using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] hints;
    public PuzzleParent[] puzzleParents;
    public int currentPuzzle;
    // Start is called before the first frame update
    void Start()
    {
        SetAllPuzzlesToUnsolved();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetAllPuzzlesToUnsolved()
    {
        foreach(PuzzleParent p in puzzleParents)
        {
            p.isDone = false;
        }
    }

    public void PuzzleSolved()
    {
        puzzleParents[currentPuzzle].isDone = true;
        ++currentPuzzle;
    }

    public string GetCurrentHint()
    {
        return hints[currentPuzzle];
    }
}
