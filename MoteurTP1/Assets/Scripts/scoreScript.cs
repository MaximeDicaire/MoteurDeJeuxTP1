using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SQLite4Unity3d;

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

        if (score >= 6)
        {
            //Quand fini loader leaderboard avec nouveau score
            SQLiteConnection connection = new SQLiteConnection(Application.streamingAssetsPath + "/db.db", SQLiteOpenFlags.ReadWrite);
            connection.Insert(new Scores() { name = "Arouba", score = "6" });
            LoadLevel();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        score += 1;
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Menu");
    }
}
