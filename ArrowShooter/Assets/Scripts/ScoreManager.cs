using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    [HideInInspector]
    public int Score = 0;

    [SerializeField]
    private Text Scoretxt;

    void Update()
    {
        SetScore(Score);
    }



    void SetScore(int score)
    {
        Scoretxt.text = "Score: " + Score; 
    }
}
