using UnityEngine;
using UnityEngine.UI;

public class MetricsPanelController : MonoBehaviour
{
    [SerializeField] private Text initialVelocityText;
    [SerializeField] private Text initialAngleText;
    [SerializeField] private Text rangeText;
    [SerializeField] private Text maxHeightText;

    public void DisplayInitialVelocity(string initialVelocity)
    {
        initialVelocityText.text = initialVelocity;
    }

    public void DisplayInitialAngle(string initialAngle)
    {
        initialAngleText.text = initialAngle;
    }

    public void DisplayRange(string range)
    {
        rangeText.text = range;
    }

    public void DisplayMaxHeight(string maxHeight)
    {
        maxHeightText.text = maxHeight;
    }
}
