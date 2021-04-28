using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{
    private string input;
    public InputField WYK1;
    public InputField WYK2;
    public InputField Prediction3;
    public InputField Reflection;
    public InputField Name;
    public InputField Date;
    public InputField Title;

    public Text wyk1;
    public Text wyk2;
    public Text p;
    public Text r;
    public Text showPredictions;
    public Text finalPredictions;
    public Text nameText;
    public Text dateText;
    public Text titleText;
    public Text whatYouKnow;

    public GameObject NextButton;
    public GameObject RNextButton;
    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NameInput(string s)
    {
        input = s;
        Debug.Log(s);
        nameText.text = s;

    }
    public void DateInput(string s)
    {
        input = s;
        Debug.Log(s);
        dateText.text = s;

    }
    public void TitleInput(string s)
    {
        input = s;
        Debug.Log(s);
        titleText.text = s;
        continueButton.SetActive(true);
    }
    public void WYK1Input(string s)
    {
        input = s;
        Debug.Log(s);
        wyk1.text = s;
        
    }
    public void WYK2Input(string s)
    {
        input = s;
        Debug.Log(s);
        wyk2.text = s;
        whatYouKnow.text = wyk1.text + "\n" + wyk2.text;
    }
    public void Prediction3Input(string s)
    {
        input = s;
        Debug.Log(s);
        p.text = s;
        showPredictions.text =  p.text;
        finalPredictions.text = p.text;
        NextButton.SetActive(true);
    }
    public void Reflect(string s)
    {
        input = s;
        Debug.Log(s);
        r.text = s;
        RNextButton.SetActive(true);
    }

}
