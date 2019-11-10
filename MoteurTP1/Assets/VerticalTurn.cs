using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalTurn : MonoBehaviour
{

    void Awake()
    {
        
    }

    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        transform.Rotate(new Vector3(0,Time.deltaTime*50,0));
    }
}
