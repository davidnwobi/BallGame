using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    [SerializeField]
    private LevelLoader levelLoader;
    public void CompleteLevel()
    {
        gameHasEnded = true;
        levelLoader.LoadNextLevel();
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
        
    }
    void Restart()
    {
        levelLoader.RestartLevel();
    }


}
