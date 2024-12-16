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

    public bool getMoved()
    {
       return moved;
    }

    public void Moved()
    {
        moved = true;
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
