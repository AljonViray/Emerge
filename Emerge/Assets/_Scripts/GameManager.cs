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
    // Start is called before the first frame update
    void Start()
    {
        SetAllPuzzlesToUnsolved();
    }


    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
            Debug.Log("GAME OVER");
        }
        this.GetComponentInChildren<TextMeshProUGUI>().text = (timeRemaining/60f).ToString("0.00");
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
