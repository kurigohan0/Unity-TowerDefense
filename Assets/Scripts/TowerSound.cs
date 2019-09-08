using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSound : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioClip MusicClip;

    public static AudioSource MusicSource;

    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Play()
    {
        MusicSource.Play();
    }
}
