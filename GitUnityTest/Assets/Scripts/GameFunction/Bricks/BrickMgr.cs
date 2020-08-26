using System.Collections.Generic;
using UnityEngine;

public class BrickMgr : BaseManeger<BrickMgr>
{
    private float playerScore;
    private int playerHealth;

    public float PlayerScore { get => playerScore; set => playerScore = value; }
    public int PlayerHealth { get => playerHealth; set => playerHealth = value; }

    /// <summary>
    /// 记录带颜色砖块
    /// </summary>
    private Dictionary<E_Brick_Type, IBrick> brickDic = new Dictionary<E_Brick_Type, IBrick>();

    /// <summary>
    /// 接收Brick实体，判断类型，做出操作
    /// </summary>
    /// <param name="brick"></param>
    public void OperateBrick(IBrick brick,E_Ball_Type ball_type)
    {
            brick.Health_Brick--;
            if (brick.Type_Brick == E_Brick_Type.Basic)
            {
                PlayerScore += brick.ReleaseBrickObject();
            }
            else if (brick.Type_Brick == E_Brick_Type.Freeze)
            {
                brick.RayInspectRound();
                brick.LoadAndShootBall();
                PlayerScore += brick.ReleaseBrickObject();
            }
            else {
                    brick.RayInspectRound();
                    brick.LoadAndShootBall();
                    PlayerScore += brick.ReleaseBrickObject();
            }

    }


    public void InitMgr()
    {
        playerScore = 0.0f;
        playerHealth = 3;
    }


}