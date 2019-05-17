using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRack : MonoBehaviour
{
    public List<string> attempt = new List<string>();
    public List<string> solution;
    public GameObject resetButton;
    public GameObject noteFragment;
    public bool isSolved = false;

    private GameObject player;
    private GameObject playerHeldObject;
    private List<GameObject> barrels;
    private List<GameObject> racks;


    // Main Functions //


    private void Start()
    {
        player = GameObject.Find("Player");
        resetButton = GameObject.Find("Reset_Barrels");

        solution = new List<string> { "Position_1 (1)", "Position_1 (3)", "Position_2 (3)",
                                      "Position_2 (1)", "Position_1 (2)" };

        barrels = new List<GameObject> { GameObject.Find("Barrel_1"), GameObject.Find("Barrel_2"), GameObject.Find("Barrel_3"),
                                         GameObject.Find("Barrel_4"), GameObject.Find("Barrel_5"), GameObject.Find("Barrel_6") };
        racks = new List<GameObject> { GameObject.Find("Area_1"), GameObject.Find("Area_2"), GameObject.Find("Area_3") };
    }

    void Update()
    {
        if (attempt.Count >= 5 && isSolved == false) CheckSolution();
        if (player.GetComponent<PlayerInteraction>().lookingAt() == resetButton && Input.GetKeyDown(KeyCode.E)) Reset();
    }


    // Helper Functions //


    private void Reset()
    {
        Debug.Log("Resetting Barrels...");
        attempt.Clear();
        for (int i = 0; i < barrels.Count; i++)
        {
            barrels[i].GetComponent<Rigidbody>().isKinematic = false;
            barrels[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            barrels[i].gameObject.transform.SetPositionAndRotation(barrels[i].GetComponent<ResetObjects>().originalPosition,
                                                                   barrels[i].GetComponent<ResetObjects>().originalRotation);
        }
        for (int i = 0; i < racks.Count; i++)
        {
            racks[i].GetComponent<InnerBarrelRack>().bottomFilled = false;
            racks[i].GetComponent<InnerBarrelRack>().allFilled = false;
        }
    }


    void CheckSolution()
    {
        Debug.Log("Checking Solution of Barrels...");
        // Checking is it fails
        for (int i = 0; i < solution.Count; i++)
            if (!solution.Contains(attempt[i])) return;

        // If successful, play animation and freeze barrels (if it's on the rack)
        for (int i = 0; i < barrels.Count; i++)
        {
            if (barrels[i].GetComponent<Rigidbody>().isKinematic)
            {
                barrels[i].transform.SetParent(this.gameObject.transform);
                barrels[i].tag = "Untagged";
            }
        }
 
        Debug.Log("Barrel Minigame COMPLETE!");
        isSolved = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();

        // "Spawn" the Note Fragment after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        noteFragment.GetComponent<Rigidbody>().isKinematic = false;

        // Prevents script from running anymore
        Destroy(resetButton);
        this.gameObject.GetComponent<BarrelRack>().enabled = false;
    }



}