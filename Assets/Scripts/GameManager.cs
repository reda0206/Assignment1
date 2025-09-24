using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isKeyCollected = false;
    public GameObject pauseMenuUi;
    public bool isPaused = false;
    public TextMeshProUGUI keyStatusText;
    public Transform KeyDoor;
    private List<AudioSource> audioSources = new List<AudioSource>();
    public List<AudioSource> excludedAudioSources = new List<AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        keyStatusText.text = "Key: Not Collected";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void CollectKey()
    {
        isKeyCollected = true;
        keyStatusText.text = "Key: Collected";
        Debug.Log("Key Collected!");
        OpenKeyDoor();
    }

    public void OpenKeyDoor()
    {
        Destroy(KeyDoor.gameObject);
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuUi.SetActive(true);
        PauseAudio();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUi.SetActive(false);
        ResumeAudio();
        Time.timeScale = 1f;
    }

    public void QuitToMenuButton()
    {
        SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1f;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void PauseAudio()
    {
        foreach (AudioSource audio in FindObjectsOfType<AudioSource>())
        {
            if (!excludedAudioSources.Contains(audio) && audio.isPlaying)
            {
                audio.Pause();
                audioSources.Add(audio);
            }
        }
    }

    public void ResumeAudio()
    {
        for (int i = audioSources.Count -1; i >= 0; i--)
        {
            if (audioSources[i])
            {
                audioSources[i].UnPause();
                audioSources.RemoveAt(i);
            }
        }
    }
}
