using UnityEngine;

public class OrientationModifier : MonoBehaviour
{
    [SerializeField] private Vector3 scalePotrait;
    [SerializeField] private Vector3 scaleLandscape;

    void Update()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            this.gameObject.transform.localScale = scalePotrait;
        }
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            this.gameObject.transform.localScale = scaleLandscape;
        }
    }

}
