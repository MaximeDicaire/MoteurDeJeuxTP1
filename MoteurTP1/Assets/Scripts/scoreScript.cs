using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    public Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Hello: " + score);

    }

    private void OnCollisionEnter(Collision collision)
    {

        score += 1;
        Debug.Log("BYE: " + score);
    }
}
