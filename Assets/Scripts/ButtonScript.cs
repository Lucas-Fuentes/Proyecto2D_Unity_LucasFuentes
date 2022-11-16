using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text PlayerName, PlayerAge;

    string name;
    byte age;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Validate()
    {
        name = PlayerName.text;
        age = byte.Parse(PlayerAge.text);
        Debug.Log(name);
        Debug.Log(age);

        if (age >= 18)
        {
            SceneManager.LoadScene("Level_0");
        }
        else
        {
            Debug.Log("Muy enano para jugar el juego.");
        }
    }
}
