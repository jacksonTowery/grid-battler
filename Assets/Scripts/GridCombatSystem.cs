using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnitGridCombat unitGridCombat;
    // Update is called once per frame

    public void Start()
    {
        int moveDistance = 3;
        unitGridCombat.getPosition();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            unitGridCombat.moveTo(UtilsClass.GetMouseWorldPosition(),()=> { });
        }
    }
}
