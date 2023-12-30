using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("MENUS")]
    [Tooltip("The Menu for when the MAIN menu buttons")]
    public GameObject mainMenu;
    [Tooltip("THe first list of buttons")]
    public GameObject firstMenu;
    [Tooltip("The Menu for when the EXIT button is clicked")]
    public GameObject exitMenu;
    [Tooltip("The Menu for when the SETTINGS button is clicked")]
    public GameObject settingsMenu;



    public void PlayGame(){
        FindObjectOfType<GameManager>().CompleteLevel();
    }

    public void AreYouSure(){
        mainMenu.SetActive(false);
        exitMenu.SetActive(true);		
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturnMenu(){
        exitMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SettingsMenu(){
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ReturnSettings(){
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
