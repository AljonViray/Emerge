using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    public List<string> attempt = new List<string>();
    public GameObject player;
    public GameObject resetButton;
    public bool isSolved = false;

    private List<string> solution;
    private List<GameObject> darts;


    // Main Functions //


    private void Start()
    {
        player = GameObject.Find("Player");
        resetButton = GameObject.Find("Reset_Button_Dartboard");

        solution = new List<string> { "Ring1", "Ring3", "Bullseye" };
        darts = new List<GameObject> { GameObject.Find("Dart_1"), GameObject.Find("Dart_2"),
                                       GameObject.Find("Dart_3"), GameObject.Find("Dart_4"),
                                       GameObject.Find("Dart_5") };
    }


    private void Update()
    {
        if (attempt.Count >= 3 && isSolved == false) CheckSolution();
        if (player.GetComponent<PlayerInteraction>().lookingAt() == resetButton && Input.GetKeyDown(KeyCode.E)) Reset();
    }


    private void Reset()
    {
        Debug.Log("Resetting...");
        attempt.Clear();
        for (int i = 0; i < darts.Count; i++)
        {
            darts[i].GetComponent<Rigidbody>().isKinematic = false;
            darts[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            darts[i].gameObject.transform.SetPositionAndRotation(darts[i].GetComponent<Dart>().originalPosition,
                                                                 darts[i].GetComponent<Dart>().originalRotation);
        }
    }


    // Helper Functions //


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
        }
        Debug.Log("Dartboard Minigame COMPLETE!");
        isSolved = true;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();
    }
}
