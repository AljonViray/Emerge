using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void InteractWhenNotHeld()
    {
        _player.GetComponent<PlayerInteraction>().PickupObject(this.gameObject);
    }

    public virtual void InteractWhenHeld()
    {
        _player.GetComponent<PlayerInteraction>().ReleaseCurrentlyHeldObject();
    }
}
