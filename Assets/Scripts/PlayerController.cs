using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�����ƶ���ر���
    Vector2 moveDir;
    //����ͼ������ر���
    public LayerMask detectLayer;

    private void Update()
    {
        //��ȡ�û�����
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
        //��ɫ�ƶ��ж�
        if (moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }
        //���ƶ���������
        moveDir = Vector2.zero;
    }
    //����һ������ֵ�������ж���ҽ�ɫ�Ƿ������������ƶ�
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
    //��ɫ�ƶ��ķ���
    void Move(Vector2 dir) 
    {
        transform.Translate(dir) ;
    }
}
