using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using System.Dynamic;

public class Grid<TGridObject>
{
    private int width;
    private int height;
    private int DepthOfGrid;
    public TGridObject[,] gridArray;
    private TextMesh[,] debugValues;
    private float CellSize;
    private Vector3 OriginPos;

    public  void TriggerChangeInGUI(int x,int y)
    {
        debugValues[x, y].text = gridArray[x, y].ToString();
    }

    public Vector3 GetOriginPos()
    {
        return OriginPos;
    }

    public int GetDepthOfGrid()
    {
        return DepthOfGrid;
    }

    public float GetCellSize()
    {
        return CellSize;
    }
    //THIS MEANS IT WILL RECIEVE A FUNCUTION TO DECLARE THE OBJECT!!
    // THAT FUNCUTION TAKES GRID,INT,INT and OUTPUTS TGRIDOBJECT, FOLLOWED BY ITS NAME

    public Grid(int width, int height, float CellSize, int depth, Vector3 OriginPos)
    {
        this.width = width;
        this.height = height;
        this.CellSize = CellSize;
        this.DepthOfGrid = depth;
        this.OriginPos = OriginPos;

        gridArray = new TGridObject[width, height];
        debugValues = new TextMesh[width, height];


        Debug.Log("Initiated a grid with Width =  " + width.ToString() + " Cells  and height =  " + height.ToString() + " Cells");

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                Vector3 CurrentWorldPosition = GetWorldPosition(i, j);
                CurrentWorldPosition.z = depth;
                //debugValues[i, j] = UtilsClass.CreateWorldText(gridArray[i, j]?.ToString(), null, CurrentWorldPosition + new Vector3(CellSize / 2, CellSize / 2, 0), 10, Color.white);
                Helper.DrawRectangle(CurrentWorldPosition, CellSize);
            }
        }

    }

    public Grid(int width,int height, float CellSize, int depth , Vector3 OriginPos, Func<Grid<TGridObject>,int,int,TGridObject> CreateObject)
    {
        this.width  = width;
        this.height = height;
        this.CellSize = CellSize;
        this.DepthOfGrid = depth;
        this.OriginPos = OriginPos;

        gridArray = new TGridObject[width, height];
        debugValues = new TextMesh[width, height];

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                gridArray[i, j] = CreateObject(this,i,j);
            }
        }

                Debug.Log("Initiated a grid with Width =  "+ width.ToString()+ " Cells  and height =  "+ height.ToString()+" Cells");

        for(int i = 0; i<gridArray.GetLength(0);i++)
        {
            for(int j=0;j<gridArray.GetLength(1);j++)
            {
                Vector3 CurrentWorldPosition = GetWorldPosition(i,j);
                CurrentWorldPosition.z = depth;
                //debugValues[i,j]=UtilsClass.CreateWorldText(gridArray[i, j]?.ToString(), null, CurrentWorldPosition+new Vector3(CellSize/2,CellSize/2,0), 20, Color.white);
                Helper.DrawRectangle(CurrentWorldPosition, CellSize);
            }
        }

    }

    public void GetXYFromWorldPosition(Vector3 WorldPosition,out int x,out int y)
    {
        x = Mathf.FloorToInt( (WorldPosition.x - OriginPos.x) / CellSize);
        y = Mathf.FloorToInt( (WorldPosition.y - OriginPos.y) / CellSize);
    }

    public Vector3 GetWorldPosition(int x,int y)
    {
        return OriginPos + (new Vector3(x, y) * CellSize);
    }
    

    private void  SetGridElementValue(int x,int y, TGridObject value)
    {
        gridArray[x, y] = value;
        debugValues[x, y].text = value.ToString();
    }

    private TGridObject GetGridValue(int x, int y)
    {
       if (x<=gridArray.GetLength(0)-1 && y<= gridArray.GetLength(1)-1)     
       {
            return gridArray[x, y];
       }
        return default;
    }

    public TGridObject GetGridValue(Vector3 WorldPos)
    {
        int x, y;
        GetXYFromWorldPosition(WorldPos, out x, out y);
        return GetGridValue(x, y);
    }


    public  void SetElemetValue(Vector3 WorldPosition , TGridObject value)
    {
        int x, y;
        GetXYFromWorldPosition(WorldPosition, out x, out y);
        SetGridElementValue(x, y, value);
    }
}
