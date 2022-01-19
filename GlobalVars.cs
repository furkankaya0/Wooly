using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars
{
    public static GlobalVars _instance;
    
    public static GlobalVars Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalVars();
            }
            return _instance;
        }
    }
        public string PlayerName;
        public int PlayerScore;
}
