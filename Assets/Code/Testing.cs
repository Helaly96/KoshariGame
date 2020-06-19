using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    //fun signature that can be used as a variable
    public delegate void TestDelegate();

    //can be assigned to a funcution that matches the signature
    private TestDelegate TestingDelegate;

    Grid<bool> grid;
    private int DEPTH_OF_THE_GRID = 100;
    TileMap newTile;

    public Sprite[] Sprites;

    //defining unity event
    public UnityEvent testunityevent;

    int test_count = 0;

    int tile_to_be_placed = -1;

    //defining custom event
    public event EventHandler<OnMousePressEventArgs> OnMousePress;
    public class OnMousePressEventArgs : EventArgs 
    {
        public int count;
    }

    // Start is called before the first frame update

    private void Test1()
    {
        Debug.Log("HELLO!1");
    }
    
    private void Test2()
    {
        Debug.Log("HELLO!2");
    }
    private void TEST(object sender, OnMousePressEventArgs e)
    {
        Debug.Log(e.count);
    }

    public void printey()
    {
        Debug.Log("Test");
    }

    void Start()
    {
        //Subscribing to the event
        OnMousePress += TEST;
        //ARGS                        //The Returned Value (TGRIDOBJECT)
        //grid = new Grid<bool>(10, 10, 10, DEPTH_OF_THE_GRID, new Vector3(0, 10, 0), (Grid<bool> g, int x, int y) => new bool());
        newTile = new TileMap(5, 5, 10, DEPTH_OF_THE_GRID, new Vector3(0, 10, 0), Sprites);

        //TestingDelegate = Test1;
        //TestingDelegate += Test2;
        //TestingDelegate += delegate () { Debug.Log("Annoynumus fn"); };
        //TestingDelegate += () => { Debug.Log("Lambda"); };
        //TestingDelegate();
    }

 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //test_count += 1;
            //grid.SetElemetValue(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), true);
            //OnMousePress?.Invoke(this, new OnMousePressEventArgs { count = test_count });
            //testunityevent?.Invoke();
            //newTile.SetTileMapObject(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), TilemapObject.TileMapSprite.Ground);
            if(tile_to_be_placed == -1)
            {
                newTile.SetTileMapObject(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), TilemapObject.TileMapSprite.None);

            }
            else if (tile_to_be_placed == 1)
            {
                newTile.SetTileMapObject(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), TilemapObject.TileMapSprite.Grass);

            }
            else if(tile_to_be_placed == 2)
            {
                newTile.SetTileMapObject(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), TilemapObject.TileMapSprite.Sand);

            }

            else if (tile_to_be_placed == 3)
            {
                newTile.SetTileMapObject(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), TilemapObject.TileMapSprite.test_1);

            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UtilsClass.CreateWorldTextPopup(null, "Grass", Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID),20,Color.green, Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID)+new Vector3(0,2,0), 1);
            tile_to_be_placed = 1;

        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UtilsClass.CreateWorldTextPopup(null, "Sand", Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), 20, Color.yellow, Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID) + new Vector3(0, 2, 0), 1);
            tile_to_be_placed = 2;

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UtilsClass.CreateWorldTextPopup(null, "KoshariTest", Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID), 20, Color.yellow, Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID) + new Vector3(0, 2, 0), 1);
            tile_to_be_placed = 3;

        }

        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(newTile.GetTileObjectValue(Helper.GetMousePosition(Input.mousePosition, DEPTH_OF_THE_GRID)));
        }

        

      
    }


}
