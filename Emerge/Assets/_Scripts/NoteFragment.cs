using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteFragment : CarryableObject
{
    public int orderInReceipe;


    new private void Start()
    {
        base.Start();
        Debug.Log("note frag start");
    }
}
