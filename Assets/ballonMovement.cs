using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballonMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 7.5f;
    [SerializeField] float xMax = 20;
    [SerializeField] float xMin = -20;
    [SerializeField] bool right = true;
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject controller;
    [SerializeField] float expansionRate;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (audio == null)
            audio = GetComponent<AudioSource>();
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("GameController");
        if (SceneManager.GetActiveScene().name == "SampleScene")
            expansionRate = 0.001f;
        else if (SceneManager.GetActiveScene().name == "SampleScene 2")
            expansionRate = 0.002f;
        else if (SceneManager.GetActiveScene().name == "SampleScene 3")
            expansionRate = 0.003f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 2.0f)
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            PersistantData.Instance.SetScore(PlayerPrefs.GetInt("PlayerLevelScore" + (SceneManager.GetActiveScene().buildIndex - 1).ToString()));
            PersistantData.Instance.SetScore(PlayerPrefs.GetInt("PlayerLevelDarts" + (SceneManager.GetActiveScene().buildIndex - 1).ToString()));
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            expand();
        } 
    }

    void FixedUpdate()
    {
        if (right)
        {
            move(speed);
        }
        else
        {
            move(-speed);
        }
        if (rigid.position.x >= xMax)
        {
            right = false;
            if (speed < 15)
            {
                speed += 0.1f;
            }
        }
        if (rigid.position.x <= xMin)
        {
            right = true;
            if (speed < 15)
            {
                speed += 0.1f;
            }
        }
    }

    void move(float speed)
    {
        rigid.MovePosition(rigid.position + (new Vector2(speed,0)) * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Dart")
        {
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            controller.GetComponent<ScoreKeeper>().UpdateScore(1);
            Destroy(gameObject);
        }
    }

    public void expand()
    {
        transform.localScale = new Vector2(transform.localScale.x + expansionRate, transform.localScale.y + expansionRate);
    }
}
