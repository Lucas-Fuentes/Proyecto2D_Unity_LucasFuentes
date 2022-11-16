using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource[] soundsfx;
    
    private void Awake()
    {
        instance = this;
    }

    public void Play(int soundToPlay)
    {
        soundsfx[soundToPlay].Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
