using UnityEngine;
namespace CarControllers
{
    public class WheelBraking : MonoBehaviour
    {
        private WheelSteering wheelSteering;

        void Start()
        {
            wheelSteering = GetComponent<WheelSteering>();
        }

        public void ApplyBrake(float brakeInput, float brakePower)
        {
            wheelSteering.setWheelBreake(wheelSteering.getWheelColliders().FrontLeftWheel, brakeInput * brakePower * 0.7f);
            wheelSteering.setWheelBreake(wheelSteering.getWheelColliders().FrontRightWheel, brakeInput * brakePower * 0.7f);
            wheelSteering.setWheelBreake(wheelSteering.getWheelColliders().BackLeftWheel, brakeInput * brakePower * 0.3f);
            wheelSteering.setWheelBreake(wheelSteering.getWheelColliders().BackRightWheel, brakeInput * brakePower * 0.3f);
        }

    }
}
