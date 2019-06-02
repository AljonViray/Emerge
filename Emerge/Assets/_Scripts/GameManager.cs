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

        timeRemaininStr = ((timeRemaining - 60) / 60f).ToString("0");
        timeRemaininStr += ":";
        timeRemaininStr += (timeRemaining % 60).ToString("0");

        this.GetComponentInChildren<TextMeshProUGUI>().text = timeRemaininStr;


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
