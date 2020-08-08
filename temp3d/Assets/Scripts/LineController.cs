using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer line;
    private float velocityMagnifier = 20;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
    }
    public void InitiliseLine(Vector3 ballPosition)
    {
        line.positionCount = 2;
        line.SetPosition(0, ballPosition);
        line.SetPosition(1, ballPosition);
    }

    public void UpdateEndPoint(Vector3 mousePosition, Vector3 ballPosition)
    {
        Vector3 mousePositionInWorld = GameUtil.GetMousePositionInWorld(mousePosition, ballPosition);
        line.SetPosition(1, mousePositionInWorld);
    }

    public Vector3 GetInitialVelocity()
    {
        return velocityMagnifier * (line.GetPosition(1) - line.GetPosition(0));
    }

    public double GetInitialAngle()
    {
        Vector3 lineLength = line.GetPosition(1) - line.GetPosition(0);
        return PhysicsUtil.GetInitialAngleInDegrees(lineLength.y, lineLength.x);
    }

    public void RemoveLineEndPoints()
    {
        line.positionCount = 0;
    }
}
