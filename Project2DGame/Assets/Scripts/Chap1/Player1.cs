using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour    // 1단계 플레이어 코드
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public float speed;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");   // 키보드 입력
        PlayerMove();   // 플레이어 이동 함수 호출
    }

    private void PlayerMove()   // 플레이어 이동
    {
        // 플레이어 방향 전환
        if (Input.GetButtonDown("Horizontal"))  // 키 입력할 때
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // 왼쪽키누르면 왼쪽,오른쪽 누르면 오른쪽 바라보기

        // 플레이어 x축 속도에 따른 애니메이션 변환
        if (Mathf.Abs(rigid.velocity.x) < 0.3)  // 플레이어 멈췄을 때(절대값)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);    // 플레이어 움직일때

        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y); // 이동
    }
}
