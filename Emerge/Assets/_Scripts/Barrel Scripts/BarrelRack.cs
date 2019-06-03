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
    private List<GameObject> barrels = new List<GameObject>();
    private List<GameObject> slots;


    // Main Functions //
    private void Start()
    {
        solution = new List<string> { "Slot_1", "Slot_4", "Slot_5", "Slot_6" };
        GameObject barrelsParent = GameObject.Find("---Barrels---");
        foreach (Transform child in barrelsParent.transform)
            barrels.Add(child.gameObject);
        slots = new List<GameObject> { GameObject.Find("Slot_1"), GameObject.Find("Slot_2"), GameObject.Find("Slot_3"),
                                       GameObject.Find("Slot_4"), GameObject.Find("Slot_5"), GameObject.Find("Slot_6") };
    }

    void Update()
    {
        if (attempt.Count >= 4 && isSolved == false)
            CheckSolution();
        if (player.GetComponent<PlayerInteraction>().LookingAt() == resetButton && Input.GetKeyDown(KeyCode.E))
            Reset();
    }


    // Helper Functions //
    private void Reset()
    {
        Debug.Log("Resetting Barrels...");
        resetButton.transform.GetChild(0).GetComponent<AudioSource>().Play();
        attempt.Clear();
        for (int i = 0; i < barrels.Count; i++)
        {
            barrels[i].gameObject.transform.SetPositionAndRotation(barrels[i].GetComponent<ResetObjects>().originalPosition,
                                                                   barrels[i].GetComponent<ResetObjects>().originalRotation);
            barrels[i].GetComponent<Rigidbody>().isKinematic = false;
            barrels[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].GetComponent<InnerBarrelRack>().filled = false;
        }
    }


    private void CheckSolution()
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
                barrels[i].transform.SetParent(this.transform);
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

        // "Spawn" the Note Fragment AND Dart_3 after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        noteFragment.GetComponent<Rigidbody>().isKinematic = false;

        GameObject dart_3 = GameObject.Find("Dart_3");
        dart_3.GetComponent<Rigidbody>().isKinematic = false;
        dart_3.transform.GetChild(0).gameObject.SetActive(true);
        dart_3.transform.GetChild(1).gameObject.SetActive(true);

        // Enable Reset_Darts and the pressure plate
        GameObject resetDarts = GameObject.Find("Reset_Darts");
        resetDarts.GetComponent<BoxCollider>().enabled = true;
        resetDarts.transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
        GameObject.Find("Pressure Plate").GetComponent<BoxCollider>().enabled = true;

        // Prevents script from running anymore
        Destroy(resetButton);
        this.GetComponent<BarrelRack>().enabled = false;
    }
}