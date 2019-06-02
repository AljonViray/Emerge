using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBottle : MonoBehaviour
{
    GameObject player;
    GameObject lookingAt;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        lookingAt = player.GetComponent<PlayerInteraction>().LookingAt();
        if (lookingAt != null)
        {
            if (lookingAt.name == "final_bottle")
                Debug.Log("YOU WIN!!!");
                //need the win screen to show here
        }
    }
}
