using UnityEngine;

public enum E_Brick_Type
{
        Basic,
        Freeze,
        Red
}


public abstract class IBrick : MonoBehaviour
{
    private int health_Brick;
    private float score_Brick;
    private E_Brick_Type type_Brick;

    private Vector3 shootDir;
    private GameObject ball;
    private float rayRadius;

    protected GameObject brickSelf;
    private bool matchTrigger;
    private bool shootTrigger;
    private bool destoryTrigger;

    public int Health_Brick { get => health_Brick; set => health_Brick = value; }
    public float Score_Brick { get => score_Brick; set => score_Brick = value; }
    public E_Brick_Type Type_Brick { get => type_Brick; set => type_Brick = value; }

    public Vector3 ShootDir { get => shootDir; set => shootDir = value; }
    public GameObject Ball { get => ball; set => ball = value; }
    public float RayRadius { get => rayRadius; set => rayRadius = value; }
    public bool MatchTrigger { get => matchTrigger; set => matchTrigger = value; }
    public bool ShootTrigger { get => shootTrigger; set => shootTrigger = value; }
    public bool DestoryTrigger { get => destoryTrigger; set => destoryTrigger = value; }

    protected abstract void InitBrick();

    //砖块发射弹珠
    public virtual void LoadAndShootBall()
    {

    }

    public GameObject GetBrickObject()
    {
        return brickSelf;
    }

    public virtual float ReleaseBrickObject()
    {
        if (health_Brick <= 0)
        {
            GameObject.Destroy(brickSelf);
            return Score_Brick;
        }
        else
            return 0;
    }

    //砖块检测四周环境
    public virtual void RayInspectRound()
    {
        Vector3 temple;
        //发出射线检测物体
        Collider[] cols = Physics.OverlapSphere(transform.position, rayRadius);
        if (cols.Length > 0)
        {
            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.GetComponent<IBall>())
                {
                    temple = transform.position - cols[i].transform.position;
                    shootDir = new Vector3(temple.x, 0, temple.z).normalized;
                    Debug.Log("检测到弹球: " + cols[i] + "预备发射方向" + shootDir);
                    break;
                }
            }
        }
    }
}