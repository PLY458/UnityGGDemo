using UnityEngine;

public class BrickMgr : BaseManeger<BrickMgr>
{
    private float playerScore;

    public float PlayerScore { get => playerScore; set => playerScore = value; }

    /// <summary>
    /// 接收Brick实体，判断类型，做出操作
    /// </summary>
    /// <param name="brick"></param>
    public void OperateBrick(IBrick brick)
    {
        brick.Health_Brick--;
        if (brick.Health_Brick <= 0)
        {
            switch (brick.Type_Brick)
            {
                case E_Brick_Type.Basic:
                    PlayerScore += brick.Score_Brick;
                    brick.ReleaseBrickObject();
                    break;
                case E_Brick_Type.Freeze:
                    PlayerScore += brick.Score_Brick;
                    brick.RayInspectRound();
                    brick.LoadAndShootBall();
                    brick.ReleaseBrickObject();
                    break;
            }
        }


    }

    public void InitMgr()
    {
        playerScore = 0.0f;
        Debug.Log("玩家初始分数：" + (int)playerScore);
        EventCenter.GetInstance().AddEventListener<IBrick>("处理被打击的砖块", OperateBrick);
    }

    
}