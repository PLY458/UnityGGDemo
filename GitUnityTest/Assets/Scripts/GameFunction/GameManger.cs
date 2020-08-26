using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;


public class GameManger : MonoBehaviour
{
    public Camera theCamera;

    public void InitSystem()
    {
        //Time.timeScale = 0.0f;
        BrickMgr.GetInstance().InitMgr();
        //UIManagercs.GetInstance().showPanelOnLayer<OpenMenu>("OpenMenu", E_UI_Layer.Top);
        UIManagercs.GetInstance().showPanelOnLayer<ScorePlane>("ScorePlane");

    }

    // Start is called before the first frame update
    void Start()
    {
        InitSystem();
        Debug.Log("完成初始化");
    }

    private void Update()
    {
        RestartGame();
    }

    void RestartGame()
    {
        if (BrickMgr.GetInstance().PlayerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(0);
        }
    }
}
