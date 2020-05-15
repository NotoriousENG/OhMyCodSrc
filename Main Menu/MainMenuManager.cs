using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject creditsPanel;

    private AudioSource audio;
    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = this.GetComponent<AudioSource>();
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }


    public void startGame(int index)
    {
        audio.PlayOneShot(buttonSound);
        SceneManager.LoadScene(index);
    }

    public void quitGame()
    {
        audio.PlayOneShot(buttonSound);
        Application.Quit();
    }

    public void toggleControlsPanel()
    {
        audio.PlayOneShot(buttonSound);
        if (controlsPanel.activeInHierarchy)
        {
            controlsPanel.SetActive(false);
        }
        else
        {
            controlsPanel.SetActive(true);
        }

    }

    public void toggleCreditPanel()
    {
        audio.PlayOneShot(buttonSound);
        if (creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(false);
        }
        else
        {
            creditsPanel.SetActive(true);
        }
    }

}
