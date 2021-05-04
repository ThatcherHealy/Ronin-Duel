using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeathColorChange : MonoBehaviour
{
    float delay;
    float timer;
    public Color myColor;
    // Use this for initialization
    void Start()
    {
     bool myColor = false;
        //Set the value of 'delay' to 10:
        delay = 28;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the value of 'timer' by deltaTime:
        timer += Time.deltaTime;


        //Verify if the timer is greater than delay:
        if (timer > delay)
        {
       bool myColor = true;
        }
    }
}