using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SQLite4Unity3d;

public class LeaderboardHandler : MonoBehaviour
{
    public Transform scrollview;
    public GameObject prefab;
    // Start is called before the first frame updatess
    void OnEnable()
    {
        ShowScores();
    }

    public void OnAddBtnClick()
    {
        SQLiteConnection connection = new SQLiteConnection(Application.streamingAssetsPath + "/db.db", SQLiteOpenFlags.ReadWrite);

        connection.Insert(new Scores() { name = "test", score = "0" });

        ShowScores();
    }

    void ShowScores()
    {
        foreach (Transform child in scrollview)
        {
            Destroy(child.gameObject);
        }

        SQLiteConnection connection = new SQLiteConnection(Application.streamingAssetsPath + "/db.db", SQLiteOpenFlags.ReadWrite);
        var scores = connection.Query<Scores>("SELECT * FROM Scores ORDER BY score DESC");

        Scores[] scoresArr = scores.ToArray();
        Scores scorePlusGrand = null;
        foreach (Scores score in scoresArr)
        {
            //Trouver le plus grand score

            Debug.Log("test " + score);
        }

        foreach (Scores score in scoresArr)
        {
            //Load la base de données et boucler les inscrutions pour chaque score.
            GameObject scoreLine = Instantiate(prefab, scrollview);

            Transform nameLabel = scoreLine.transform.Find("NameLabel");
            TMP_Text nameLabelTextField = nameLabel.GetComponent<TMP_Text>();
            nameLabelTextField.SetText(score.name);

            Transform scoreLabel = scoreLine.transform.Find("ScoreLabel");
            TMP_Text scoreLabelTextField = scoreLabel.GetComponent<TMP_Text>();
            scoreLabelTextField.text = score.score.ToString();
        }
    }
}
