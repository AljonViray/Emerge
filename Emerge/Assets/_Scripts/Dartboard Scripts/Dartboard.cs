using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    public GameObject player;
    public GameObject resetButton;
    public GameObject noteFragment;
    public GameObject dartsParent;
    public List<string> attempt = new List<string>();
    public List<string> solution;
    public bool isSolved = false;

    private List<GameObject> darts = new List<GameObject>();


    // Main Functions //
    private void Start()
    {
        solution = new List<string> { "Ring1", "Ring3", "Bullseye" };
        foreach (Transform child in dartsParent.transform)
            darts.Add(child.gameObject);
    }

    private void Update()
    {
        if (attempt.Count >= 3 && isSolved == false)
            CheckSolution();
        if (player.GetComponent<PlayerInteraction>().LookingAt() == resetButton && Input.GetKeyDown(KeyCode.E))
        {
            resetButton.transform.GetChild(0).GetComponent<AudioSource>().Play();
            Reset();
        }
    }


    // Helper Functions //
    public void Reset()
    {
        Debug.Log("Resetting Darts...");
        attempt.Clear();
        for (int i = 0; i < darts.Count; i++)
        {
            darts[i].GetComponent<Rigidbody>().isKinematic = false;
            darts[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            darts[i].gameObject.transform.SetPositionAndRotation(darts[i].GetComponent<ResetObjects>().originalPosition,
                                                                 darts[i].GetComponent<ResetObjects>().originalRotation);
        }
    }

    private void CheckSolution()
    {
        // Checking is it fails
        for (int i = 0; i < solution.Count; i++)
            if (attempt.Contains(solution[i]) == false) return;

        // If successful, play animation and freeze dartboard/darts
        for (int i = 0; i < darts.Count; i++)
        {
            if (darts[i].GetComponent<Rigidbody>().isKinematic) // If darts on the board itself
                darts[i].transform.SetParent(this.gameObject.transform);
            else
                Destroy(darts[i]);
            darts[i].tag = "Untagged"; // Prevents darts from being picked up again
        }

        Debug.Log("Dartboard Minigame COMPLETE!");
        isSolved = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();
        transform.parent.GetComponent<Animator>().SetTrigger("isComplete");
        transform.parent.GetComponent<AudioSource>().Play();

        // "Spawn" the Note Fragment AND the Poster after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        GameObject poster = GameObject.Find("Poster");
        poster.GetComponent<Rigidbody>().isKinematic = false;
        poster.GetComponent<MeshRenderer>().enabled = true;
        poster.GetComponent<CapsuleCollider>().enabled = true;

        // Prevents script from running anymore
        Destroy(resetButton);
        GameObject.Find("Pressure Plate").GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Dartboard>().enabled = false;
    }
}
