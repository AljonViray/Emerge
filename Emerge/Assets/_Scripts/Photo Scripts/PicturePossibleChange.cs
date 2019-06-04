using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturePossibleChange : InteractableObject
{
    public bool realChange;

    public bool isSelected;

    public bool isLookedAt;

    public Material noMat;
    public Material selectedMat;
    public Material lookedMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isLookedAt)
        {
            this.GetComponent<MeshRenderer>().material = lookedMat;
        }
        else
        {
            if(isSelected)
            {
                this.GetComponent<MeshRenderer>().material = selectedMat;

            }
            else
            {
                this.GetComponent<MeshRenderer>().material = noMat;

            }
        }

        isLookedAt = false;


    }

    public void BeingLookedAt()
    {
        isLookedAt = true;
        
    }

    public void BeingSelected()
    {
        isSelected = !isSelected;
    }

}
