using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class SoundMarche : MonoBehaviour
{
    AudioSource audioMarche;        //son quand marche
    public AudioClip marche;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        //Son
        audioMarche = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving && (Input.GetKeyDown("up") || Input.GetKeyDown("down") || Input.GetKeyDown("right") || Input.GetKeyDown("left")))
        {
            isMoving = true;
            audioMarche.Play();
            audioMarche.loop = true;
        }
        else if (!Input.GetKey("up") && !Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            isMoving = false;
            audioMarche.Stop();
            audioMarche.loop = false;
        }
    }
}
