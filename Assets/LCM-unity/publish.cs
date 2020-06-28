using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LCM;

public class publish : MonoBehaviour
{
	int t = 0;
    LCM.LCM.LCM myLCM;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("publish start"); 
        myLCM = new LCM.LCM.LCM();
    }

    // Update is called once per frame
    void Update()
    {
        t++;
        if (t > 60){
            exlcm.example_t msg = new exlcm.example_t();
            //Debug.Log("publish update");
            TimeSpan span = DateTime.Now - new DateTime(1970, 1, 1);
            msg.timestamp = span.Ticks * 100;
            msg.position = new double[] { 1, 2, 3 };
            msg.orientation = new double[] { 1, 0, 0, 0 };
            msg.num_ranges = 15;
            msg.ranges = new short[msg.num_ranges];
            for (int i = 0; i < msg.num_ranges; i++)
            {
                msg.ranges[i] = (short) i;
            }
            msg.name = "example string";
            msg.enabled = true;

            myLCM.Publish("EXAMPLE", msg); 
            t=0;
        } 
    }
}
