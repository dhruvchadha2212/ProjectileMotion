using UnityEngine;
using UnityEngine.UI;
using System;

public class BallController : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LineRenderer initialVelocityLine;
    private Rigidbody rb;
    private Vector3 initialVelocity;
    private double initialAngle;
    private float velocityMagnifier = 10;
    private bool isJustLaunched = false;
    public static bool hasBouncedOnce = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (rb.velocity == new Vector3(0, 0, 0))
        {
            initialVelocityLine.positionCount = 2;
            initialVelocityLine.SetPosition(0, rb.transform.position);
            initialVelocityLine.SetPosition(1, rb.transform.position);
        }
    }

    void OnMouseDrag() 
    {
        if (rb.velocity == new Vector3(0, 0, 0) && initialVelocityLine.positionCount == 2)
        {
            Vector3 mousePositionInWorld = GameUtil.GetMousePositionInWorld(Input.mousePosition, rb.transform.position);
            initialVelocityLine.SetPosition(1, mousePositionInWorld);
            initialVelocity = velocityMagnifier * (initialVelocityLine.GetPosition(1) - initialVelocityLine.GetPosition(0));
            initialAngle = PhysicsUtil.GetInitialAngleInDegrees(initialVelocity.y, initialVelocity.x);
            uiManager.DisplayVelocityAndAngle(initialVelocity.magnitude, initialAngle);
        }
    }

    private void OnMouseUp()
    {
        if (rb.velocity == new Vector3(0, 0, 0) && initialVelocityLine.positionCount == 2)
        {
            initialVelocityLine.positionCount = 0;
            if(initialVelocity.magnitude > velocityMagnifier)
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
