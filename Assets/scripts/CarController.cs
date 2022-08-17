using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public enum Drivetrain {FWD,
        RWD,
        FourWD};
    
    private float horizontalInput, verticalInput;
    private float steeringAngle;
    
    
    [Header("Car Settings")]
    public Drivetrain drivetrain = Drivetrain.FWD;
    public float maxSteeringAngle = 30;
    public float torque = 60;

    [Header("Wheel Colliders")] 
    public WheelCollider frontRightWheel;
    public WheelCollider frontLeftWheel;
    public WheelCollider rearRightWheel;
    public WheelCollider rearLeftWheel;

    [Header("Wheels")] 
    public Transform frontRightTransform;
    public Transform frontLeftTransform;
    public Transform rearRightTransfrom;
    public Transform rearLeftTransform;
    
    private Joystick joy;

    private void GetInput()
    {
        joy = FindObjectOfType<Joystick>();
        horizontalInput = -joy.Horizontal;
        verticalInput = joy.Vertical;
    }

    private void Accelerate()
    {
        switch (drivetrain)
        {
            case Drivetrain.FWD:
                frontLeftWheel.motorTorque = torque * verticalInput;
                frontRightWheel.motorTorque = torque * verticalInput;
                break;
            case Drivetrain.RWD:
                rearLeftWheel.motorTorque = torque * verticalInput;
                rearRightWheel.motorTorque = torque * verticalInput;
                break;
            case Drivetrain.FourWD:
                frontLeftWheel.motorTorque = torque * verticalInput;
                frontRightWheel.motorTorque = torque * verticalInput;
                rearLeftWheel.motorTorque = torque * verticalInput;
                rearRightWheel.motorTorque = torque * verticalInput;
                break;
        }
    }

    private void Steer()
    {
        steeringAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheel.steerAngle = steeringAngle;
        frontRightWheel.steerAngle = steeringAngle;
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    
    private void UpdateWheelPoses()
    {
        UpdateSingleWheel(frontLeftWheel, frontLeftTransform);
        UpdateSingleWheel(frontRightWheel, frontRightTransform);
        UpdateSingleWheel(rearLeftWheel,rearLeftTransform);
        UpdateSingleWheel(rearRightWheel, rearRightTransfrom);
    }


    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}