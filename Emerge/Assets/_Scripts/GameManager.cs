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

    string timeRemaininStr;

    void Start()
    {
        SetAllPuzzlesToUnsolved();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            Debug.Log("GAME OVER");
        }
        string minutes = ((int)(timeRemaining / 60f)).ToString("0");
        string seconds;
        if (timeRemaining % 60 < 10f)
        {
            seconds = "0" + (timeRemaining % 60).ToString("0");
        }
        else
        {
            seconds = (timeRemaining % 60).ToString("0");
        }
        timeRemaininStr = minutes + ":" + seconds;
        this.GetComponentInChildren<TextMeshProUGUI>().text = timeRemaininStr;


    }

    private void SetAllPuzzlesToUnsolved()
    {
        foreach(PuzzleParent p in puzzleParents)
        {
            if (p != null)
                p.isDone = false;
        }
    }

    public void PuzzleSolved()
    {
        if (puzzleParents[currentPuzzle] != null)
            puzzleParents[currentPuzzle].isDone = true;
        ++currentPuzzle;
    }

    public string GetCurrentHint()
    {
        return hints[currentPuzzle];
    }
}
