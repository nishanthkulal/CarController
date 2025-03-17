using UnityEngine;
namespace CarControllers
{
    public class WheelMotor : MonoBehaviour
    {
        private WheelSteering wheelSteering;

        void Start()
        {
            wheelSteering = GetComponent<WheelSteering>();
        }

        public void ApplyMotorPower(float gasInput, float motorPower)
        {
            wheelSteering.setWheelTorque(wheelSteering.getWheelColliders().FrontLeftWheel, gasInput * motorPower);
            wheelSteering.setWheelTorque(wheelSteering.getWheelColliders().FrontRightWheel, gasInput * motorPower);
            wheelSteering.setWheelTorque(wheelSteering.getWheelColliders().BackLeftWheel, gasInput * motorPower);
            wheelSteering.setWheelTorque(wheelSteering.getWheelColliders().BackRightWheel, gasInput * motorPower);
        }
    }

}
