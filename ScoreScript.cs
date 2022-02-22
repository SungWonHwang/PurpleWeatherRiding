using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyScoreText;
    private int ScoreNum;
    void Start()
    {
        ScoreNum=0;
        MyScoreText.text="SCORE : "+ ScoreNum;
    }

}
