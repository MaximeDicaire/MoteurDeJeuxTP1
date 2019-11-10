using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class SoundMarche : MonoBehaviour
{
    AudioSource audioMarche;        //son quand marche
    public AudioClip marche;

    // Start is called before the first frame update
    void Start()
    {
        //Son
        audioMarche = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si on marche, on fait tourner le son
        if (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left"))
        {
            audioMarche.Play();
            audioMarche.loop = true;
        }
        //Si on marches pu on arrete le son
        if (Input.GetKeyUp("up") || Input.GetKeyUp("down") || Input.GetKeyUp("right") || Input.GetKeyUp("left"))
        {
            audioMarche.Stop();
            audioMarche.loop = false;
        }
    }
}
