using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public Camera cameraUI;
    public GameObject tipUI ;
    //游戏物体与UI坐标交互的层级
    public LayerMask interactionMask;
    //对UI界面进行跟踪的目标UI层
    private Transform interUIlayer;

    // Start is called before the first frame update
    void Start()
    {
        UIManagercs.GetInstance().showPanelOnLayer<InteractPanel>("InteractPanel", E_UI_Layer.Top);
        //下面可以从GameDataMgr初始化所有面板存储的数据    
        UIManagercs.GetInstance().showPanelOnLayer<InteractSlot>("InteractSlot", E_UI_Layer.System, (panel) =>
        {
            panel.InitInfo();
            tipUI = panel.gameObject;
        });
        UIManagercs.GetInstance().GetUIlayer(E_UI_Layer.System, out interUIlayer);
    }

    // Update is called once per frame
    void Update()
    {
        //FollowTips();
    }

    private void FixedUpdate()
    {
        
    }

    private void ActTips()
    {
        //长按事件模拟
        //开始按键
        if (Input.GetMouseButtonDown(0))
        {
                //鼠标在UI上的方位
                Vector2 mousePosition;
                // 射出一条射线
                Ray ray = cameraUI.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // 如果射线与物体交互
                if (Physics.Raycast(ray, out hit, interactionMask))
                {
                    Debug.Log("获得鼠标点击区" + hit.point);
                }
            
        }


    }
    /// <summary>
    /// 得到某个UI上的鼠标真实坐标(待封装)
    /// </summary>
    /// <param name="thisTrans"></param>
    /// <returns></returns>
    public void CurrMousePosition(Transform thisTrans)
    {
        float width, length;
        RectTransform parentRT = thisTrans.parent.transform.GetComponent<RectTransform>();
    }

}
