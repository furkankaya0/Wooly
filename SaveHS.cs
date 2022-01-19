using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SaveHS : MonoBehaviour
{
    public Text nameText;
    public Text highScoreText;

    private  int highScore;
    private string PlayerName;

    public void saveAndReturn()
    {
        //highScore = int.Parse(highScoreText.text);
        PlayerName = nameText.text;
        highScore = int.Parse(highScoreText.text);
        Debug.Log(PlayerName);


        GlobalVars.Instance.PlayerName = PlayerName;
        GlobalVars.Instance.PlayerScore = highScore;

        //SceneManager.LoadScene(0);


    }
}
