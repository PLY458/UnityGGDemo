using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MoveBoard:MonoBehaviour
{
    public float speed;
    public float force;
    public GameObject ball;
    public Transform ShootPos;

    public Transform rightPos;
    public Transform leftPos;
    public bool isRight;

    private void Start()
    {
        isRight = true;
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (this.transform.position.x >= rightPos.position.x)
            isRight = false;
        if (this.transform.position.x <= leftPos.position.x)
            isRight = true;
        this.transform.Translate((isRight ? speed : -speed)*Time.deltaTime, 0, 0);
    }

    public void Shoot()
    {
        GameObject obj = Instantiate(ball, ShootPos.position,Quaternion.identity);
        obj.transform.forward = new Vector3(0, 1, 0);
        Rigidbody rig = obj.GetComponent<Rigidbody>();
        if(rig!=null)
            rig.AddForce(new Vector3(0, force, 0));
    }


}
