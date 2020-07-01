using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LCM;
//using csharp;
//using c_test_lcm;

public class body_move : MonoBehaviour
{
    public static float[] body_pos = new float[3];
    public static float test_x;
    public static float test_y, test_z;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Listener");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(body_pos[0], body_pos[1], body_pos[2]);
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    internal class SimpleSubscriber : LCM.LCM.LCMSubscriber
    {

        private int seq = 0;

        public void MessageReceived(LCM.LCM.LCM lcm, string channel, LCM.LCM.LCMDataInputStream dins)
        {
            Debug.Log ("RECV: " + channel);
            if (channel == "body_move")
            {
                LCMTypes.c_test_lcmt msg = new LCMTypes.c_test_lcmt(dins);
                String message = "CLCM Received message of the type c_test_lcmt:\n ";
                message+=String.Format("  position    = ({0:N}, {1:N}, {2:N})\n ",
                        msg.body_pos[0], msg.body_pos[1], msg.body_pos[2]);
                message+=String.Format("  orientation = ({0:N}, {1:N}, {2:N})\n",
                        msg.body_ori[0], msg.body_ori[1], msg.body_ori[2]);
                message+=(" ]\n");
                Debug.Log (message);

                for(int i = 0; i<3; ++i)
                {
                    body_pos[i] = msg.body_pos[i];
                }
                //test_x = msg.body_pos[0];

            }
        }
    }
    Boolean running = false;
    LCM.LCM.LCM myLCM = null;

    public IEnumerator Listener()
    {
        Debug.Log ("Listener started.");
        myLCM = new LCM.LCM.LCM();

        myLCM.SubscribeAll(new SimpleSubscriber());
        running = true;
        while (running){
            yield return null;
        }
        Debug.Log ("listener coroutine returning!");
    }

}
