using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Grid<bool> grid = new Grid<bool>(11, 11, 10f, new Vector3(20,0));
    }

}
