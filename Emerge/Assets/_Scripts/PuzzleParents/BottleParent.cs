using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleParent : PuzzleParent
{

    public override bool IsPuzzleDone()
    {
        Debug.Log("BottleParent Parent");
        if (isDone)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
