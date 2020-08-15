using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : BaseManeger<BallManager>
{
    List<BasicBall> balls;
    int count;

    UnityEngine.Events.UnityAction<int> judgeEnd =null;
    public BallManager()
    {
        balls = new List<BasicBall>();
        count = 0;
    }

     public void Add(BasicBall ball)
     {
        balls.Add(ball);
        if (!ball.isShootObject) count++;
        if (judgeEnd != null)
        {
            judgeEnd(count);
        }
     }

     public void  Remove(BasicBall ball)
     {
        balls.Remove(ball);
        if (!ball.isShootObject) count--;
     }

}
