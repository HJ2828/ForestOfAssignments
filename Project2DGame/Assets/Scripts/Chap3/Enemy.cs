using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour  // 3단계 적 코드
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
        // 오른쪽으로 자동 이동
        rigid.velocity = new Vector2(3, rigid.velocity.y);  // 우측으로 이동
    }
}
