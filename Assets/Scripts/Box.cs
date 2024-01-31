using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //声明改变箱子颜色相关变量
    public Color finishColor;
    Color originColor;

    private void Start()
    {
        //获取箱子原本颜色
        originColor = GetComponent<SpriteRenderer>().color;
        //获取箱子总数
        //每个箱子调用一次GamneManager，使箱子数+1
        FindObjectOfType<GameManager>().totalBoxes++;
    }
    //声明布尔值，用于判定箱子是否可以向给定方向移动
    public bool CanMoveToDir(Vector2 dir) 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + 0.5f*(Vector3)dir, dir, 0.5f);
        if (!hit||hit.collider.tag=="Target")
        {
            transform.Translate(dir);
            return true;
        }
        else
        {
            return false;
        }
    }
    //箱子进入触发器区域时的方法
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GetComponent<SpriteRenderer>().color = finishColor;
            FindObjectOfType<GameManager>().finishedBoxes++;
            FindObjectOfType<GameManager>().CheckFinish();
        }
    }
    //箱子离开触发器区域时的方法
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GetComponent<SpriteRenderer>().color = originColor;
            FindObjectOfType<GameManager>().finishedBoxes--;
        }
    }
}
