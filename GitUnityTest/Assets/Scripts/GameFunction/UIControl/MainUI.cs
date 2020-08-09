using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManagercs.GetInstance().showPanel<BagPanel>("BagPanel", E_UI_Layer.Top);
        //下面可以从GameManager初始化所有面板存储的数据    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
