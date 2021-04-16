using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    private string input;
    public InputField Prediction1;
    public InputField Prediction2;
    public InputField Prediction3;
    public InputField Reflection;

    public Text p1;
    public Text p2;
    public Text p3;
    public Text r1;
    public Text showPredictions;

    public GameObject NextButton;
    public GameObject RNextButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Prediction1Input(string s)
    {
        input = s;
        Debug.Log(s);
        p1.text = s;
        
    }
    public void Prediction2Input(string s)
    {
        input = s;
        Debug.Log(s);
        p2.text = s;
        
    }
    public void Prediction3Input(string s)
    {
        input = s;
        Debug.Log(s);
        p3.text = s;
        showPredictions.text = "1. " + p1.text + "\n" + "2. " + p2.text + "\n" + "3. " + p3.text;
        NextButton.SetActive(true);
    }
    public void Reflect(string s)
    {
        input = s;
        Debug.Log(s);
        r1.text = s;
        RNextButton.SetActive(true);
    }

}
