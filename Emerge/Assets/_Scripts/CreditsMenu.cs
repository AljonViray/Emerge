using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    private GameObject[] myMenuUI;
    private GameObject myCredits;
    private GameObject myControls;
    private GameObject myBackButton;
    // Start is called before the first frame update
    void Start()
    {
        myMenuUI = new GameObject[5];
        for (int i = 0; i < 5; ++i)
        {
            myMenuUI[i] = this.transform.GetChild(i+1).gameObject;
        }
        myCredits = this.transform.GetChild(6).gameObject;
        myControls = this.transform.GetChild(7).gameObject;
        myBackButton = this.transform.GetChild(8).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewCredits()
    {
        for (int i = 0; i < 5; ++i)
        {
            myMenuUI[i].SetActive(false);
        }
        myCredits.SetActive(true);
        myBackButton.SetActive(true);
    }

    public void ViewControls()
    {
        for (int i = 0; i < 5; ++i)
        {
            myMenuUI[i].SetActive(false);
        }
        myControls.SetActive(true);
        myBackButton.SetActive(true);
    }

    public void BackToMenu()
    {
        for (int i = 0; i < 5; ++i)
        {
            myMenuUI[i].SetActive(true);
        }
        myCredits.SetActive(false);
        myControls.SetActive(false);
        myBackButton.SetActive(false);
    }
}
