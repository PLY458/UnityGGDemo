using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;


public class Redball : IBall
{


    protected override void InitBall()
    {
        ball_rid = GetComponent<Rigidbody>();
        Type_ball = E_Ball_Type.Red;
        movSpeed = 10.0f;
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
