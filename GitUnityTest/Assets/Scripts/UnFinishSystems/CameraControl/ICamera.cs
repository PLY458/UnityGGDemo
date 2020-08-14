using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public abstract class ICamera
{
    //挂载的摄像头
    protected Camera theCamera;
    //跟踪(或贴合)的目标方位
    protected Transform theTarget;
    //俯仰，偏航，翻滚角速度
    protected float yaw_Speed;
    protected float pitch_Speed;
    protected float roll_Speed;
    //缩放速度和移动速度
    protected float zoom_Speed;
    


}
