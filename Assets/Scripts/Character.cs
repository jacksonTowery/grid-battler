using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character: MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] private int atk;
    [SerializeField] private int def;
    [SerializeField] private int mRange;
    [SerializeField] private int aRange;
    //[SerializeField] private GameObject selectionPrefab;
    //private GameObject newSelection;
    private int health = 100;
    private bool attacked=false;
    private bool moved=false;
    private bool usedAbillity = false;
    public bool isSelected;
    public bool owner;

    public int getmRange()
    {
        return mRange;
    }
    public int getaRange() 
    {
        return aRange;
    }
    public int getAtk()
    {
        return atk;
    }
    public void setAtk(int a)
    {
        atk = a;
    }
    public void setDef(int d)
    {
        def = d;
    }
    public void setmRange(int m)
    {
        mRange = m;
    }
    public void setaRange(int m)
    {
        aRange = m;
    }
    public int getHealth()
    {
        return health;
    }
    public bool getMoved()
    {
       return moved;
    }

    public void Moved()
    {
        moved = true;
    }
    public void attack()
    {
        attacked = true;
    }
    public bool getAttack()
    {
        return attacked;
    }
    public bool getIsOwner()
    {
        return owner;
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
    public void takeDammage(int power)
    {
        health -= power*25 / def;
        if(health <= 0)
        {
            defeated();
        }
    }
    private void defeated()
    {
        Destroy(gameObject);
    }
    public void resetBools() 
    {
        attacked = false;
        moved = false;
        usedAbillity = false;
    }
    public void change()
    {
        owner = !owner;
    }


    /*private void OnMouseDown()
    {
        if (newSelection==null)
        {
            newSelection = Instantiate(selectionPrefab, transform.position,Quaternion.identity);
            newSelection.transform.SetParent(gameObject.transform);
            newSelection.SetActive(false);
        }

        isSelected=!isSelected;

        if(isSelected)
        {
            newSelection.SetActive(true);
        }
        else
        {
            newSelection.SetActive(false);
        }
    }*/




}
