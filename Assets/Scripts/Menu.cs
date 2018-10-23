using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject HelpMenu;
    
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;

        HelpMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Replay();
    }

    public void StartButton()
    {
        StartMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HardModeButton()
    {
        StartMenu.SetActive(false);
        Time.timeScale = 1.75f;
    }

    public void HelpButton()
    {
        StartMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void BackButton()
    {
        StartMenu.SetActive(true);
        HelpMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
