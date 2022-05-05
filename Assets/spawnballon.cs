using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnballon : MonoBehaviour
{
    [SerializeField] GameObject ballon;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int numOfBallons;
        int xMin = -20;
        int xMax = 20;
        int yMin = -4;
        int yMax = 6;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            numOfBallons = 1;
        }
        else if (SceneManager.GetActiveScene().name == "SampleScene 2")
        {
            numOfBallons = 2;
        }
        else
        {
            numOfBallons = 3;
        }
        for (int i = 0; i < numOfBallons; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(ballon, position, Quaternion.identity);
        }
    }
}
