using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownController : MonoBehaviour
{
    GameObject MainCamera;
    Transform GroundPlane;
    float RotationSpeed;

    void Awake()
    {
        MainCamera =  GameObject.FindGameObjectWithTag("MainCamera");
        GroundPlane     =  GameObject.FindGameObjectWithTag("GroundPlane").transform;
        MainCamera.transform.LookAt(GroundPlane);

    }

    public void SetRotationSpeed(float RTSpeed)
    {
        RotationSpeed = RTSpeed;
    }

    public void RotateTopDownCameraToTarget(float AimAxisValue)  
    {
        MainCamera.transform.LookAt(GroundPlane);
        MainCamera.transform.RotateAround(GroundPlane.position,Vector3.up, Mouse.current.delta.x.ReadValue() * RotationSpeed);

    }
}
