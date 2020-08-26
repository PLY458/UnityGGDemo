using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public class Brick_Red : IBrick
{
    static string Red_Ball = "RedBall";
    private IBall m_redball;

    protected override void InitBrick()
    {
        Health_Brick = 5;
        Score_Brick = 600.0f;
        Type_Brick = E_Brick_Type.Red;
        brickSelf = transform.gameObject;
        //shootDir = new Vector3(0.0f,0.0f,0.0f);
        RayRadius = 1.3f;
        ShootTrigger = false;
        MatchTrigger = false;
        DestoryTrigger = false;
    }

    void Start()
    {
        InitBrick();
    }

    void Update()
    {

    }

    public override void LoadAndShootBall()
    {
        if (!ShootTrigger)
        {
            transform.GetComponent<Collider>().enabled = false;
            Ball = ResourcesMgr.GetInstance().Load<GameObject>("Prefabs/" + Red_Ball);
    
            if (Ball.GetComponent<Redball>())
                Setball(Ball.GetComponent<Redball>());
    
            Ball.transform.position = transform.position + ShootDir;
            if (Ball.GetComponent<IBall>() != null)
            {
                //赋予小球发射初方向
                Ball.GetComponent<IBall>().MoveDir = ShootDir.normalized;
                ShootTrigger = true;
            }
            transform.GetComponent<Collider>().enabled = true;
        }


    }
    /// <summary>
    /// 检测碰撞时小球的方位，计算自身小球的发射向量
    /// </summary>
    public override void RayInspectRound()
    {
        Vector3 temple;
        //发出射线检测物体
        Collider[] cols = Physics.OverlapSphere(transform.position, RayRadius);
        if (cols.Length > 0)
        {

            for (int n = 0; n < cols.Length ; n++)
            {
                //检测小球类型进行分别处理
                if (cols[n].gameObject.GetComponent<IBall>() )
                {
                    if (!ShootTrigger)
                    {
                        temple = transform.position - cols[n].transform.position;
                        ShootDir = new Vector3(temple.x, 0, temple.z).normalized;
                        Debug.Log("检测到弹球: " + cols[n] + "预备发射方向" + ShootDir);
                    }
                    else if(cols[n].gameObject.GetComponent<IBall>().Type_ball == E_Ball_Type.Red)
                    {
                        EqualballTest(cols[n].gameObject.GetComponent<IBall>());
                    }
                    
                }
            }
        }


    }

    /// <summary>
    /// 自我销毁以及分数回报
    /// </summary>
    public override float ReleaseBrickObject()
    {
        if (Health_Brick <= 0 || DestoryTrigger)
        {
            GameObject.Destroy(brickSelf);
            return Score_Brick;
        }
        else
            return 0;
    }

    /// <summary>
    /// 桥接模式，设定持有的小球对象
    /// </summary>
    /// <param name="redball"></param>
    public void Setball(IBall redball)
    {
        if (m_redball != null)
            m_redball.Release();
        m_redball = redball;

        //设定UI拥有者
        m_redball.SetOwner(this);
    }

    /// <summary>
    /// 检查传入小球是否是自己的
    /// </summary>
    /// <param name="redball"></param>
    private void EqualballTest(IBall redball)
    {
        if (m_redball.Equals(redball))
        {
            
        }
        else
        {
            DestoryTrigger = true;
            redball.Release();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, 1.3f);
    }
}
