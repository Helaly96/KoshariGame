using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = Helper.MoveCamera(this.transform.position, "Up", 10, 10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = Helper.MoveCamera(this.transform.position, "Down", 10, 10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = Helper.MoveCamera(this.transform.position, "Left", 10, 10);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position =  Helper.MoveCamera(this.transform.position, "Right", 10, 10);
        }
    }
}
