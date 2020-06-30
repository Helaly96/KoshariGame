using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    PlayerControls control;
    public float AimAxisValue;
    bool RightClicked = false;
    public bool bIsJumping = false;
    GameObject Player;

    public Vector2 MovementInput;
    public InputHandler()
    {
        Debug.Log("Input Handler Created");
        control = new PlayerControls();
        Player = GameObject.FindGameObjectWithTag("Player");
        control.GamePlay.AimAxis.performed += ctx => this.AimAxisValue = ctx.ReadValue<float>();
        control.GamePlay.RightClick.performed += ctx => RightClicked = true;
        control.GamePlay.RightClick.canceled += ctx => RightClicked = false;
        control.GamePlay.SwitchCameras.performed += ctx => Player.GetComponent<PlayerScript>().SwitchCameras();
        control.GamePlay.Jump.performed += ctx => bIsJumping = true;
        control.GamePlay.Jump.canceled  += ctx => bIsJumping = false;
        control.GamePlay.WASD.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
    }


    public bool GetRightClickStatus()
    {
        return RightClicked;
    }

    public void EnableControls()
    {
        control.GamePlay.Enable();
    }

    public void DisableControls()
    {
        control.GamePlay.Disable();
    }

}
