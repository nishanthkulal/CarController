using System;
using UnityEngine;
namespace CarControllers
{

    public class CarController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float motorPower;
        [SerializeField] private AnimationCurve steeringCurve;
        [SerializeField] private float brakePower;
        private WheelSteering wheelSteering;
        private WheelMotor wheelMotor;
        private WheelBraking wheelBraking;
        private WheelPositionUpdater wheelPositionUpdater;
        private InputHandler inputHandler;


        private float speed;
        void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
            wheelSteering = GetComponent<WheelSteering>();
            wheelMotor = GetComponent<WheelMotor>();
            wheelBraking = GetComponent<WheelBraking>();
            wheelPositionUpdater = GetComponent<WheelPositionUpdater>();
        }

        void Update()
        {
            speed = rb.linearVelocity.magnitude;
            inputHandler.HandleInput(speed);
            wheelSteering.ApplySteering(inputHandler.SteerInput, steeringCurve.Evaluate(speed));
            wheelMotor.ApplyMotorPower(inputHandler.GasInput, motorPower);
            wheelBraking.ApplyBrake(inputHandler.BrakeInput, brakePower);
            wheelPositionUpdater.UpdateWheelPositions();
        }
    }

}
