using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TestGrid : MonoBehaviour
{
    // Start is called before the first frame update
    private PathFinding pathFinding;
    //[SerializeField] private CharacterPathfinding characterPathfinding;
    [SerializeField] private Character characterA;
    [SerializeField] private Character characterB;
    [SerializeField] private Character characterC;
    [SerializeField] private Character characterD;
    [SerializeField] private Character characterE;
    [SerializeField] private Character characterF;
    //[SerializeField] private List<Character> characters;
    private Character character;
    private Character targetedCharacter;
    private List<Character> characters;
    bool attack;
    bool move;
    bool act;
    // [SerializeField] public Camera camera;
   // [SerializeField] public Component.camera camera;
    void Start()
    {
        //  Grid<bool> grid = new Grid<bool>(11, 11, 10f, new Vector3(20,0), ()=> new bool());
        pathFinding = new PathFinding(11, 11);
         characters = new List<Character>();
         characters.Add(characterA);
         characters.Add(characterB);
         characters.Add(characterC);
         characters.Add(characterD);
         characters.Add(characterE);
         characters.Add(characterF);
        changeCharacter(characterA);
        changeTargetedCharacter(characterE);
    }
    public void changeCharacter(Character character)
    {
        if(characters.Contains(character))
        {
            this.character = character;
        }
    }
    public void changeTargetedCharacter(Character tarCharacter)
    {
        if (characters.Contains(tarCharacter))
        {
            this.targetedCharacter = tarCharacter;
        }
    }
    public bool containsCharacter(Vector3 position)
    {
        pathFinding.getGrid().GetXY(position, out int xEnd, out int yEnd);
        Vector3 gridPosition=new Vector3(xEnd, yEnd);
        Vector3 characterPosition;
        foreach (Character characterPos in characters)
        {
            pathFinding.getGrid().GetXY(characterPos.transform.position, out int xChar, out int yChar);
            characterPosition = new Vector3(xChar, yChar);
            Debug.Log("Clicked: " + gridPosition + ", Character: " + characterPos.transform.position);
            if (characterPosition==gridPosition)
            {
                return true;
            }
        }
        return false;
    }
    public Character GetCharacter(Vector3 pos)
    {
        pathFinding.getGrid().GetXY(pos, out int xEnd, out int yEnd);
        Vector3 gridPosition = new Vector3(xEnd, yEnd);
        Vector3 characterPosition;
        foreach (Character characterPos in characters)
        {
            pathFinding.getGrid().GetXY(characterPos.transform.position, out int xChar, out int yChar);
            characterPosition = new Vector3(xChar, yChar);
            Debug.Log("Clicked: " + gridPosition + ", Character: " + characterPos.transform.position);
            if (characterPosition == gridPosition)
            {
                return characterPos;
            }
        }
        return null;

    }
    public void attackTrue()
    {
        attack = true;
        move = false;
        act = false;
    }
    public void moveTrue() 
    {
        attack=false;
        move = true;
        act = false;
    }
    public void actTrue() 
    {
        attack = false;
        move = false;
        act = true;
    }
    public void Update()
    {
       /* if(Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            if (containsCharacter(mouseWorldPosition))
            {
                changeTargetedCharacter(GetCharacter(mouseWorldPosition));
                Debug.Log("target");
            }
        }
        else*/ if (Input.GetMouseButtonDown(0))
        {
            
           // Debug.Log("good");
          //  Console.Write("good");
            // Vector3 mouseWorldPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            //mouseWorldPosition.z = 0f;
            //  Debug.Log(UtilsClass.GetMouseWorldPosition());
            if (containsCharacter(mouseWorldPosition))
            {
                changeCharacter(GetCharacter(mouseWorldPosition));
            }
            else if(attack)
            {
                pathFinding.getGrid().GetXY(mouseWorldPosition, out int xEnd, out int yEnd);
                pathFinding.getGrid().GetXY(character.getPosition(), out int xStart, out int yStart);

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

                if (path.Count <= character.getmRange())
                {
                    character.SetPosition(pathFinding.getGrid().GetWorldPosition(xEnd, yEnd) + new Vector3(5, 5));
                }
                else
                {
                    Debug.Log("Out of Range ");
                }
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
