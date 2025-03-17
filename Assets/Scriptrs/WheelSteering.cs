using UnityEngine;
namespace CarControllers
{
    public class WheelSteering : MonoBehaviour
    {
        [SerializeField] private WheelColliders wheelColliders;

        internal WheelColliders getWheelColliders()
        {
            return wheelColliders;
        }

        internal void setWheelTorque(WheelCollider wheelCollider, float power)
        {
            wheelCollider.motorTorque = power;
        }
        internal void setWheelBreake(WheelCollider wheelCollider, float power)
        {
            wheelCollider.brakeTorque = power;
        }

        public void ApplySteering(float steerInput, float steeringAngle)
        {
            wheelColliders.FrontLeftWheel.steerAngle = steerInput * steeringAngle;
            wheelColliders.FrontRightWheel.steerAngle = steerInput * steeringAngle;
        }
    }

}
