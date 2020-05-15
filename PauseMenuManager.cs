using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject controlMenu;

    private AudioSource audio;
    public AudioClip pauseMenuAppear;
    public AudioClip buttonClick;

    private void Start()
    {
        controlMenu.SetActive(false);
        pauseMenu.SetActive(false);
        audio = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePauseMenu(false);
        }
    }

    public void returnToMainMenu()
    {
        playSoundClip(buttonClick);
        SceneManager.LoadScene(0);
    }

    public void restartLevel()
    {
        playSoundClip(buttonClick);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void toggleControlMenu()
    {
        playSoundClip(buttonClick);

        if (controlMenu.activeInHierarchy)
        {
            controlMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            controlMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void togglePauseMenu(bool buttonPress)
    {
        if (buttonPress)
        {
            playSoundClip(buttonClick);
        }
        else
        {
            playSoundClip(pauseMenuAppear);
        }

        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }

    public void playSoundClip(AudioClip sound)
    {
        audio.PlayOneShot(sound);
    }
}
