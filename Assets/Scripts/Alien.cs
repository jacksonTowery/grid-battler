using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : Character
{
    // Start is called before the first frame update
    void Start()
    {
        setAtk(3);
        setDef(3);
        setmRange(4);
        setaRange(4);
        setactRange(4);
        setAbillity("lowerA");
    }
}
