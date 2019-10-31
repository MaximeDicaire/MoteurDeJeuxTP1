using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x += Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        position.z += Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.position = position;

        //Input.GetAxis("Horizontal")
        //body.AddForce(transform.forward * (Time.deltaTime * moveSpeed));
    }
}
