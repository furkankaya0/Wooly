using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    static float speed;
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
        if (speed >= 1)
        {
            Time.timeScale = speed;
        }else
        {
            Time.timeScale = 1;
        }
        
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void TurnMainMenu2()
    {
        SceneManager.LoadScene(0);
    }
    static void AdjustSpeed(float MenuSpeed)
    {
        speed = MenuSpeed;

    }
}
