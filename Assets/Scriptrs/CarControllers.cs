using System;
using Unity.VisualScripting;
using UnityEngine;

public class CarControllers : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private WheelColliders wheelCollider;
    [SerializeField] private WheelMeshes wheelMeshes;
    [SerializeField] private float motorPower;
    [SerializeField] private AnimationCurve steeringCurve;
    [SerializeField] private float breakPower;
    private float gasInput;
    private float steerInput;
    private float speed;
    private float steeringAngle;
    private float slipAngle;
    private float breakInput;

    void Update()
    {
        speed = rb.linearVelocity.magnitude;
        HandleInput();
        HandleSteering();
        HandleMotorPower();
        ApplyBrake();
        HandleWheelPosition();
    }

    private void ApplyBrake()
    {
        wheelCollider.FrontLeftWheel.brakeTorque = breakInput * breakPower * 0.7f;
        wheelCollider.FrontRightWheel.brakeTorque = breakInput * breakPower * 0.7f;
        wheelCollider.BackLeftWheel.brakeTorque = breakInput * breakPower * 0.3f;
        wheelCollider.BackRightWheel.brakeTorque = breakInput * breakPower * 0.3f;
    }

    private void HandleSteering()
    {
        steeringAngle = steerInput * steeringCurve.Evaluate(speed);
        wheelCollider.FrontRightWheel.steerAngle = steeringAngle;
        wheelCollider.FrontLeftWheel.steerAngle = steeringAngle;

    }

    private void HandleMotorPower()
    {
        wheelCollider.FrontRightWheel.motorTorque = gasInput * motorPower;
        wheelCollider.FrontLeftWheel.motorTorque = gasInput * motorPower;
        wheelCollider.BackRightWheel.motorTorque = gasInput * motorPower;
        wheelCollider.BackLeftWheel.motorTorque = gasInput * motorPower;
    }

    void HandleInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward, rb.linearVelocity - transform.forward);
        if (slipAngle < 120)
        {
            if (gasInput < 0)
            {
                breakInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }

        }
        else
        {
            breakInput = 0;
        }

    }
    private void HandleWheelPosition()
    {
        Updatewheelpositions(wheelCollider.FrontRightWheel, wheelMeshes.FrontRightWheel);
        Updatewheelpositions(wheelCollider.FrontLeftWheel, wheelMeshes.FrontLeftWheel);
        Updatewheelpositions(wheelCollider.BackRightWheel, wheelMeshes.BackRightWheel);
        Updatewheelpositions(wheelCollider.BackLeftWheel, wheelMeshes.BackLeftWheel);

    }

    void Updatewheelpositions(WheelCollider coll, MeshRenderer mesh)
    {
        Quaternion quat;
        Vector3 pos;
        coll.GetWorldPose(out pos, out quat);
        mesh.transform.position = pos;
        mesh.transform.rotation = quat;
    }

}
