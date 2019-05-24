using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRack : MonoBehaviour
{
    public GameObject player;
    public GameObject resetButton;
    public GameObject noteFragment;
    public List<string> attempt = new List<string>();
    public List<string> solution;
    public bool isSolved = false;

    private GameObject playerHeldObject;
    public List<GameObject> bottles;
    public List<GameObject> areas;


    // Main Functions //
    private void Start()
    {
        solution = new List<string> { "whiskey", "gin", "vodka", "rum", "tequila", "absinthe" };

        GameObject bottlesParent = GameObject.Find("---Bottles---");
        foreach (Transform child in bottlesParent.transform)
            bottles.Add(child.gameObject);
        foreach (Transform child in this.transform)
            areas.Add(child.gameObject);
    }

    void Update()
    {
        if (attempt.Count >= 6 && isSolved == false) CheckSolution();
        if (player.GetComponent<PlayerInteraction>().lookingAt() == resetButton && Input.GetKeyDown(KeyCode.E)) Reset();
    }


    // Helper Functions //
    private void Reset()
    {
        Debug.Log("Resetting Bottles...");
        attempt.Clear();
        for (int i = 0; i < bottles.Count; i++)
        {
            bottles[i].GetComponent<Rigidbody>().isKinematic = false;
            bottles[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            bottles[i].gameObject.transform.SetPositionAndRotation(bottles[i].GetComponent<ResetObjects>().originalPosition,
                                                                   bottles[i].GetComponent<ResetObjects>().originalRotation);
        }
        foreach (GameObject area in areas)
        {
            area.GetComponent<InnerBottleRack>().filled = false;
        }
    }


    void CheckSolution()
    {
        Debug.Log("Checking Solution of Bottles...");
        // Checking is it fails
        for (int i = 0; i < solution.Count; i++)
        {
            if (!solution.Contains(attempt[i])) return;
        }

        // If successful, freeze bottles (if it's on the rack)
        for (int i = 0; i < bottles.Count; i++)
        {
            if (bottles[i].GetComponent<Rigidbody>().isKinematic)
                bottles[i].tag = "Untagged";
        }
        // Also disable box colliders of areas
        for (int i = 0; i < areas.Count; i++)
        {
            areas[i].GetComponent<BoxCollider>().enabled = false;
        }
 
        Debug.Log("Bottle Minigame COMPLETE!");
        isSolved = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();

        // "Spawn" the Note Fragment after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        noteFragment.GetComponent<Rigidbody>().isKinematic = false;

        // Prevents script from running anymore
        Destroy(resetButton);
        this.gameObject.GetComponent<BottleRack>().enabled = false;
    }
}