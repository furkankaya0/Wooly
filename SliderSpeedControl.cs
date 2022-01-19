using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSpeedControl : MonoBehaviour
{

    public static Slider SpeedSlider1;
    public static float Speed;

    // Start is called before the first frame update
    static void Start()
    {
        //SpeedSlider1.onValueChanged.AddListener(delegate { SpeedChange(); });
        //FixedUpddate();
    }
    static void FixedUpddate()
    {
        //Time.fixedDeltaTime = 0.03f* SpeedSlider1.value;
        //Debug.Log(Time.fixedDeltaTime);

    }
    void update()
    {
        //Time.fixedDeltaTime =Speed*30;
        //Debug.Log(Time.fixedDeltaTime);
    }


}
