using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeathTop : MonoBehaviour
{
    float delay;
    float timer;
    float speed = 2;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        //Set the value of 'delay' to 10:
        delay = 25;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the value of 'timer' by deltaTime:
        timer += Time.deltaTime;


        //Verify if the timer is greater than delay:
        if (timer > delay)
        {

            //If so, proceed to translate the object:
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
