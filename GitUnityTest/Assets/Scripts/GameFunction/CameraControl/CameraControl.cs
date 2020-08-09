using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl :MonoBehaviour
{
    private CameraState m_cameraState = null;
    public Camera m_camera;
    public GameObject m_target;
    public Vector3 m_offestVec;
    public float m_minZoom;
    public float m_maxZoom;

    public void Start()
    {
        m_cameraState = new CameraState(m_camera,m_target.transform,m_offestVec);


    }

    //鼠标滚动控制缩放
    public void ZoomChangeUpdate()
    {
       // float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitivity;
       //
       // if (scroll != 0f)
       // {
       //     targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom);
       // }
       // currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomSmoothV, .15f);
    }

    //E,Q负责控制左右偏航
    public void YawChangeUpdate()
    {
      // transform.position = target.position - transform.forward * dst * currentZoom;
      // transform.LookAt(target.position);
      // 
      // float yawInput = Input.GetAxisRaw("Horizontal");
      // transform.RotateAround(target.position, Vector3.up, -yawInput * yawSpeed * Time.deltaTime);
    }
}
