using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowHS : MonoBehaviour
{

    private int highScore;
    private string PlayerName;

    public Text ShowHStext;
    // Start is called before the first frame update
     void Start()
     {
        Debug.Log("SCENE START" + GlobalVars.Instance.PlayerName);
        PlayerName = GlobalVars.Instance.PlayerName;
        highScore = GlobalVars.Instance.PlayerScore;
        string MessageHs =PlayerName + "      " + highScore;
        ShowHStext.text = MessageHs;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
