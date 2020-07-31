using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LineController lineController;
    private Rigidbody rb;
    private Vector3 initialVelocity;
    private float velocityThreshold = 10;
    private double initialAngle;
    
    private bool isJustLaunched = false;
    public static bool hasBouncedOnce = false;
    private bool lineBeingRendered = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (rb.velocity == new Vector3(0, 0, 0))
        {
            lineController.InitiliseLine(rb.transform.position);
            lineBeingRendered = true;
        }
    }

    void OnMouseDrag() 
    {
        if (rb.velocity == new Vector3(0, 0, 0) && lineBeingRendered)
        {
            lineController.UpdateEndPoint(Input.mousePosition, rb.transform.position);
            initialVelocity = lineController.GetInitialVelocity();
            initialAngle = lineController.GetInitialAngle();
            uiManager.DisplayVelocityAndAngle(initialVelocity.magnitude, initialAngle);
        }
    }

    private void OnMouseUp()
    {
        if (rb.velocity == new Vector3(0, 0, 0) && lineBeingRendered)
        {
            lineController.RemoveLineEndPoints();
            if(initialVelocity.magnitude > velocityThreshold)
            {
                isJustLaunched = true;
                rb.velocity = initialVelocity;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            if (isJustLaunched)
            {
                isJustLaunched = false;
                hasBouncedOnce = true;
                double maxHeight = PhysicsUtil.GetProjectileMaxHeight(initialVelocity.magnitude, initialAngle);
                double range = PhysicsUtil.GetProjectileRange(initialVelocity.magnitude, initialAngle);
                uiManager.DisplayRangeAndMaxHeight(range, maxHeight);
            }
            else
            {
                hasBouncedOnce = false;
            }
        }
    }
}
