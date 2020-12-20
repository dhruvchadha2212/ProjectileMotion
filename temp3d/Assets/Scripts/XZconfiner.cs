using UnityEngine;
using Cinemachine;

public class XZconfiner : CinemachineExtension
{
    private float fixedYPosition;
    [SerializeField] private Rigidbody sphere;

    private void OnEnable()
    {
        fixedYPosition = sphere.transform.position.y;
    }

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
