using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public string[] hints;
    public PuzzleParent[] puzzleParents;
    public int currentPuzzle;
    public float timeRemaining;

    void Start()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
            Debug.Log("GAME OVER");
        }
        this.GetComponentInChildren<TextMeshProUGUI>().text = (timeRemaining/60f).ToString("0.00");
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
