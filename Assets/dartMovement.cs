using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dartMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    /* [SerializeField] bool isFired = false;
    [SerializeField] bool isFacingRight = true; */
    int speed;
    string difficulty;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        difficulty = PlayerPrefs.GetString("GameDifficulty");
        Debug.Log(difficulty);
        if (difficulty == "Easy")
        {
            speed = 25;
        }
        if (difficulty == "Medium")
        {
            speed = 20;
        }
        if (difficulty == "Hard")
        {
            speed = 15;
        }
        Debug.Log(speed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (rigid.position.x > 20)
        {
            Destroy(gameObject);
        }
        fire(speed);
    }

    void fire(float speed)
    {
        rigid.MovePosition(rigid.position + (new Vector2(speed,0)) * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    } 
}
