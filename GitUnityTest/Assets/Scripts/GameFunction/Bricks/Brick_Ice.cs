using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Ice : IBrick
{
    private Vector3 shootDir;
    private GameObject ball;
    private float rayRadius;


    protected override void InitBrick()
    {
        Health_Brick = 1;
        Score_Brick = 200.0f;
        Type_Brick = E_Brick_Type.Freeze;
        brickSelf = transform.gameObject;
        shootDir = new Vector3(0.0f,0.0f,0.0f);
        rayRadius = 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitBrick();
    }

    void Update()
    {

    }

    public override void LoadAndShootBall()
    {
        transform.GetComponent<Collider>().enabled = false;
        ball = ResourcesMgr.GetInstance().Load<GameObject>("Prefabs/ShootBall");
        ball.transform.position = transform.position + shootDir;
        if (ball.GetComponent<IBall>() != null)
        {
            //赋予小球发射初方向
            ball.GetComponent<IBall>().MoveDir = shootDir.normalized;
        }
    }

    /// <summary>
    /// 检测碰撞时小球的方位，计算自身小球的发射向量
    /// </summary>
    public override void RayInspectRound()
    {
        Vector3 temple;
        //发出射线检测物体
        Collider[] cols = Physics.OverlapSphere(transform.position, rayRadius);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.GetComponent<IBall>())
                {
                    temple = transform.position - cols[i].transform.position;
                    shootDir = new Vector3(temple.x,0,temple.z).normalized;
                    Debug.Log("检测到弹球: "+cols[i]+"预备发射方向"+shootDir);
                    break;
                }     
            }
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }
}
