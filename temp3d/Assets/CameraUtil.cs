using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraUtil : MonoBehaviour
{
    private CinemachineVirtualCamera currentVCam;
    [SerializeField] private GameObject ball;

    public void moveCameraToBall()
    {
        currentVCam.gameObject.SetActive(false);
        transform.position = ball.transform.position;
        currentVCam.gameObject.SetActive(true);
    }

    private void Update()
    {
        currentVCam = GetComponent<CinemachineBrain>().ActiveVirtualCamera as CinemachineVirtualCamera; //always null on first frame
    }
}
