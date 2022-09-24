using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{

    public GameObject display;
    public int hour;
    public int minute;
    public int seconds;

    
    void Awake()
    {
        hour = System.DateTime.Now.Hour;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        display.GetComponent<Text>().text = "" + hour + ":" + minute + ":" + seconds;
        
    }
}
