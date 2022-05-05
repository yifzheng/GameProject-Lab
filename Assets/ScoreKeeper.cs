using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int dartCount;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text dartTxt;
    [SerializeField] int scoreThreshold;
    // Start is called before the first frame update
    void Start()
    {
        score = PersistantData.Instance.GetScore();
        dartCount = PersistantData.Instance.GetDarts();
        scoreThreshold = (SceneManager.GetActiveScene().buildIndex - 2) * 1;
        DisplayScore();
        DisplayDarts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int addend)
    {
        score += addend;
        DisplayScore();
        PersistantData.Instance.SetScore(score);
        if (score >= SceneManager.GetActiveScene().buildIndex - 2)
        {
            if (SceneManager.GetActiveScene().name == "SampleScene 3")
            {
                PlayerPrefs.SetInt("PlayerDartCount", PersistantData.Instance.GetDarts());
                PlayerPrefs.SetInt("PlayerScore", PersistantData.Instance.GetScore());
            }
            PlayerPrefs.SetInt("PlayerLevelScore" + SceneManager.GetActiveScene().buildIndex, score);
            PlayerPrefs.SetInt("PlayerLevelDarts" + SceneManager.GetActiveScene().buildIndex, dartCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void UpdateDarts()
    {
        dartCount++;
        DisplayDarts();
        PersistantData.Instance.IncrementDarts();
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayDarts()
    {
        dartTxt.text = "Darts: " + dartCount;
    }
}
