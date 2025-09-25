using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
