﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleParent : MonoBehaviour
{
    public bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PuzzleParent Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract bool IsPuzzleDone();
}
