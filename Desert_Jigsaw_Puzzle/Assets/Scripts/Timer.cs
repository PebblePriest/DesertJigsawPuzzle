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
    public float reminderCounter = 10f;
    
    public bool startTimer;
    public bool noTimer = false;
   
    public bool reminderBool;
    public ButtonCode but;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        reminderCounter = 6f;
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
      
            if (startTimer == true)
            {

                currentTime -= 1 * Time.deltaTime;

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
        but.Coming.SetActive(false);
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
