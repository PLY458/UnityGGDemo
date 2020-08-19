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
        movSpeed = 5.0f;
        rayDistance = 0.5f;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitBall();
    }


    void FixedUpdate()
    {
        ball_rid.MovePosition(transform.position + MoveDir * movSpeed * Time.deltaTime);
        RayToInspect();
    }

}
