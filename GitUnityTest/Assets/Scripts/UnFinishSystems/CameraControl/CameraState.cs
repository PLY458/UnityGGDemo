using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// 摄像机属性方法
/// </summary>
public class CameraState
{
    //追踪目标
    public Transform followTarget;
    //挂载的摄像头
    public Camera theCamera;

    //偏移的向量和移动速度
    public Vector3 offset;
    public float smoothSpeed;

    //镜头缩放的相关数值
    private float p_currentZoom;
    private float p_maxZoom;
    private float p_minZoom;
    private float p_zoomSensitivity;
    float zoomSmoothV;
    float targetZoom;

    //偏航速度和相对目标的直线距离
    private float p_yawSpeed;
    float dst;

    /// <summary>
    /// 初始化跟踪目标和偏移向量
    /// </summary>
    /// <param name="target"></param>
    /// <param name="offest"></param>
    /// <param name="camera"></param>>
    public CameraState(Camera camera,Transform target,Vector3 offest,float maxZoom,float minZoom,float yawspeed)
    {
        theCamera = camera;
        theCamera.transform.LookAt(target);
        dst = offest.magnitude;
        p_maxZoom = maxZoom;
        p_minZoom = minZoom;
        p_yawSpeed = yawspeed;
        p_currentZoom = 1f;
        targetZoom = p_currentZoom;
    }


    public void SetZoom(float scroll)
    {
            if (scroll != 0f)
            {
                targetZoom = Mathf.Clamp(targetZoom - scroll, p_minZoom, p_maxZoom);
            }
            p_currentZoom = Mathf.SmoothDamp(p_currentZoom, targetZoom, ref zoomSmoothV, .15f);
    }

    public void SetYaw()
    {
            
    }

    public void UpdateCamera()
    {

    }
}
