using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    public GameObject player;
    public GameObject noteFragment;
    public List<GameObject> solution = new List<GameObject>();
    public bool isSolved = false;

    public GameObject absinthe;

    private GameObject lookingAt;
    public GameObject loreCard;


    // Main Functions //
    private void Start()
    {
        player = GameObject.Find("Player");
        foreach (Transform child in this.transform)
            if (child.name.Split(' ')[0] == "CorrectChange")
                solution.Add(child.gameObject);
    }

    private void Update()
    {
    }


    public void CheckSolution()
    {
        Debug.Log("CheckSolutionPhoto");
        // If successful, play animation and freeze paintings
        Debug.Log("Photo Minigame COMPLETE!");
        isSolved = true;
        //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();

        for (int i = 0; i < this.transform.childCount-1; i++)
            this.transform.GetChild(i).GetComponent<SphereCollider>().enabled = false;

        // "Spawn" the Note Fragment after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        noteFragment.GetComponent<Rigidbody>().isKinematic = false;

        loreCard.SetActive(true);

        // "Spawn" the bottles of Absinthe
        absinthe.SetActive(true);
        //GameObject absinthe = GameObject.Find("absinthe");
        //absinthe.GetComponent<MeshRenderer>().enabled = true;
        //absinthe.GetComponent<MeshCollider>().enabled = true;
        //absinthe.GetComponent<Rigidbody>().isKinematic = false;
        //absinthe.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        //absinthe.transform.GetChild(1).GetComponent<Canvas>().enabled = true;

        // Enable Reset_Bottles (was causing problems w/ resetting absinthe when it's not available)
        GameObject resetButton = GameObject.Find("Reset_Bottles");
        resetButton.GetComponent<BoxCollider>().enabled = true;
        resetButton.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;

        // Prevents script from running anymore
        this.GetComponent<Photo>().enabled = false;
    }
}
