using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] hints;
    public PuzzleParent[] puzzleParents;
    public int currentPuzzle;


    void Start()
    {
        SetAllPuzzlesToUnsolved();
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
