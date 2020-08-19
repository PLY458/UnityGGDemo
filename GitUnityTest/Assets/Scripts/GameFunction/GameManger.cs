using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public class GameManger : MonoBehaviour
{
    public Camera theCamera;

    public void InitSystem()
    {
        BrickMgr.GetInstance().InitMgr();
        UIManagercs.GetInstance().showPanelOnLayer<ScorePlane>("ScorePlane");
    }

    // Start is called before the first frame update
    void Start()
    {
        InitSystem();
        Debug.Log("完成初始化");
    }


}
