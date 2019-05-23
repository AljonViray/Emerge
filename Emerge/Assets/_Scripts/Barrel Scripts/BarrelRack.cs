using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRack : MonoBehaviour
{
    public GameObject player;
    public GameObject resetButton;
    public GameObject noteFragment;
    public List<string> attempt = new List<string>();
    public List<string> solution;
    public bool isSolved = false;

    private GameObject playerHeldObject;
    private List<GameObject> barrels;
    private List<GameObject> slots;


    // Main Functions //


    private void Start()
    {
        solution = new List<string> { "Slot_1", "Slot_2", "Slot_4", "Slot_5", "Slot_6" };
        barrels = new List<GameObject> { GameObject.Find("Barrel_1"), GameObject.Find("Barrel_2"), GameObject.Find("Barrel_3"),
                                         GameObject.Find("Barrel_4"), GameObject.Find("Barrel_5"), GameObject.Find("Barrel_6") };
        slots = new List<GameObject> { GameObject.Find("Slot_1"), GameObject.Find("Slot_2"), GameObject.Find("Slot_3"),
                                       GameObject.Find("Slot_4"), GameObject.Find("Slot_5"), GameObject.Find("Slot_6") };
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
    }


    void CheckSolution()
    {
        Debug.Log("Checking Solution of Barrels...");
        // Checking is it fails
        for (int i = 0; i < solution.Count; i++)
        {
            if (!solution.Contains(attempt[i])) return;
        }

        // If successful, play animation and freeze barrels (if it's on the rack)
        for (int i = 0; i < barrels.Count; i++)
        {
            if (barrels[i].GetComponent<Rigidbody>().isKinematic)
            {
                barrels[i].transform.SetParent(this.gameObject.transform);
                barrels[i].tag = "Untagged";
            }
        }
        // Also disable box colliders of areas
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].GetComponent<BoxCollider>().enabled = false;
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