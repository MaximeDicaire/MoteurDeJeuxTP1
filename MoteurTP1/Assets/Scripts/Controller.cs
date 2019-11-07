using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody body;
    private bool murFrappe = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        Vector3 movement = new Vector3();
        movement.x += Input.GetAxis("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        movement.z += Input.GetAxis("Vertical") * Time.fixedDeltaTime * moveSpeed;

        if (Physics.Raycast(transform.position,movement))
        {
            body.MovePosition(transform.position + movement);
        }
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            murFrappe = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            murFrappe = false;
        }
    }
}
