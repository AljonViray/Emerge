using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photo : MonoBehaviour
{
    public GameObject player;
    public List<string> solution;
    public GameObject lookingAt;
    public bool isSolved = false;


    void Start()
    {
        player = GameObject.Find("Player");
        solution = new List<string> { "Position_1", "Position_2", "Position_3",
                                      "Position_4", "Position_5" };
    }

    void Update()
    {
        lookingAt = player.GetComponent<PlayerInteraction>().LookingAt();
        if (lookingAt != null && Input.GetKeyDown(KeyCode.E))
        {
            if (solution.Contains(lookingAt.name))
            {
                lookingAt.GetComponent<MeshRenderer>().enabled = true;
                solution.Remove(lookingAt.name);
            }

            if (solution.Count == 0)
            {
                isSolved = true;
                this.gameObject.GetComponent<Photo>().enabled = false;
            }
        }
    }
}
