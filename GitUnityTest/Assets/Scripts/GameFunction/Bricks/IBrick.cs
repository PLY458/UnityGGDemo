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
    protected GameObject brickSelf;

    public int Health_Brick { get => health_Brick; set => health_Brick = value; }
    public float Score_Brick { get => score_Brick; set => score_Brick = value; }
    public E_Brick_Type Type_Brick { get => type_Brick; set => type_Brick = value; }

    protected abstract void InitBrick();

    //砖块发射弹珠
    public virtual void LoadAndShootBall()
    {

    }

    public GameObject GetBrickObject()
    {
        return brickSelf;
    }

    public void ReleaseBrickObject()
    {
        GameObject.Destroy(brickSelf);
    }

    //砖块检测四周环境
    public virtual void RayInspectRound()
    {

    }
}