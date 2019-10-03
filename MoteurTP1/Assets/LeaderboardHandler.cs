using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardHandler : MonoBehaviour
{
    public Transform scrollview;
    public GameObject prefab;
    // Start is called before the first frame updatess
    void OnEnable()
    {
        //Load la base de données et boucler les inscrutions pour chaque score.
        GameObject scoreLine = Instantiate(prefab, scrollview);

        Transform nameLabel = scoreLine.transform.Find("NameLabel");
        TMP_Text nameLabelTextField = nameLabel.GetComponent<TMP_Text>();
        //Affecter le nom ici

        Transform scoreLabel = scoreLine.transform.Find("ScoreLabel");
        TMP_Text scoreLabelTextField = scoreLabel.GetComponent<TMP_Text>();
        //Affecter le score ici.
    }
}
