using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TileMap
{
    private Sprite[] CurrentSprites;
    private Grid<TilemapObject> grid;

    public TileMap(int width,int height , float cellsize, int Depth ,Vector3 Origin,Sprite[] CurrentSprites)
    {
        this.CurrentSprites = CurrentSprites;
        grid = new Grid<TilemapObject>(width, height, cellsize, Depth, Origin,(Grid<TilemapObject>g,int x,int y)=> new TilemapObject(g,x,y));
    }

    public void SetTileMapObject(Vector3 Worldpos,TilemapObject.TileMapSprite Sprite)
    {
        int x, y;
        grid.GetXYFromWorldPosition(Worldpos, out x, out y);
        TilemapObject T = grid.GetGridValue(Worldpos);
        T.SetTileMapSprite(Sprite);
        //grid.TriggerChangeInGUI(x, y);
        T.UpdateSprite(CurrentSprites);

    }
    public string GetTileObjectValue(Vector3 Worldpos)
    {
        TilemapObject T = grid.GetGridValue(Worldpos);
        return T._Sprite.ToString();
    }
}

public class TilemapObject
{
    public enum TileMapSprite
    {
        None,
        Grass,
        Sand,
        test_1
    }

    private Grid<TilemapObject> grid;
    public  GameObject MySprite;
    private int x;
    private int y;
    public TileMapSprite _Sprite;

    public TilemapObject (Grid<TilemapObject> grid,int x,int y)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
        MySprite = new GameObject();
        float CZ = grid.GetCellSize();
        MySprite.transform.position = new Vector3((x* CZ)+ grid.GetOriginPos().x, (y*CZ)+ grid.GetOriginPos().y , grid.GetDepthOfGrid());
        MySprite.AddComponent<SpriteRenderer>();
    }

    public void UpdateSprite(Sprite[] Sprites )
    {
        if(_Sprite== TileMapSprite.Grass)
        {
            MySprite.GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if (_Sprite == TileMapSprite.Sand)
        {
            MySprite.GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
        else if (_Sprite == TileMapSprite.test_1)
        {
            Debug.Log("Error");
            MySprite.GetComponent<SpriteRenderer>().sprite = Sprites[2];
        }


    }

    public void SetTileMapSprite(TileMapSprite TS)
    {
        this._Sprite = TS;

    }

    public override string ToString()
    {
        return _Sprite.ToString();
    }



}
