using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    private float speedMovement;
    private int lifePoints;
    private float posX;
    private Animator anim;
    private Rigidbody2D rb2d;
    private bool facingRight = true;
    private Vector3 localScale;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        speedMovement = 6f;
        lifePoints = 10;
    }

    // Update is called once per frame
    private void Update()
    {
        posX = Input.GetAxisRaw("Horizontal") * speedMovement;

        if (Input.GetKeyDown(KeyCode.Space) && rb2d.velocity.y == 0)
        {
            rb2d.AddForce(Vector2.up * 700f);
        }


        if (Mathf.Abs(posX) > 0 || Mathf.Abs(posX) < 0 && rb2d.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else 
        {
            anim.SetBool("isRunning", false);
        }
        
        if (rb2d.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb2d.velocity.y > 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", true);
        }

        if (rb2d.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFalling", true);
        }
    }

    // FUNCION ATAQUE JUGADOR

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(posX, rb2d.velocity.y);
    }

    private void LateUpdate()
    {
        if (posX > 0)
        {
            facingRight = true;
        }
        else if (posX < 0)
        {
            facingRight = false;
        }

        if ((facingRight) && (localScale.x < 0) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // ESCENAS

        if (collision.tag == "NextLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.tag == "PreviousLevel")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        else if (collision.tag == "DeathTrap")
        {
            SceneManager.LoadScene("Defeat");
        }
        else if (collision.tag == "VictoryGate")
        {
            SceneManager.LoadScene("Victory");
        }
        else if (collision.tag == "EnergyDrink")
        {
            collision.GetComponent<EnergyDrink>().OnTriggerEnter2D(collision);
        }

        // ENEMIGOS

        if (collision.tag == "EnemyMinion")
        {
            lifePoints = lifePoints - 2;
            Debug.Log(lifePoints);
            if (lifePoints == 0 || lifePoints < 0)
            {
                SceneManager.LoadScene("Defeat");
            }

        }


        if (collision.tag == "EnemyBoss")
        {
            lifePoints = lifePoints - 4;
            //anim.SetBool("isDamaged", true);
            Debug.Log(lifePoints);
            if (lifePoints == 0 || lifePoints < 0)
            {
                anim.SetBool("isDead", true);
                SceneManager.LoadScene("Defeat");
            }
        }

        // BOOSTER

        if (collision.tag == "Booster")
        {
            lifePoints = 10;
            Debug.Log(lifePoints);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        // ENEMIGOS


        // BOOSTER

        if (collision.CompareTag("Booster"))
        {
            Destroy(collision.gameObject);
        }
    }
}
