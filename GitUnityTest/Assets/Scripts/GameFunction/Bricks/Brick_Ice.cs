using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Ice : IBrick
{
    static string Ice_Ball = "ShootBall";

    protected override void InitBrick()
    {
        Health_Brick = 1;
        Score_Brick = 200.0f;
        Type_Brick = E_Brick_Type.Freeze;
        brickSelf = transform.gameObject;
        //shootDir = new Vector3(0.0f,0.0f,0.0f);
        RayRadius = 2.0f;
 
    }

    void Awake()
    {
        InitBrick();
    }

    void Update()
    {

    }

    public override void LoadAndShootBall()
    {
        transform.GetComponent<Collider>().enabled = false;
        Ball = ResourcesMgr.GetInstance().Load<GameObject>("Prefabs/" + Ice_Ball);
        Ball.transform.position = transform.position +ShootDir;
        if (Ball.GetComponent<IBall>() != null)
        {
            //赋予小球发射初方向
            Ball.GetComponent<IBall>().MoveDir = ShootDir.normalized;
        }
    }

    /// <summary>
    /// 检测碰撞时小球的方位，计算自身小球的发射向量
    /// </summary>
    public override void RayInspectRound()
    {
        base.LoadAndShootBall();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }
}
