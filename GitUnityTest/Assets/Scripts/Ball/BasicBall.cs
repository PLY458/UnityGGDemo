using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : MonoBehaviour
{
    public bool isShootObject;//是否为射击小球
    public GameObject normalEffect;//普通粒子效果
    public GameObject colorEffect;//彩色粒子效果
    public float effectTime;//粒子效果持续时间
    Rigidbody rigidbody;
    MeshRenderer meshRenderer;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        BallManager.GetInstance().Add(this); 
    }

    private void OnCollisionEnter(Collision collision)
    {

        Rebound(collision);
    }

    void Rebound(Collision collision)//反弹
    {
        Vector3 v = rigidbody.velocity;
        ContactPoint contactPoint = collision.contacts[0];
        Vector3 newDir = Vector3.zero;
        Vector3 curDir = transform.TransformDirection(Vector3.forward);
        newDir = Vector3.Reflect(curDir, contactPoint.normal);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, newDir);
        transform.rotation = rotation;
        rigidbody.velocity = newDir.normalized * v.x / v.normalized.x;
    }

    void OnDestroy()
    {
        BallManager.GetInstance().Remove(this);
        if (isShootObject)
        {
            GameObject obj = Instantiate(normalEffect, transform.position, Quaternion.identity);
            Destroy(obj, effectTime);
        }
        else
        {
            GameObject obj = Instantiate(colorEffect, transform.position, Quaternion.identity);
            Destroy(obj, effectTime);
        }
    }
      
}
