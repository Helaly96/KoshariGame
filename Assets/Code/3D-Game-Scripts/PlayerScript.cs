using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateOfPlayer
{
    TopDown = 0,
    FirstPerson=1
}

public class PlayerScript : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public Camera TopDownCamera;
    InputHandler IP;
    StateOfPlayer PlayerState;
    FirstPersonController FPSController;
    TopDownController TDController;
    public float RotationSpeedOfTopDownCamera;
    private void Awake()
    {
        Debug.Log("Created a player");
        IP = new InputHandler();
        IP.EnableControls();
        PlayerState = StateOfPlayer.TopDown;
        FPSController = this.GetComponent<FirstPersonController>();
        TDController  = this.GetComponent <TopDownController>();
        TDController.SetRotationSpeed(RotationSpeedOfTopDownCamera);
    }

    public void SwitchCameras()
    {
        if(PlayerState==StateOfPlayer.TopDown)
        {
            TopDownCamera.gameObject.SetActive(false);
            FirstPersonCamera.gameObject.SetActive(true);
            PlayerState = StateOfPlayer.FirstPerson;
        }
        else
        {
            TopDownCamera.gameObject.SetActive(true);
            FirstPersonCamera.gameObject.SetActive(false);
            PlayerState = StateOfPlayer.TopDown;
        }
        
    }

    void FixedUpdate()
    {
        if (PlayerState == StateOfPlayer.TopDown)
        {
            if (IP.GetRightClickStatus())
            {
                TDController.RotateTopDownCameraToTarget(IP.AimAxisValue);

            }
        }
        else
        {

            FPSController.Movement(IP.bIsJumping,IP.MovementInput);
           
        }
    }
}
