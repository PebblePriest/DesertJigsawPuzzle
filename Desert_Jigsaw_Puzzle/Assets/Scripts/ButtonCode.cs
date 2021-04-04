using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TitlePanel;
    public GameObject LessonPanel;
    public void StartButton()
    {
        TitlePanel.SetActive(false);
        LessonPanel.SetActive(true);

    }
    public void DesertButton()
    {
        SceneManager.LoadScene(1);
    }
}
