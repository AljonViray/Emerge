using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoParent : PuzzleParent
{
    public GameObject fakePhoto;
    public override bool IsPuzzleDone()
    {
        Debug.Log("Puzzle Parent");
        if(isDone)
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
        isDone = CheckCompletion();
        if(isDone && GameObject.Find("GameManager").GetComponent<GameManager>().currentPuzzle == 2)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PuzzleSolved();
        }
    }

    public bool CheckCompletion()
    {
        bool temp = true;
        PicturePossibleChange[] possChanges = GetComponentsInChildren<PicturePossibleChange>();
        foreach(PicturePossibleChange p in possChanges)
        {
            if(!(p.isSelected == p.realChange))
            {
                temp = false;
                break;
            }
            else
            {
                continue;
            }
        }
        return temp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Poster")
        {
            fakePhoto.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
