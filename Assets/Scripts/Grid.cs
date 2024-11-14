using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grid<TGridObject>
{
    int width;
    int height;
    float cellsize;
    Vector3 originPosition;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugArray;
     public Grid(int width, int height, float cellsize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        this.originPosition = originPosition;
        gridArray = new TGridObject[width, height];
        debugArray = new TextMesh[width, height];

        for(int x=0; x<gridArray.GetLength(0); x++)
        {
            for(int y=0;  y<gridArray.GetLength(1); y++)
            {
                 debugArray[x,y]= CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y)+new Vector3(cellsize,cellsize)*.5f, 20, Color.white, TextAnchor.MiddleCenter);
                //CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellsize, cellsize) * .5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x+1, y), GetWorldPosition(x, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width,height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0), GetWorldPosition(width,height), Color.white, 100f);


    }

    public static TextMesh CreateWorldText(string text, Transform parent=null, Vector3 localPosition=default(Vector3),int fontsize=40, Color? color=null, TextAnchor textAnchor=TextAnchor.UpperLeft)
    {
        if(color==null) 
            color = Color.white;

        return CreateWorldText(parent, text, localPosition, fontsize, (Color)color, textAnchor, TextAlignment.Center, 20);
    }
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontsize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontsize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;

    }
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize+originPosition;
    }

    public void setValue(int x, int y, TGridObject value) {
        if(x>=0 && y>=0 && x<width && y<height)
        {
            gridArray[x,y] = value;
            debugArray[x, y].text = gridArray[x,y].ToString();
        }
    }

    public void setValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        setValue(x, y, value);
    }
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
      x=Mathf.FloorToInt((worldPosition-originPosition).x/cellsize);
        y=Mathf.FloorToInt((worldPosition-originPosition).y/cellsize);
    }

    public TGridObject getValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x,y];
        }
        else { return default(TGridObject); }
    }
    public TGridObject getValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return getValue(x, y);
    }
}
