using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject horizontalCamera;
    [SerializeField] private GameObject verticalCamera;
    [SerializeField] private GameObject withBallCamera;

    private void Start()
    {
        withBallCamera.SetActive(true);
    }

    public void SetCameraMovementHorizontal()
    {
        horizontalCamera.SetActive(true);
        verticalCamera.SetActive(false);
        withBallCamera.SetActive(false);
    }

    public void SetCameraMovementVertical()
    {
        verticalCamera.SetActive(true);
        horizontalCamera.SetActive(false);
        withBallCamera.SetActive(false);
    }

    public void SetCameraMovementWithBall()
    {
        withBallCamera.SetActive(true);
        horizontalCamera.SetActive(false);
        verticalCamera.SetActive(false);
    }
}
