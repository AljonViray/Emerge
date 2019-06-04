using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject player;
    public GameObject finalBottle;


    private void Start()
    {
        player = GameObject.Find("Player");
        finalBottle = GameObject.Find("final_bottle");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.transform.parent);
        if (other.transform.parent != null
            && other.transform.parent.gameObject == player 
            && player.GetComponent<PlayerInteraction>().heldObject == finalBottle)
        {
            GameObject.Find("SceneManagerObj").GetComponent<SceneManager>().LoadWin();
            //Debug.Log("WIN CONDITION MET, NEED END SCREEN");
        }
    }
}
