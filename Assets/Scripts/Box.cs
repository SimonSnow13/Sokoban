using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //�����ı�������ɫ��ر���
    public Color finishColor;
    Color originColor;

    private void Start()
    {
        //��ȡ����ԭ����ɫ
        originColor = GetComponent<SpriteRenderer>().color;
        //��ȡ��������
        //ÿ�����ӵ���һ��GamneManager��ʹ������+1
        FindObjectOfType<GameManager>().totalBoxes++;
    }
    //��������ֵ�������ж������Ƿ��������������ƶ�
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
    //���ӽ��봥��������ʱ�ķ���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GetComponent<SpriteRenderer>().color = finishColor;
            FindObjectOfType<GameManager>().finishedBoxes++;
            FindObjectOfType<GameManager>().CheckFinish();
        }
    }
    //�����뿪����������ʱ�ķ���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GetComponent<SpriteRenderer>().color = originColor;
            FindObjectOfType<GameManager>().finishedBoxes--;
        }
    }
}
