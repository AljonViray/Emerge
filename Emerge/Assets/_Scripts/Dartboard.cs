using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    public List<string> attempt = new List<string>();

    [SerializeField] private List<string> solution;
    [SerializeField] private List<GameObject> darts;


    // Main Functions //


    private void Start()
    {
        solution = new List<string> { "Ring1", "Ring3", "Bullseye" };
        darts = new List<GameObject> { GameObject.Find("Dart_1"), GameObject.Find("Dart_2"),
                                       GameObject.Find("Dart_3"), GameObject.Find("Dart_4"),
                                       GameObject.Find("Dart_5") };
    }


    private void Update()
    {
        if (attempt.Count >= 3) CheckSolution();
        if (Input.GetKeyDown(KeyCode.R)) Reset();
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
        for (int i = 0; i < solution.Count; i++)
        {
            if (attempt.Contains(solution[i]) == false)
            {
                Debug.Log("Incorrect Combination! Press 'R' to Reset");
                return;
            }
        }

        // If successful, destroy all dartboard-related objects
        Destroy(GameObject.Find("Dartboard"));
        for (int i = 0; i < darts.Count; i++) Destroy(darts[i]);
        Debug.Log("Attempt Successful!");
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PuzzleSolved();
    }
}
