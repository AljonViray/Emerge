using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFragment : CarryableObject
{
    public int orderInReceipe;
    // Start is called before the first frame update
    new private void Start()
    {
        base.Start();
        Debug.Log("note frag start");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
