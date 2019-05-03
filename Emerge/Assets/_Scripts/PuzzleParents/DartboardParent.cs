using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartboardParent : PuzzleParent
{
    public override bool IsPuzzleDone()
    {
        Debug.Log("Dartboard Parent");
        return false;
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
