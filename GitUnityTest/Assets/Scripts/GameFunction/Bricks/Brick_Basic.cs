using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public class Brick_Basic : IBrick
{
    protected override void InitBrick()
    {
        Health_Brick = 2;
        Score_Brick = 100.0f;
        Type_Brick = E_Brick_Type.Basic;
        brickSelf = transform.gameObject;
    }

    private void Start()
    {
        InitBrick();
    }
}
