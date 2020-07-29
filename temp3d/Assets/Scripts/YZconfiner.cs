using UnityEngine;
using Cinemachine;

public class YZconfiner : CinemachineExtension
{
    [SerializeField] private Rigidbody sphere;
    private float fixedXPosition;

    private void OnEnable()
    {
        fixedXPosition = sphere.transform.position.x;
    }

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            state.RawPosition = new Vector3(fixedXPosition, state.RawPosition.y, state.RawPosition.z);
        }
    }
}