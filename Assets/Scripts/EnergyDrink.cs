using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDrink : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public ScoreSystem scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnergyDrink")
        {
            score = score + 1;
            scoreText.text = "PUNTAJE: " + score;
            scoreManager.scoreValue = score;
            Destroy(collision.gameObject);
        }
    }
}
