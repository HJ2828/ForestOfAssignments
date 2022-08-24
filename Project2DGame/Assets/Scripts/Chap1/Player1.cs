using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour    // 1�ܰ� �÷��̾� �ڵ�
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
        horizontal = Input.GetAxis("Horizontal");   // Ű���� �Է�
        PlayerMove();   // �÷��̾� �̵� �Լ� ȣ��
    }

    private void PlayerMove()   // �÷��̾� �̵�
    {
        // �÷��̾� ���� ��ȯ
        if (Input.GetButtonDown("Horizontal"))  // Ű �Է��� ��
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // ����Ű������ ����,������ ������ ������ �ٶ󺸱�

        // �÷��̾� x�� �ӵ��� ���� �ִϸ��̼� ��ȯ
        if (Mathf.Abs(rigid.velocity.x) < 0.3)  // �÷��̾� ������ ��(���밪)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);    // �÷��̾� �����϶�

        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y); // �̵�
    }
}
