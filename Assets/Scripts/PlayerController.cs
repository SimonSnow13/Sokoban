using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //声明移动相关变量
    Vector2 moveDir;
    //声明图层检测相关变量
    public LayerMask detectLayer;

    private void Update()
    {
        //获取用户输入
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) 
        {
            moveDir = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            moveDir = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            moveDir = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            moveDir = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        //角色移动判定
        if (moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }
        //将移动向量清零
        moveDir = Vector2.zero;
    }
    //声明一个布尔值，用以判定玩家角色是否可向给定方向移动
    bool CanMoveToDir(Vector2 dir) 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,dir,1.0f,detectLayer ) ;
        if (!hit)
        {
            return true;
        }
        else if (hit.collider.GetComponent<Box>() != null)
        {
            return hit.collider.GetComponent<Box>().CanMoveToDir(dir);
        }
        else 
        {
            return false; 
        }
    }
    //角色移动的方法
    void Move(Vector2 dir) 
    {
        transform.Translate(dir) ;
    }
}
