using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : UIBasePanel
{
    private Image imgBkg;
    private Animator animatorBkg;
    private Button startGame;
    private Button endGame;

    protected override void InitPanel()
    {
        imgBkg = GetControl<Image>("imgBkg");
        animatorBkg = imgBkg.GetComponent<Animator>();
        startGame = GetControl<Image>("imgStart").GetComponent<Button>();
        endGame = GetControl<Image>("imgEnd").GetComponent<Button>();
        startGame.onClick.AddListener(StartGame);
        endGame.onClick.AddListener(EndGame);
    }

    void Start()
    {
        InitPanel();
    }

    
    void Update()
    {
        FinishAnime();
    }

    public void StartGame()
    {
        Debug.Log("背景动画机：" + animatorBkg);
        bool isOpen = animatorBkg.GetBool("Open");
        animatorBkg.SetBool("Open", !isOpen);
    }

    public void FinishAnime()
    {
        AnimatorStateInfo stateInfo = animatorBkg.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Opening") && stateInfo.normalizedTime >= 1.0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void EndGame()
    {
        Debug.Log("确认退出！");
        Application.Quit();
    }
}
