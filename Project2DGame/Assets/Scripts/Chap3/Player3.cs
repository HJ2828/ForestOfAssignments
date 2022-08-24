using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player3 : MonoBehaviour    // 3단계 플레이어 관련 코드
{
    Vector3 firstpos;   // 플레이어 첫 위치
    public float maxSpeed;  // 최대속도
    public float jumpPower; // 점프파워
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField] GameObject GameOver;

    public GameObject FadeScript;   // 페이드 아웃 스크립트 호출 위함


    // Start is called before the first frame update
    void Start()
    {
        // 초기화
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.anim = GetComponent<Animator>();

        firstpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);   // 플레이어 처음 위치 값 저장
    }

    void Update()   // 단발적인 키 입력, 실제적으로 도는 것(1초에 60번)
    {
        // 플레이어 점프(점프 한번만)
        if (Input.GetButtonDown("Jump") && this.rigid2D.velocity.y == 0)  // 키 입력할 때(space 바(유니티 기본세팅))
        {
            rigid2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // 플레이어 이동
        if (Input.GetButtonUp("Horizontal")) //버튼 떼면 속도 줄여줌
        {
            // normalized: 벡터의 크기를 1로 만든 상태 단위 벡터)(방향 구할 때 씀)
            rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * 0.5f, rigid2D.velocity.y);
        }

        // 플레이어 방향 전환
        if (Input.GetButtonDown("Horizontal"))  // 키 입력할 때
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; // 왼쪽키누르면 왼쪽,오른쪽 누르면 오른쪽 바라보기

        // 플레이어 x축 속도에 따른 애니메이션 변환
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)  // 플레이어 멈췄을 때(절대값)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);    // 플레이어 움직일때

        // 플레이어가 화면 밖으로 나갔다면 게임 오버
        if(transform.position.y < -30)  
        {
            GameOver.SetActive(true);   // 게임 오버 텍스트 활성화
            transform.position = firstpos;   // 플레이어 위치 처음으로
            FadeScript.GetComponent<FadeEffect>();  // 페이드 아웃 해주는 함수 호출

        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // 적이랑 충돌하면
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameOver.SetActive(true);   // 게임 오버 텍스트 활성화
            FadeScript.GetComponent<FadeEffect>();  // 페이드 아웃 해주는 함수 호출
        }
    }

    // Update is called once per frame
    void FixedUpdate()  // 지속적인 키 입력, 1초에 약 50번 도는 것
    {
        // 이동, 속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // 속도 제한
        if(rigid2D.velocity.x > maxSpeed)  // 오른쪽 최대 속도
        {
            rigid2D.velocity = new Vector2(maxSpeed, rigid2D.velocity.y);
        }
        else if (rigid2D.velocity.x < maxSpeed*(-1))  // 왼쪽 최대 속도
        {
            rigid2D.velocity = new Vector2(maxSpeed*(-1), rigid2D.velocity.y);
        }
    }
}
