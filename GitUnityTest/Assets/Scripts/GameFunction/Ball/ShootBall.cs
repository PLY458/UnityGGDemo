using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : IBall
{

    protected override void InitBall()
    {
        ball_rid = GetComponent<Rigidbody>();
        Type_ball = E_Ball_Type.Basic;
        movSpeed = 8.0f;
        rayDistance = 0.5f;
        ballself = transform.gameObject;
    }

    void Start()
    {
        InitBall();
    }


    void FixedUpdate()
    {
        MovePosition();
        RayToInspect();
    }

}
