using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class CountdownToSuddenDeath : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 25f;
    private float Disappear = 25f;
    public Text SuddenDeathCountdown;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update ()
    {
        currentTime -= 1 * Time.deltaTime;
        SuddenDeathCountdown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
           currentTime = 0;
        }
           
        if (SuddenDeathCountdown.enabled && (Time.time >= Disappear))
        {
            SuddenDeathCountdown.enabled = false;
        }
        
    }
}