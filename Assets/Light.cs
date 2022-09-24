using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    /*public int sun;
    public int night;
    
    public int sky;*/
    public Clock clock;

    public bool bright;
    public bool dark;
    
    void Start()
    {
        
        if (clock.hour >= 12)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x + 210f, transform.rotation.y, transform.rotation.z);
            dark = true;
        }

        if (clock.hour < 12)
        {
            bright = true;
        }
    }

    // Update is called once per frame
    void Update()
    {


        
    }

}
