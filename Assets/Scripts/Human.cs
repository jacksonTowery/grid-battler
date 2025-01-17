using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Character
{
    /* private int atk;
     private int def;
     private int mRange;
     private int aRange;
    //[SerializeField] private GameObject selectionPrefab;
    //private GameObject newSelection;
    private int health = 100;
    private bool attacked = false;
    private bool moved = false;
    private bool usedAbillity = false;
    public bool owner;*/
    // Start is called before the first frame update
    void Start()
    {
        setAtk(3);
        setDef(3);
        setmRange(4);
        setaRange(4);
        setactRange(4);
        setAbillity("boostA");
        setName("Astronaut");
        //Sprite sprite=Resources.Load("Human (2)",typeof(Sprite)) as Sprite;
       //Sprite sprite=Resources.Load("Assets/Sprites/Human (2)", typeof(Sprite)) as Sprite;
        //Sprite sprite = Resources.Load<Sprite>("Assets/Sprites/Human (2).png");
       // setSprite(sprite);
       // Debug.Log(sprite);
    }


}
