using UnityEngine;
using Cinemachine;

public class XZconfiner : CinemachineExtension
{
    [Tooltip("Lock the camera's Y position to this value")]
    private float fixedYPosition = 0.1f;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            state.RawPosition = new Vector3(state.RawPosition.x, fixedYPosition, state.RawPosition.z);
        }
    }
}
