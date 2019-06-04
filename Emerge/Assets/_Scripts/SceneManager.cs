using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public string mainGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainGame);
    }

    public void LoadGameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game Over");
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }

    public void LoadWin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
    }
}
