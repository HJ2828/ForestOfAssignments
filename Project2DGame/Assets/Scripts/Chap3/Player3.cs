using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3 : MonoBehaviour    // 3�ܰ� �÷��̾� ���� �ڵ�
{
    Vector3 firstpos;   // �÷��̾� ù ��ġ
    public float maxSpeed;  // �ִ�ӵ�
    public float jumpPower; // �����Ŀ�
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField] GameObject GameOver;

    public GameObject FadeScript;   // ���̵� �ƿ� ��ũ��Ʈ ȣ�� ����


    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();

        firstpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);   // �÷��̾� ó�� ��ġ �� ����
    }

    void Update()   // �ܹ����� Ű �Է�, ���������� ���� ��(1�ʿ� 60��)
    {
        // �÷��̾� ����(���� �ѹ���)
        if (Input.GetButtonDown("Jump") && this.rigid2D.velocity.y == 0)  // Ű �Է��� ��(space ��(����Ƽ �⺻����))
        {
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // �÷��̾� �̵�
        if (Input.GetButtonUp("Horizontal")) //��ư ���� �ӵ� �ٿ���
        {
            // normalized: ������ ũ�⸦ 1�� ���� ���� ���� ����)(���� ���� �� ��)
            rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * 0.5f, rigid2D.velocity.y);
        }

        // �÷��̾� ���� ��ȯ
        if (Input.GetButtonDown("Horizontal"))  // Ű �Է��� ��
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // ����Ű������ ����,������ ������ ������ �ٶ󺸱�

        // �÷��̾� x�� �ӵ��� ���� �ִϸ��̼� ��ȯ
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)  // �÷��̾� ������ ��(���밪)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);    // �÷��̾� �����϶�

        // �÷��̾ ȭ�� ������ �����ٸ� ���� ����
        if(transform.position.y < -30)  
        {
            GameOver.SetActive(true);   // ���� ���� �ؽ�Ʈ Ȱ��ȭ
            transform.position = firstpos;   // �÷��̾� ��ġ ó������
            FadeScript.GetComponent<FadeEffect>();  // ���̵� �ƿ� ���ִ� �Լ� ȣ��

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ���̶� �浹�ϸ�
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameOver.SetActive(true);   // ���� ���� �ؽ�Ʈ Ȱ��ȭ
            FadeScript.GetComponent<FadeEffect>();  // ���̵� �ƿ� ���ִ� �Լ� ȣ��
        }
    }

    // Update is called once per frame
    void FixedUpdate()  // �������� Ű �Է�, 1�ʿ� �� 50�� ���� ��
    {
        // �̵�, �ӵ�
        float h = Input.GetAxisRaw("Horizontal");
        rigid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // �ӵ� ����
        if(rigid2D.velocity.x > maxSpeed)  // ������ �ִ� �ӵ�
        {
            rigid2D.velocity = new Vector2(maxSpeed, rigid2D.velocity.y);
        }
        else if (rigid2D.velocity.x < maxSpeed*(-1))  // ���� �ִ� �ӵ�
        {
            rigid2D.velocity = new Vector2(maxSpeed*(-1), rigid2D.velocity.y);
        }
    }
}
