using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour  // 3�ܰ� �� �ڵ�
{
    Rigidbody2D rigid;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ���������� �ڵ� �̵�
        rigid.velocity = new Vector2(3, rigid.velocity.y);  // �������� �̵�
    }
}
