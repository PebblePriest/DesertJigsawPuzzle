using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 30f;
    public Text Successful;
    public bool isTurnedOn;
    public int count;
    public GameObject reminder;
    public float reminderCounter = 15f;
    
    public bool startTimer;

   
    public bool reminderBool;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        reminderCounter = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isTurnedOn == true)
        {
            Debug.Log("Got here");
            count += 1;
            if (count >= 2000)
            {
                Debug.Log("Deactivate");
                Successful.gameObject.SetActive(false);
                isTurnedOn = false;
            }
        }
        else
        {
            count = 0;
        }
       
        if(startTimer == true)
        {
            //Debug.Log("Timer Started");
            currentTime -= 1 * Time.deltaTime;
            //Debug.Log(currentTime);
            //Debug.Log(startTimer);
            if (currentTime <= 0)
            {
               
                currentTime = 0;
                
               reminder.SetActive(true);
                
                reminderCounter -= 1 * Time.deltaTime;
                
                
               if (reminderCounter <= 0)
               {
                    reminder.SetActive(false);
                    startTimer = false;
                }
               

            }
            
        }
    }
    public void TimerStart()
    {
        startTimer = true;
    }
    public void HandleInputData(int val)
    {
        Successful.gameObject.SetActive(true);
        if(val == 0){
            startingTime = 30f;
            currentTime = startingTime;
            Successful.text = "Timer is now set to: " + startingTime + " seconds.";
        }
        if (val == 1)
        {
            startingTime = 60f;
            currentTime = startingTime;
            Successful.text = "Timer is now set to: " + startingTime + " seconds.";
        }
        if (val == 2)
        {
            startingTime = 120f;
            currentTime = startingTime;
            Successful.text = "Timer is now set to: " + startingTime + " seconds.";
        }
        isTurnedOn = true;
    }
   
    
   
    
}
