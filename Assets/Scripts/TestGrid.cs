using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private PathFinding pathFinding;
    [SerializeField] private CharacterPathfinding characterPathfinding;
    public int range = 4;
    // [SerializeField] public Camera camera;
   // [SerializeField] public Component.camera camera;
    void Start()
    {
        //  Grid<bool> grid = new Grid<bool>(11, 11, 10f, new Vector3(20,0), ()=> new bool());
        pathFinding = new PathFinding(11, 11);
    }

    public void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("good");
          //  Console.Write("good");
            // Vector3 mouseWorldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            //mouseWorldPosition.z = 0f;
            //  Debug.Log(UtilsClass.GetMouseWorldPosition());
             pathFinding.getGrid().GetXY(mouseWorldPosition, out int xEnd, out int yEnd);
             pathFinding.getGrid().GetXY(characterPathfinding.transform.position, out int xStart, out int yStart);

            // List<PathNode> path = pathFinding.FindPath(0, 0, xEnd, yEnd); 
            List<PathNode> path = pathFinding.FindPath(xStart, yStart, xEnd, yEnd);
            //PathNode end= new PathNode(xEnd, yEnd);
            //List<PathNode> path = pathFinding.calculatePath(end);
          //int pathSize= pathFinding.FindPath(xStart, yStart, xEnd, yEnd);
            //characterPathfinding.setTargetPosition(mouseWorldPosition);
            /* if (path != null)
             {
                 for (int i = 1; i < path.Count - 1; i++)
                 {
                                Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
                   // characterPathfinding.movementHandler();
                   //pathFinding.getGrid().GetXY(mouseWorldPosition, out x, out y);
                   //characterPathfinding.transform.position = pathFinding.getGrid().GetWorldPosition((x/5)*5,(y/5)*5);
                 }
             }*/
            //String a=mouseWorldPosition.ToString();
            // Debug.Log(a);!!!!!!!!!!!!!!!!!!
            //   characterPathfinding.setTargetPosition(mouseWorldPosition);!!!!!!!!!!
            // pathFinding.getGrid().GetXY(mouseWorldPosition, out x, out y);
            /*pathFinding.getGrid().GetXY(mouseWorldPosition, out int unitX, out int unitY);

               for (int xV=unitX-range; xV<=unitX+range; xV++)
               {
                   for(int yV=unitY-range; yV<=unitY+range;yV++)
                   {
                       if (path.Count <= range)
                       {
                           characterPathfinding.transform.position = pathFinding.getGrid().GetWorldPosition(xEnd, yEnd) + new Vector3(5, 5);
                       }
                       else
                       {
                           Debug.Log("Out of Range");
                       }
                   }
               }*/

            if (path.Count <= range)
            {
                characterPathfinding.transform.position = pathFinding.getGrid().GetWorldPosition(xEnd, yEnd) + new Vector3(5, 5);
            }
            else
            {
                Debug.Log("Out of Range "+path.Count);
            }


            // characterPathfinding.transform.position = pathFinding.getGrid().GetWorldPosition(x,y)+new Vector3(5,5);


            //characterPathfinding.transform.position = mouseWorldPosition;
            /*while(characterPathfinding.transform.position!=mouseWorldPosition)
            {
                characterPathfinding.movementHandler();
            }*/
            //  characterPathfinding.movementHandler();
            //  characterPathfinding.changePosition(mouseWorldPosition);
            /*  for (int i = 1; i < path.Count - 1; i++)
              {
                  //Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green);
                   characterPathfinding.movementHandler();
              }*/
            //  Vector3 pos=pathFinding.getGrid().GetWorldPosition((int)mouseWorldPosition.x, (int)mouseWorldPosition.y);
            //  characterPathfinding.transform.position = pos;
        }
    }
}
