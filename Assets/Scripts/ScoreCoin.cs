using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCoin : MonoBehaviour
{
    public static int scoreAmount;
    Text Score;
    void Start()
    {
        Score = GetComponent<Text>();
        scoreAmount = 0;
    }
    void Update()
    {
        Score.text = "Score:" + scoreAmount + "/10";
        if (scoreAmount == 10)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
