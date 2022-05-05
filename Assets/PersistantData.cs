using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] int numDarts;

    public static PersistantData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        AudioListener.volume = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        numDarts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore(int s)
    {
        playerScore = s;
    }

    public void SetDarts(int s)
    {
        numDarts = s;
    }

    public void IncrementDarts()
    {
        numDarts += 1;
    }

    public void Reset()
    {
        playerScore = 0;
        numDarts = 0;
    }
    public int GetScore()
    {
        return playerScore;
    }

    public int GetDarts()
    {
        return numDarts;
    }
}
