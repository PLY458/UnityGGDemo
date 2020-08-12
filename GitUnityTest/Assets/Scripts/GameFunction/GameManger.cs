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
        //UIManagercs.GetInstance().showPanelOnLayer<InteractSlot>("InteractSlot", E_UI_Layer.System);
        //生成初始界面
        UIManagercs.GetInstance().showPanelOnLayer<InteractPanel>("InteractPanel", E_UI_Layer.Top);
        //得到临时格子UI所在的层级  

    }

    // Start is called before the first frame update
    void Start()
    {
        InitSystem();
        RayserUIsystem.GetInstance().InitRayserSystem(theCamera);
        Debug.Log("完成初始化");
    }


}
