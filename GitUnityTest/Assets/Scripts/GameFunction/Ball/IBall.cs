using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public enum E_Ball_Type
{
    Basic,
    Freeze,
    Red
}


public abstract class IBall:MonoBehaviour
{
    protected Rigidbody ball_rid;
    [SerializeField]
    private Vector3 moveDir;
    private E_Ball_Type type_ball;

    protected float movSpeed;
    protected float rayDistance;

    public Vector3 MoveDir { get => moveDir; set => moveDir = value; }
    public E_Ball_Type Type_ball { get => type_ball; set => type_ball = value; }

    protected abstract void InitBall();


    /// <summary>
    /// 小球射线检测
    /// </summary>
    protected virtual void RayToInspect()
    {
            Ray catchRay = new Ray(transform.position, MoveDir);
            RaycastHit hitInfo;
            if (Physics.Raycast(catchRay, out hitInfo, rayDistance))
            {
                var touch = hitInfo.transform.gameObject;
                Debug.DrawLine(catchRay.origin, hitInfo.point, Color.white);
                //玩家弹射版接触
                DapToOtherDir(hitInfo.normal, touch);
            }
            else
            {
                Debug.DrawLine(catchRay.origin, catchRay.origin + catchRay.direction * rayDistance, Color.yellow);
            }

    }

    /// <summary>
    /// 弹跳运动轨迹判定
    /// </summary>
    /// <param name="dapnormal">计算反弹用的法线</param>
    /// <param name="bar">可能得到的反弹板实例</param>
    protected virtual void DapToOtherDir(Vector3 dapnormal, GameObject touchObj)
    {
        Vector3 result;
        result = Vector3.Reflect(MoveDir, dapnormal);
        //根据不同Tag下有不同策略
        if (touchObj.tag == "MoveBar")
        {
            Vector3 barMove = touchObj.GetComponent<MoveBar>().GetBarMov();
            Debug.Log("反弹板的速度：" + barMove);
            result += barMove;
        }
        else if(touchObj.tag == "Brick")
        {
            EventCenter.GetInstance().EventTrigger<IBrick>("处理被打击的砖块", touchObj.GetComponent<IBrick>());
        }
        MoveDir = result.normalized;
    }
}
