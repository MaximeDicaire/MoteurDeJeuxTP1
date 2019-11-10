using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectScript : MonoBehaviour
{
    public Rigidbody body;
    public Collider monCollider;
    public bool userTouch = false;
    public int cpt = 0;
    AudioSource audioCollectible;
    public AudioClip collectible;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        audioCollectible = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(userTouch == true)
        {
                if(cpt <= 8)
                {

                    transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                    cpt++;

                }
                else if(cpt <= 16)
                {

                    transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
                cpt++;

                }
                else
                {
                    Destroy(gameObject);
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            monCollider.enabled = false;
            userTouch = true;
            audioCollectible.PlayOneShot(collectible, 1);
        }
    }

}
