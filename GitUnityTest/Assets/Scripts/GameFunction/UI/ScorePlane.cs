using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlane : UIBasePanel
{
    private Text score;
    private Text health;

    protected override void InitPanel()
    {
        score = GetControl<Text>("textScore");
        score.text = "0";
        health = GetControl<Text>("textHealth");
        score.text = "3";
    }

    void UpdateData()
    {
        int reallyscore = (int)BrickMgr.GetInstance().PlayerScore;
        score.text = reallyscore.ToString();
        int reallyHealth = BrickMgr.GetInstance().PlayerHealth;
        health.text = reallyHealth.ToString();
    }

    private void Start()
    {
        InitPanel();    
    }

    private void Update()
    {
        UpdateData();
    }
}
