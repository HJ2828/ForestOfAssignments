using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour    // 2단계 플레이어(사각형 박스) 관련 코드
{
    Rigidbody2D rigid;

    bool keyUp, keyRight, keyLeft, keyDown, keySpace;   // 누른 키와 화살표 이미지가 같은지 판단
    public static int count = 1;    // 한줄에 8번, 첫 시작 점 1번
    Vector3 pos = new Vector3(-7, 1, 0);    // 플레이어 위치 설정

    public static int score2 = 0;   // 점수
    [SerializeField]    
    private Text scoretext; // 점수 텍스트

    [SerializeField] GameObject TimeOver;   // 각 ui를 오브젝트로...
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        transform.position = pos;   // 플레이어 위치(플레이어: 사각박스)
    }

    // Update is called once per frame
    void Update()
    {
        keyCheck(); // 방향키와 화살표 오브젝트 일치여부 확인 함수 호출

        GameEnd();  // 게임이 끝나면 호출
    }

    private void playerMove()   // 플레이어 이동
    {
        if(count <= 7)  // 1 ~ 7번째
        {
            transform.Translate(2, 0, 0); // 이동 (옆으로)
            count++;    // 자리수 증가
        }
        else if(count > 7)  // 8번째
        {
            transform.position = pos;   // 처음 위치로
            count = 1;  // 1번 으로
        }

        score2++;   // 점수 증가
        scoretext.text = "과제 해결: " + score2 + " / " + (score2 / 8); // 점수 반영해서 UI 나타내기

    }

    private void keyCheck() // 방향키와 화살표가 같은지 확인
    {
        if (keyUp && Input.GetKeyDown(KeyCode.UpArrow)) // 상
        {
            playerMove();
        }
        if (keyRight && Input.GetKeyDown(KeyCode.RightArrow)) //우
        {
            playerMove();
        }
        if (keyLeft && Input.GetKeyDown(KeyCode.LeftArrow)) // 좌
        {
            playerMove();
        }
        if (keyDown && Input.GetKeyDown(KeyCode.DownArrow)) // 하
        {
            playerMove();
        }
        if (keySpace && Input.GetKeyDown(KeyCode.Space))    // 스페이스바
        {
            playerMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 충돌 여부 확인(방향키와 화살표오브젝트 일치 여부 확인하기 위함)
    {
        if (collision.gameObject.tag == "up")   // 상
        {
            keyUp  = true;  // 위쪽 화살표 오브젝트와 방향키 일치시 keyUp true로
        }
        if (collision.gameObject.tag == "right")    // 우
        {
            keyRight  = true;  // 오른쪽 화살표 오브젝트와 방향키 일치시 keyRight true로
        }
        if (collision.gameObject.tag == "left") // 좌
        {
            keyLeft = true;  // 왼쪽 화살표 오브젝트와 방향키 일치시 keyLeft true로
        }
        if (collision.gameObject.tag == "down") // 하
        {
            keyDown = true;  // 아래쪽 화살표 오브젝트와 방향키 일치시 keyDown true로
        }
        if (collision.gameObject.tag == "space")    // 스페이스바
        {
            keySpace  = true;  // 스페이스바 오브젝트와 방향키 일치시 keySpace true로
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)      // 플레이어가 화살표 이미지를 벗어남
    {
        if (collision.gameObject.tag == "up")   // 상
        {
            keyUp = false;  // 위쪽 화살표 오브젝트와 방향키 일치시 keyUp false로
        }
        if (collision.gameObject.tag == "right")    // 우
        {
            keyRight  = false;  // 오른쪽 화살표 오브젝트와 방향키 일치시 keyRight false로
        }
        if (collision.gameObject.tag == "left") // 좌
        {
            keyLeft = false;  // 왼쪽 화살표 오브젝트와 방향키 일치시 keyLeft false로
        }
        if (collision.gameObject.tag == "down") // 하
        {
            keyDown = false;  // 아래쪽 화살표 오브젝트와 방향키 일치시 keyDown false로
        }
        if (collision.gameObject.tag == "space")    // 스페이스바
        {
            keySpace  = false;  // 스페이스바 오브젝트와 방향키 일치시 keySpace false로
        }
    }

    // 시간 종료 후 점수에 따른 게임 결과
    private void GameEnd()
    {
        if (TimeOver.activeSelf == true)    // 시간이 종료 되었다면
        {
            if(score2 > 50) // 50점보다 높다면
            {
                GameClear.SetActive(true);  // 게임 클리어 텍스트 활성화
            }
            else // 50 아래
            {
                GameOver.SetActive(true);   // 게임 오버 텍스트 활성화
            }   
        }
    }
}
