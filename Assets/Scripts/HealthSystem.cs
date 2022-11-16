using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int lifePoints;
    public Text lifePointsText;
    
    // Start is called before the first frame update
    void Start()
    {
        lifePointsText.text = "VIDA: " + lifePoints;
        lifePoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyMinion")
        {
            lifePoints = lifePoints - 2;
            lifePointsText.text = "VIDA: " + lifePoints;
            if (lifePoints == 0 || lifePoints < 0)
            {
                SceneManager.LoadScene("Defeat");
            }
        }
        else if (collision.tag == "Booster")
        {
            lifePoints = 10;
            lifePointsText.text = "VIDA: " + lifePoints;
            Destroy(collision.gameObject);
        }
    }
}


