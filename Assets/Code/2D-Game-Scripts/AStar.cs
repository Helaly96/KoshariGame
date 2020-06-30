using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class AStar : MonoBehaviour
{

    Dictionary<char, Vector2> LookUpTable;

    Vector2 StartPos;
    Vector2 EndPos;

    public enum CostsOfMove
    {
        Horizontal_Cost = 10,
        Vertical_Cost = 10,
        Diagonal_Cost = 5
    }


    private TextMesh[,] HCost;
    private TextMesh[,] GCost;
    private TextMesh[,] FCost;

    List<QueueElementAStar> Queue;
    List<char> Searched;

    private Sprite[] State_Colors;

    bool Grid_Not_Changed = false;
    Grid<AStarGridObject> grid;


    public AStar(int width, int height, float cellsize, int Depth, Vector3 Origin, Sprite[] CurrentSprites)
    {
        this.State_Colors = CurrentSprites;
        grid = new Grid<AStarGridObject>(width, height, cellsize, Depth, Origin, (Grid<AStarGridObject> g, int x, int y) => new AStarGridObject(g, x, y));
        HCost = new TextMesh[width, height];
        GCost = new TextMesh[width, height];
        FCost = new TextMesh[width, height];
        Queue = new List<QueueElementAStar>();
        Searched = new List<char>();
        LookUpTable = new Dictionary<char, Vector2>();
    }

    public void Calculate_H_Costs()
    {
        //Finds H's for all the grids
        char _ = 'A';

        for (int i = 0; i < grid.gridArray.GetLength(0); i++)
        {
            for (int j = 0; j < grid.gridArray.GetLength(1); j++)
            {
                float cost_ = Calculate_H_Cost(i, j);
                string cost = cost_.ToString();

                Vector3 Pos = grid.GetWorldPosition(i, j);
                float size = grid.GetCellSize();
                HCost[i, j] = UtilsClass.CreateWorldText(cost, null, Pos + new Vector3(0, size / 2, 100), 25, Color.red);
                grid.gridArray[i, j].HCost = int.Parse(cost);
                grid.gridArray[i, j].name = _;
                LookUpTable.Add(_, new Vector2(i, j));
                UtilsClass.CreateWorldText(_.ToString(), null, Pos + new Vector3(size / 2, 3, 100), 20, Color.white);
                _ = (char)((int)_ + 1);


                if (cost_ != 1000000)
                {
                    grid.gridArray[i, j].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[0];
                    
                }
                else
                {
                    grid.gridArray[i, j].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[4];
                }
                
            }
        }
    }
    public void SetInputsForA_Star(Vector2 Start,Vector2 End)
    {
        this.StartPos = Start;
        this.EndPos = End;

        //Debug.Log(StartPos);
        //Debug.Log(EndPos);
    }

    char GetGridCharXY(float x,float y)
    {
        return grid.gridArray[(int)x, (int)y].name;
    }

    static int SortByCost(QueueElementAStar p1, QueueElementAStar p2)
    {
        return p1.MyCost.CompareTo(p2.MyCost);
    }

    public void A_Star_Start()
    {
        List<char> StartingRoad = new List<char>();
        StartingRoad.Add(GetGridCharXY((int)StartPos.x, (int)StartPos.y));
        Queue.Add(new QueueElementAStar(0 + grid.gridArray[(int)StartPos.x, (int)StartPos.y].HCost, GetGridCharXY(StartPos.x, StartPos.y), StartingRoad ));
        Vector3 Pos = grid.GetWorldPosition((int)StartPos.x, (int)StartPos.y);
        FCost[(int)StartPos.x,(int)StartPos.y] = UtilsClass.CreateWorldText( (0 + grid.gridArray[(int)StartPos.x, (int)StartPos.y].HCost).ToString(), null, Pos + new Vector3(7, 2 , 100), 20, Color.white);
        grid.gridArray[(int)StartPos.x, (int)StartPos.y].G_Cost = 0;
        GCost[(int)StartPos.x, (int)StartPos.y] = UtilsClass.CreateWorldText((0).ToString(), null, Pos + new Vector3(7, 7, 100), 20, Color.yellow);



        Debug.Log("The END IS AT CHARACTER "+GetGridCharXY((int)EndPos.x, (int)EndPos.y));
    }

    public void AddElementsToQueue(float i, float j,CostsOfMove TypeOfMovement,List<char>RoadSoFar)
    {
        
            if ((i <= grid.gridArray.GetLength(0) - 1) && (j <= grid.gridArray.GetLength(1) - 1) && (i >= 0) && (j >= 0))
            {
                if((grid.gridArray[(int)i, (int)j].walkable_))
                {
                    float cost = grid.gridArray[(int)i, (int)j].HCost + (int)TypeOfMovement;
                    char Name = GetGridCharXY(i, j);
                    if (!(Searched.Contains(Name)))
                    {
                        List<char> R_ = new List<char>();
                        for (int q = 0; q < RoadSoFar.Count; q++)
                        {
                            R_.Add(RoadSoFar[q]);
                        }
                        R_.Add(Name);
                        QueueElementAStar _ = new QueueElementAStar(cost, Name, R_);
                        //_.PrintTheCurrentRoad();
                        Queue.Add(_);
                        grid.gridArray[(int)i, (int)j].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[1];
                    }
            }
                
            }
        
        
    }

    public void Test_Step()
    {
        QueueElementAStar Current = Queue[0];

        if (Current.Name.Equals(GetGridCharXY(EndPos.x, EndPos.y)))
        {

            Vector2 GO = GetXYFromName(Current.Name);
            float _i = GO.x;
            float _j = GO.y;

            for (int i = 0; i < Current.road_.Count; i++)
            {
                Vector2 __ = GetXYFromName(Current.road_[i]);
                grid.gridArray[(int)__[0], (int)__[1]].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[3];

            }
            return;
        }


        Queue.RemoveAt(0);
        Debug.Log(Current.Name + "  " + GetGridCharXY(EndPos.x, EndPos.y));
        if (!(Searched.Contains(Current.Name)))
        {
            //Get its original grid node
            Vector2 GO = GetXYFromName(Current.Name);


            float _i = GO.x;
            float _j = GO.y;

            Debug.Log("THE CURRENT IS " + Current.Name + " and has i of " + _i + " and j of   " + _j);

            AddElementsToQueue(_i + 1, _j, CostsOfMove.Vertical_Cost, Current.road_);
            AddElementsToQueue(_i - 1, _j, CostsOfMove.Vertical_Cost, Current.road_);
            AddElementsToQueue(_i, _j + 1, CostsOfMove.Horizontal_Cost, Current.road_);
            AddElementsToQueue(_i, _j - 1, CostsOfMove.Horizontal_Cost, Current.road_);

            AddElementsToQueue(_i + 1, _j + 1, CostsOfMove.Diagonal_Cost, Current.road_);
            AddElementsToQueue(_i - 1, _j - 1, CostsOfMove.Diagonal_Cost, Current.road_);
            AddElementsToQueue(_i + 1, _j - 1, CostsOfMove.Diagonal_Cost, Current.road_);
            AddElementsToQueue(_i - 1, _j + 1, CostsOfMove.Diagonal_Cost, Current.road_);

            grid.gridArray[(int)_i, (int)_j].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[2];

            Searched.Add(Current.Name);


            Queue.Sort(SortByCost);


        }
    }

    public void A_Star_Step()
    {
        //Get the first Element
        while(true)
        {
            QueueElementAStar Current = Queue[0];

            if (Current.Name.Equals(GetGridCharXY(EndPos.x, EndPos.y)))
            {

                Vector2 GO = GetXYFromName(Current.Name);
                float _i = GO.x;
                float _j = GO.y;

                for (int i = 0; i < Current.road_.Count; i++)
                {
                    Vector2 __ = GetXYFromName(Current.road_[i]);
                    grid.gridArray[(int)__[0], (int)__[1]].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[3];

                }
                break;
            }


            Queue.RemoveAt(0);
            Debug.Log(Current.Name + "  " + GetGridCharXY(EndPos.x, EndPos.y));
            if (!(Searched.Contains(Current.Name)))
            {
                //Get its original grid node
                Vector2 GO = GetXYFromName(Current.Name);


                float _i = GO.x;
                float _j = GO.y;

                Debug.Log("THE CURRENT IS " + Current.Name + " and has i of " + _i + " and j of   " + _j);

                AddElementsToQueue(_i + 1, _j, CostsOfMove.Vertical_Cost, Current.road_);
                AddElementsToQueue(_i - 1, _j, CostsOfMove.Vertical_Cost, Current.road_);
                AddElementsToQueue(_i, _j + 1, CostsOfMove.Horizontal_Cost, Current.road_);
                AddElementsToQueue(_i, _j - 1, CostsOfMove.Horizontal_Cost, Current.road_);

                AddElementsToQueue(_i + 1, _j + 1, CostsOfMove.Diagonal_Cost, Current.road_);
                AddElementsToQueue(_i - 1, _j - 1, CostsOfMove.Diagonal_Cost, Current.road_);
                AddElementsToQueue(_i + 1, _j - 1, CostsOfMove.Diagonal_Cost, Current.road_);
                AddElementsToQueue(_i - 1, _j + 1, CostsOfMove.Diagonal_Cost, Current.road_);

                grid.gridArray[(int)_i, (int)_j].MySprite.GetComponent<SpriteRenderer>().sprite = State_Colors[2];

                Searched.Add(Current.Name);


                Queue.Sort(SortByCost);

                
            }

            
        }
        

    }
 


    public Vector2 GetXYFromName(char x)
    {
        return LookUpTable[x];
    }

    float Calculate_H_Cost(int x,int y)
    {
        if (grid.gridArray[x, y].walkable_)
        {
            float Horizontal_diff = Math.Abs(EndPos.x - x);
            float Vertical_diff = Math.Abs(EndPos.y - y);

            float temp = Math.Min(Horizontal_diff, Vertical_diff);

            return ((int)CostsOfMove.Diagonal_Cost * Math.Min(Horizontal_diff, Vertical_diff)) + ((int)CostsOfMove.Horizontal_Cost * (Horizontal_diff - temp)) + ((int)CostsOfMove.Vertical_Cost * (Vertical_diff - temp));
        }
        else
        {
            return 1000000;
        }

    }

    
    public  void SetUnWalkable(Vector3 j)
    {
        int x, y;
        grid.GetXYFromWorldPosition(j, out x, out y);
        grid.gridArray[x,y].walkable_ = false;
    }
}

public class AStarGridObject
{

    int x;
    int y;

    public char name;

    public float G_Cost;
    public float F_Cost;

    public bool walkable_ = true;

    private Grid<AStarGridObject> grid;
    public GameObject MySprite;
    public float HCost;
    private State MyState;
    public enum State
    {
        None,
        Openlist,
        Searched,
        GoalIsFound
    }



    //Constructor
    public AStarGridObject(Grid<AStarGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        MySprite = new GameObject();
        float CZ = grid.GetCellSize();
        MySprite.transform.position = new Vector3((x * CZ) + grid.GetOriginPos().x, (y * CZ) + grid.GetOriginPos().y, grid.GetDepthOfGrid());
        MySprite.AddComponent<SpriteRenderer>();

    }

    public char GetGridName()
    {
        return name;
    }
}

public class QueueElementAStar
{
    public float MyCost;
    public char Name;
    public List<char> road_;

    public QueueElementAStar(float Cost,char Name,List<Char>road_)
    {
        MyCost = Cost;
        this.Name = Name;
        this.road_ = road_;
    }

    public  void PrintTheCurrentRoad()
    {
        Debug.Log("########"+Name+ "########");
        for (int i=0;i<road_.Count;i++)
        {
            Debug.Log(road_[i].ToString());
        }
        Debug.Log("########");
    }

}