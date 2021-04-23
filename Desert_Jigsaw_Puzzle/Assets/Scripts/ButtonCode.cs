using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TitlePanel;
    public GameObject LessonPanel;
    public GameObject PredictionsPanel;
    public GameObject IndexPanel;
    public GameObject SettingPanel;
    public GameObject LessonCompletePanel;
    
    public GameObject ConceptMap;
   
    public void LessonSelect()
    {
        TitlePanel.SetActive(false);
        LessonPanel.SetActive(true);
        PredictionsPanel.SetActive(false);
    }
    public void Predictions()
    {
        LessonPanel.SetActive(false);
        PredictionsPanel.SetActive(true);
        TitlePanel.SetActive(false);
    }
    public void Continue()
    {
        SceneManager.LoadScene(1);
    }
    public void TitleButton()
    {
        LessonPanel.SetActive(false);
        PredictionsPanel.SetActive(false);
        TitlePanel.SetActive(true);
        LessonCompletePanel.SetActive(false);
    }
    public void Index()
    {
        IndexPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
    public void IndexOff()
    {
        IndexPanel.SetActive(false);
    }
    public void Settings()
    {
        SettingPanel.SetActive(true);
        IndexPanel.SetActive(false);
    }
    public void SettingsOff()
    {
        SettingPanel.SetActive(false);
    }
    public void ConceptPanel()
    {
        SettingPanel.SetActive(false);
        IndexPanel.SetActive(false);
        LessonPanel.SetActive(false);
        PredictionsPanel.SetActive(false);
        LessonCompletePanel.SetActive(false);
        ConceptMap.SetActive(true);
        TitlePanel.SetActive(false);
    }
    public void LessonComplete()
    {
        SettingPanel.SetActive(false);
        IndexPanel.SetActive(false);
        LessonPanel.SetActive(false);
        PredictionsPanel.SetActive(false);
        LessonCompletePanel.SetActive(true);
        ConceptMap.SetActive(false);
        TitlePanel.SetActive(false);
    }
  
   
}
