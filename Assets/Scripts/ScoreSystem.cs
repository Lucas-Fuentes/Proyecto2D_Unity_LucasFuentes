using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public string totalScore;
    public int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("PUNTAJE", scoreValue);
    }

    void OnEnable()
    {
        scoreValue = PlayerPrefs.GetInt("PUNTAJE");
    }
}
