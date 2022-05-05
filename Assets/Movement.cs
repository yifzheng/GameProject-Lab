using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] float vMovement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject dart;
    [SerializeField] bool isFired = false;
    [SerializeField] GameObject controller;
    [SerializeField] Animator animator;
    int count = 0;
    const int IDLE = 0;
    const int RUN = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (dart == null)
            dart = GameObject.FindGameObjectWithTag("Dart");
        if (controller == null)
            controller = GameObject.FindGameObjectWithTag("GameController");
        if (animator == null)
            animator= GetComponent<Animator>();
        speed = 15;
        animator.SetInteger("state", IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isFired = true;
        }
        if (movement >= .01 || movement <= -.01)
            animator.SetInteger("state", RUN);
        else if (vMovement >= .01 || vMovement <= -.01)
            animator.SetInteger("state", RUN);
        else
            animator.SetInteger("state", IDLE);
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        rigid.velocity = new Vector2(movement * speed, vMovement * speed);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (isFired)
        {
            fireDart();
            count++;
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    /* void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    } */

    /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
 */
    void fireDart()
    {
        Vector2 position = new Vector2((float)(rigid.position.x + 1.5), rigid.position.y);
        Instantiate(dart, position, Quaternion.identity);
        isFired = false;
        controller.GetComponent<ScoreKeeper>().UpdateDarts();
    }
}
