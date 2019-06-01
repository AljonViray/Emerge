using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    public GameObject player;
    public GameObject noteFragment;
    public List<GameObject> solution = new List<GameObject>();
    public bool isSolved = false;

    private GameObject lookingAt;


    // Main Functions //
    private void Start()
    {
        player = GameObject.Find("Player");
        GameObject photoParent = GameObject.Find("FakePhoto");
        foreach (Transform child in photoParent.transform)
            solution.Add(child.gameObject);
    }

    private void Update()
    {
        if (solution.Count == 0)
            CheckSolution();

        lookingAt = player.GetComponent<PlayerInteraction>().LookingAt();
        if (lookingAt != null && Input.GetKeyDown(KeyCode.E))
        {
            if (solution.Contains(lookingAt))
            {
                lookingAt.GetComponent<MeshRenderer>().enabled = true;
                lookingAt.GetComponent<SphereCollider>().enabled = false;
                solution.Remove(lookingAt);
            }
        }
    }


    private void CheckSolution()
    {
        // If successful, play animation and freeze paintings
        Debug.Log("Photo Minigame COMPLETE!");
        isSolved = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();

        // "Spawn" the Note Fragment after winning
        noteFragment.transform.GetChild(0).gameObject.SetActive(true);
        noteFragment.GetComponent<Rigidbody>().isKinematic = false;

        // Prevents script from running anymore
        this.GetComponent<Photo>().enabled = false;
    }
}
