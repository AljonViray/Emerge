using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dartboard : MonoBehaviour
{
    public List<string> attempt = new List<string>();
    public List<GameObject> darts = new List<GameObject>();

    private List<string> solution;


    // Main Functions //


    private void Start()
    {
        solution = new List<string> { "Ring1", "Bullseye", "Ring3" };
    }

    private void Update()
    {
        if (attempt.Count == 5) CheckSolution();
        else if (Input.GetKeyDown(KeyCode.R)) Reset();
    }

    private void Reset()
    {
        Debug.Log("Attempt failed! Resetting...");
        attempt.Clear();

        for (int i = 0; i < darts.Count; i++)
        {
            darts[i].GetComponent<Rigidbody>().isKinematic = false;
            darts[i].gameObject.transform.SetPositionAndRotation
                (darts[i].GetComponent<Dart>().originalPosition,
                 darts[i].GetComponent<Dart>().originalRotation);
        }
        darts.Clear();
    }


    // Helper Functions //

    private bool CheckSolution()
    {
        for (int i = 0; i < solution.Count; i++)
        {
            if (solution[i] != attempt[i])
            {
                Reset();
                return false;
            }
        }
        Destroy(GameObject.Find("Dartboard"));
        return true;
    }
}
