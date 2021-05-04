using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class SUDDENDEATHAPPEARS : MonoBehaviour
{
    float AppearOne = 25;
    float DisappearTwo = 28;
    float delay;
    float timer;
    public Transform target;
    public Text SUDDENDEATHTEXT;

    // Use this for initialization
    void Start()
    {
        //Set the value of 'delay' to 00:
        delay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the value of 'timer' by deltaTime:
        timer += Time.deltaTime;


        //Verify if the timer is greater than delay:
        if (timer > delay)
        {
            SUDDENDEATHTEXT.enabled = false;
        }
        if (timer > AppearOne)
        {
            SUDDENDEATHTEXT.enabled = true;
        }
        if (timer > DisappearTwo)
        {
            SUDDENDEATHTEXT.enabled = false;
        }
    
    }  
}
 