using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{

    public float moveSpeed = 5f;
    private bool IsShoot = false;

    public GameObject ball;
    private Rigidbody board_rid;
    public Vector3 shootPos;

    [SerializeField]
    private Vector3 direct;

    public float minPosX;
    public float maxPosX;
    public float minPosZ;
    public float maxPosZ;


    void InitBoard()
    {
        ball = ResourcesMgr.GetInstance().Load<GameObject>("Prefabs/ShootBall");
        ball.transform.position = transform.position + shootPos;
        board_rid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InitBoard();
    }
    private void Update()
    {
        UpdateInput();
        Shoot();
    }

    private void FixedUpdate()
    {
        MovePostion();
    }

    public void UpdateInput()
    {
        direct.x = Input.GetAxisRaw("Horizontal");

    }

    public void MovePostion()
    {
        board_rid.MovePosition(board_rid.position + direct * moveSpeed * Time.fixedDeltaTime);
        if (!IsShoot)
        {
            ball.transform.position = transform.position + shootPos;
        }
        
    }
    
    public void Shoot()
    {
        if (Input.GetButton("Fire1") && !IsShoot)
        {
            float dirX = UnityEngine.Random.Range(minPosX, maxPosX);
            float dirZ = UnityEngine.Random.Range(minPosZ, maxPosZ);
            if (ball.GetComponent<ShootBall>() != null)
            {
                //赋予小球发射初方向
                ball.GetComponent<ShootBall>().MoveDir = new Vector3(dirX, 0.0f, dirZ).normalized;
            }
            IsShoot = true;   
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawWireSphere(transform.position + shootPos, 0.5f);
    }

    public Vector3 GetBarMov()
    {
        return direct * moveSpeed;
    }
}
