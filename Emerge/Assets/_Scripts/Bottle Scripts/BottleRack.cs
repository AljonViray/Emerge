using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleRack : MonoBehaviour
{
    public GameObject player;
    public GameObject resetButton;
    public GameObject noteFragment;
    public AudioClip wallSplit;
    public List<Bottle.liquorType> attempt = new List<Bottle.liquorType>();
    public List<string> attemptSlots = new List<string>();
    public List<string> solution = new List<string>();
    public Bottle.liquorType[] correctPattern;
    public bool isSolved = false;

    private GameObject playerHeldObject;
    [SerializeField] private List<GameObject> bottles = new List<GameObject>();
    private List<GameObject> areas = new List<GameObject>();


    // Main Functions //
    private void Start()
    {
        GameObject bottlesParent = GameObject.Find("---Bottles---");
        foreach (Transform child in bottlesParent.transform)
            bottles.Add(child.gameObject);
        foreach (Transform child in this.transform)
            areas.Add(child.gameObject);
    }

    private void Update()
    {
        if (attempt.Count >= 6 && isSolved == false)
            CheckSolution();
        if (player.GetComponent<PlayerInteraction>().LookingAt(3) == resetButton && Input.GetKeyDown(KeyCode.E))
            Reset();
    }


    // Helper Functions //
    private void Reset()
    {
        Debug.Log("Resetting Bottles...");
        resetButton.transform.GetChild(0).GetComponent<AudioSource>().Play();
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
            area.GetComponent<InnerBottleRack>().typeHeld = Bottle.liquorType.Empty;
        }
    }


    void CheckSolution()
    {
        Debug.Log("Checking Solution of Bottles...");
        // Checking is it fails
        for (int i = 0; i < solution.Count; i++)
        {
            if ( ! (correctPattern[i] == this.transform.GetChild(i).gameObject.GetComponent<InnerBottleRack>().typeHeld))
            {
                return;
            }
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
        GameObject.Find("RusticTower").GetComponent<Animator>().SetTrigger("isComplete");
        GameObject.Find("SecretWall_1").GetComponent<Animator>().SetTrigger("isComplete");
        GameObject.Find("SecretWall_2").GetComponent<Animator>().SetTrigger("isComplete");
        GameObject.Find("~~~Level~~~").GetComponent<AudioSource>().PlayOneShot(wallSplit, 2);

        // Stop music and play the wall opening sound


        // Prevents script from running anymore
        Destroy(resetButton);
        this.GetComponent<BottleRack>().enabled = false;
    }
}