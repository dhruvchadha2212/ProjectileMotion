using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LineController lineController;
    private Rigidbody rb;
    private Vector3 initialVelocity;
    private float velocityThreshold = 10;
    private double initialAngle;
    
    private bool lineBeingRendered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        //TODO temporarily stopping ball on velocity < 1 and mouse click. Check line rendering issue having fixed 
        //constant start point
        if (rb.velocity.magnitude <= 1)
        {
            rb.velocity = new Vector3(0, 0, 0);
            lineController.InitiliseLine(rb.transform.position);
            lineBeingRendered = true;
        }
    }

    void OnMouseDrag() 
    {
        if (rb.velocity.magnitude <= 1 && lineBeingRendered)
        {
            rb.velocity = new Vector3(0, 0, 0);
            lineController.UpdateEndPoint(Input.mousePosition, rb.transform.position);
            initialVelocity = lineController.GetInitialVelocity();
            initialAngle = lineController.GetInitialAngle();
            uiManager.DisplayVelocityAndAngle(initialVelocity.magnitude, initialAngle);
        }
    }

    private void OnMouseUp()
    {
        if (rb.velocity.magnitude <= 1 && lineBeingRendered)
        {
            lineController.RemoveLineEndPoints();
            if(initialVelocity.magnitude > velocityThreshold)
            {
                GameState.ballWasJustLaunched = true;
                rb.velocity = initialVelocity;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (GameState.ballWasJustLaunched)
            {
                GameState.ballWasJustLaunched = false;
                GameState.ballHasBouncedOnce = true;
                double maxHeight = PhysicsUtil.GetProjectileMaxHeight(initialVelocity.magnitude, initialAngle);
                double range = PhysicsUtil.GetProjectileRange(initialVelocity.magnitude, initialAngle);
                uiManager.DisplayRangeAndMaxHeight(range, maxHeight);
                UIManager.ShowBackground();
            }
            else
            {
                GameState.ballHasBouncedOnce = false;
            }
        }
    }
}
