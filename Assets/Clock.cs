using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    
    public GameObject display;
    public Set settings;


    void Awake()
    {
        settings.minute= System.DateTime.Now.Hour;

    }

    // Update is called once per frame
    void Update()
    {

        settings.hour = System.DateTime.Now.Hour;
        settings.minute = System.DateTime.Now.Minute;
        settings.seconds = System.DateTime.Now.Second;
        display.GetComponent<Text>().text = "" + settings.hour + ":" + settings.minute + ":" + settings.seconds;

        if (settings.hour < 12)
        {
            settings.bright = true;
        }

        if (settings.hour >= 12)
        {
            settings.dark = true;
        }
    }

}

