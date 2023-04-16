using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject player;
    public static float tempScore;

    void Update()
    {
        score.text = "Score: " + tempScore.ToString();
    }
}
