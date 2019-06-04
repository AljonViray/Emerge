using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    private GameObject[] myMenuUI;
    private GameObject myCredits;
    private GameObject myBackButton;
    // Start is called before the first frame update
    void Start()
    {
        myMenuUI = new GameObject[4];
        for (int i = 0; i < 4; ++i)
        {
            myMenuUI[i] = this.transform.GetChild(i+1).gameObject;
        }
        myCredits = this.transform.GetChild(5).gameObject;
        myBackButton = this.transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewCredits()
    {
        for (int i = 0; i < 4; ++i)
        {
            myMenuUI[i].SetActive(false);
        }
        myCredits.SetActive(true);
        myBackButton.SetActive(true);
    }

    public void CloseCredits()
    {
        for (int i = 0; i < 4; ++i)
        {
            myMenuUI[i].SetActive(true);
        }
        myCredits.SetActive(false);
        myBackButton.SetActive(false);
    }
}
