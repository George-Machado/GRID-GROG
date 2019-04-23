using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanger : MonoBehaviour
{

    public static Soundmanger instance;
    public AudioSource matchedSound;
    public AudioClip[]hotepCalling;
    // Start is called before the first frame update
    void Start()

    {
        instance = this;
        matchedSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void PlaySoundBite()
    {
        matchedSound.clip = hotepCalling[Random.Range(0, hotepCalling.Length)];
        matchedSound.Play();
    }
}
