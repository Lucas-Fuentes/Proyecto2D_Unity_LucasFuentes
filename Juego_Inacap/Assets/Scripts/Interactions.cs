using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public Text textLife;
    public short life=10000;//16
    public float velocidad=25.0f;
    public float salto=100.0f;
    Rigidbody2D rb2d;
    private bool saltando = false;
    // Start is called before the first frame update
    void Start()
    {
        textLife.text = life.ToString();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * velocidad * Time.deltaTime,0, 0);
        if (Input.GetKey(KeyCode.Space) && !saltando){
            rb2d.AddForce(Vector2.up * salto);
        }
        //Debug.Log(saltando);
    }    

    private void OnCollisionEnter2D(Collision2D obj){
        if(obj.collider.CompareTag("Minion")){
        Debug.Log("Colisionando Con enemy");
        }


         if(obj.collider.CompareTag("Baseplate")){
             saltando=false;
          }


     }

      private void OnCollisionExit2D(Collision2D obj){
         if(obj.collider.CompareTag("Baseplate")){
             saltando=true;
         }



    }

     private void OnCollisionStay2D(Collision2D obj){





    }

    private void OnTriggerStay2D(Collider2D obj){
        if(obj.CompareTag("Boss")){
        //restar vida
        life--;
        textLife.text = life.ToString();
        
        
    }
    }

    private void OnTriggerExit2D(Collider2D obj){
        if(obj.CompareTag("Booster")){
            velocidad = 12f;
        }
        Destroy(obj.gameObject);
    }


    }