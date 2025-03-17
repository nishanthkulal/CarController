using UnityEngine;
namespace CarControllers
{
    public class WheelPositionUpdater : MonoBehaviour
    {
        //[SerializeField] private WheelColliders wheelColliders;
        [SerializeField] private WheelMeshes wheelMeshes;

        private WheelSteering wheelSteering;

        void Start()
        {
            wheelSteering = GetComponent<WheelSteering>();
        }

        public void UpdateWheelPositions()
        {
            UpdateWheelPosition(wheelSteering.getWheelColliders().FrontLeftWheel, wheelMeshes.FrontLeftWheel);
            UpdateWheelPosition(wheelSteering.getWheelColliders().FrontRightWheel, wheelMeshes.FrontRightWheel);
            UpdateWheelPosition(wheelSteering.getWheelColliders().BackLeftWheel, wheelMeshes.BackLeftWheel);
            UpdateWheelPosition(wheelSteering.getWheelColliders().BackRightWheel, wheelMeshes.BackRightWheel);
        }

        private void UpdateWheelPosition(WheelCollider coll, MeshRenderer mesh)
        {
            coll.GetWorldPose(out Vector3 pos, out Quaternion quat);
            mesh.transform.position = pos;
            mesh.transform.rotation = quat;
        }
    }

}
