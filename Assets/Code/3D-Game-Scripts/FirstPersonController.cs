using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject Player;

    float GroundLength = 10;
    float JumpForce = 200;
    float JumpDelay = 0.5f;
    bool bAlreadyJumping = false;
    float moveSpeed = 700;

    public float Sensitivity;
    float Axis_x;
    float Axis_y;

    float h;
    float v;

    float xRotation = 0;

    float FirstJumpTime;

    bool  IsGrounded()
    {
        return Physics.Raycast(this.transform.position,-Vector3.up, GroundLength);
    }

    public void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void Movement(bool JumpingClicked,Vector2 MovementInput)
    {
        if (JumpingClicked)
        {
            if (bAlreadyJumping && (Time.time - FirstJumpTime > JumpDelay))
            {
                bAlreadyJumping = false;
            }

            Jump();
        }

        Axis_x = Mouse.current.delta.x.ReadValue()*Time.deltaTime*Sensitivity;
        Axis_y = Mouse.current.delta.y.ReadValue()*Time.deltaTime*Sensitivity;

        Player.transform.Rotate(Vector3.up * Axis_x);
        xRotation -= Axis_y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Player.GetComponent<PlayerScript>().FirstPersonCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        h = MovementInput.x;
        v = MovementInput.y;

        Debug.Log(h);
        Debug.Log(v);
        rb.AddForce(Player.transform.forward * v * moveSpeed * Time.deltaTime,ForceMode.Impulse);
        rb.AddForce(Player.transform.right * h * moveSpeed * Time.deltaTime, ForceMode.Impulse);

    }



    public void Jump()
    {
        
        if (IsGrounded()&& !bAlreadyJumping )
        {
            
            rb.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
            rb.AddForce(Vector3.down * Time.deltaTime * 10);
            bAlreadyJumping = true;
            FirstJumpTime = Time.time;
        }
    }
}
