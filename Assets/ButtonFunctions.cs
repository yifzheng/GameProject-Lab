using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    GameObject[] pauseMode;
    GameObject[] resumeMode;

    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        pauseMode = GameObject.FindGameObjectsWithTag("ResumeMode");
        resumeMode = GameObject.FindGameObjectsWithTag("PauseMode");

        foreach (GameObject g in pauseMode)
            g.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        Debug.Log("Pausing Game");
        foreach (GameObject g in resumeMode)
            g.SetActive(false);
        foreach (GameObject g in pauseMode)
            g.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Resuming Game");
        foreach (GameObject g in pauseMode)
            g.SetActive(false);
        foreach (GameObject g in resumeMode)
            g.SetActive(true);
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Menu()
    {
        /* if (SceneManager.GetActiveScene().name != "HighScore")
        {
            PersistantData.Instance.Reset();
            PlayerPrefs.DeleteKey("GameDifficulty");
        }   */
        PersistantData.Instance.Reset();
        PlayerPrefs.DeleteKey("GameDifficulty");
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void SampleScene()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void TogglePanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    public void HighScore()
    {
        PlayerPrefs.SetInt("FromMenu", 1);
        SceneManager.LoadScene("HighScore");
    }

    public void Easy()
    {
        PlayerPrefs.SetString("GameDifficulty", "Easy");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void Medium()
    {
        PlayerPrefs.SetString("GameDifficulty", "Medium");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }

    public void Hard()
    {
        PlayerPrefs.SetString("GameDifficulty", "Hard");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
}
