using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player : MonoBehaviour
{
    public TMP_Text txtScore;

    public LayerMask ground;

    public AudioClip jumpSound;
    public AudioClip cookieSound;

    AudioSource src;
    Rigidbody2D rb;
    bool jump = false;
    Vector2 move;
    float speed = 4.0f;

    
    Animator anim;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        src = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
       // txtScore.text = GameData.lives.ToString("0"); //was points
    }

    void Update() {
       // var feet = new Vector2(transform.position.x, transform.position.y - 0.5f);
        //var dimensions = new Vector2(0.8f, 0.1f);
        //var grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);

        if (Input.GetKey(KeyCode.W)) {
            rb.velocity = new Vector2(0, speed);
            anim.SetInteger("direction", 1); //going up
        }
        else if (Input.GetKey(KeyCode.S)) {
            rb.velocity = new Vector2(0, -speed);
            anim.SetInteger("direction", 2); //going towards you
        }
        else if (Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector2(-speed, 0);
            anim.SetInteger("direction", 3); //going right 
        }
        else if (Input.GetKey(KeyCode.D)) {
            rb.velocity = new Vector2(speed, 0);
            anim.SetInteger("direction", 4);
        }
        else {
            rb.velocity = Vector2.zero;
            anim.SetInteger("direction", 0);
        }

        //anim.SetBool("grounded", grounded);

        if (rb.velocity == Vector2.zero)
        {
           // anim.SetBool("isMoving", false); //was walking
        }
        else
        {
         //   anim.SetBool("isMoving", true); //was walking 
        }
    }

    private void FixedUpdate() {
       

    }

    void Die()
    {
        Debug.Log("Wasted!");
        GameData.lives--;

        if (GameData.lives == 0) {
            // Load you lose
            UnityEngine.SceneManagement.SceneManager.LoadScene("end");

        } else {

            // Reload current scene
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cookie")
        {
            Destroy(collision.gameObject);
            src.PlayOneShot(cookieSound);
            //lives = lives + 10;
        }

        if (collision.tag == "enemy")
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Die();
        }
    }

}
