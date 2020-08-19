using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlane : UIBasePanel
{
    private Text score;

    protected override void InitPanel()
    {
        score = GetControl<Text>("textScore");
        score.text = "0";
    }

    void UpdateScore()
    {
        int reallyscore = (int)BrickMgr.GetInstance().PlayerScore;
        score.text = reallyscore.ToString();
    }

    private void Start()
    {
        InitPanel();    
    }

    private void Update()
    {
        UpdateScore();
    }
}
