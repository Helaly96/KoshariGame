using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    //public static Helper KoshariUtils;

    public static void DrawRectangle (Vector3 CurrentWorldPosition , float CellSize)
    {
        Vector3 EndPoint   = CurrentWorldPosition + new Vector3(CellSize,CellSize,0);
        Vector3 RightPoint = CurrentWorldPosition + new Vector3(CellSize, 0, 0);
        Vector3 TopPoint   = CurrentWorldPosition + new Vector3(0, CellSize, 0);

        Debug.DrawLine(CurrentWorldPosition, RightPoint , Color.white, 100);
        Debug.DrawLine(CurrentWorldPosition, TopPoint   , Color.white, 100);
        Debug.DrawLine(RightPoint,           EndPoint   , Color.white, 100);
        Debug.DrawLine(TopPoint,             EndPoint   , Color.white, 100);
    }
    
    public static Vector3 GetMousePosition(Vector3 mousePos, int Depth)
    {
        mousePos.z = Depth;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public static Vector3 MoveCamera(Vector3 CameraPos,string dir,int speed,int distance)
    {
        switch (dir)
        {

        case ("Up"):
                CameraPos+=new Vector3(0,speed*Time.deltaTime*distance,0);
                break;

        case ("Down"):
                CameraPos += new Vector3(0, - speed * Time.deltaTime * distance, 0);
                break;

        case ("Left"):
                CameraPos += new Vector3(-speed * Time.deltaTime * distance,0, 0);
                break;

        case ("Right"):
                CameraPos += new Vector3(speed * Time.deltaTime * distance, 0, 0);
                break;

        }

        return CameraPos;

    }


    
    
}
