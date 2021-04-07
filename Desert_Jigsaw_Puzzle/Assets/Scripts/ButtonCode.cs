using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TitlePanel;
    public GameObject LessonPanel;
    public GameObject PredictionsPanel;
    public void StartButton()
    {
        TitlePanel.SetActive(false);
        LessonPanel.SetActive(true);
        PredictionsPanel.SetActive(false);
    }
    public void DesertButton()
    {
        LessonPanel.SetActive(false);
        PredictionsPanel.SetActive(true);
        TitlePanel.SetActive(false);
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
   
}
