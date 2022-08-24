using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour    // 1단계 게임의 게임 매니져 코드
{
    private static GameManager _instance;   // 싱글톤패턴: 최초 한번만 메모리 할당하고 인스턴스를 만들어 사용하는 패턴
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public GameObject[] book;   // 떨어지는 아이템(책 이미지 2개를 넣을 오브젝트)

    private int i;  // 랜덤으로 n번째 이미지 사용하기 위해
    private int score;  // 점수
 
    [SerializeField]
    private Text scoretext; // 점수 텍스트

    [SerializeField] GameObject TimeOver;   // 각 ui들을 오브젝트로...
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject btnNext;
    [SerializeField] GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatebookRoutine());    // 아이템(떨어지는 아이템) 생성 코루틴
    }

    // Update is called once per frame
    void Update()
    {
        GameEnd();  // 게임 종료 함수 호출
    }

    public void Score() // 점수 표시
    {
        score++;    // 점수 증가
        scoretext.text = "Score: " + score; // 증가한 점수 텍스트로 표시 
    }

    // 코루틴을 이용한 오브젝트 일정 간격으로 생성
    IEnumerator CreatebookRoutine() // 대기 전 실행
    {
        while (true)
        {
            CreatBook();    // 아이템 생성 함수 호출
            yield return new WaitForSeconds(0.5f); // 대기시간 1초 후 실행
        }
    }

    private void RandBook() // 랜덤 함수
    {
        i = Random.Range(0, 2); // 2개 중 1개 랜덤 생성해서 변수 i의 값으로
    }

    private void CreatBook()    // 아이템 생성 함수
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.09f, 0.91f), 1.1f, 0)); // 카메라 안에서만 생성되게(카메라 x좌표 좌측끝:0, 우측끝:1, y좌표 상단:1)

        // 랜덤 값을 받은 pos의 z값을 0.0f로
        pos.z = 0.0f;

        RandBook(); // 램덤 함수 호출

        Instantiate(book[i], pos, Quaternion.identity);    // 오브젝트 생성 // Quateranion.identity: 오브젝트 회전X
    }

    // 시간 종료 후 점수에 따른 게임 결과
    private void GameEnd()
    {
        if (TimeOver.activeSelf == true)    // 시간이 종료 되었다면
        {
            if (score > 50) // 50점보다 높으면
            {
                GameClear.SetActive(true);
                btnNext.SetActive(true);    // 다음 버튼 활성화
                black.SetActive(true);    // 검정배경 활성화
            }
            else // 50점 미만
            {
                GameOver.SetActive(true);   // 게임오버 텍스트 활성화
                btnNext.SetActive(true);    // 다음 버튼 활성화
                black.SetActive(true);    // 검정배경 활성화
            }
        }
    }

    public void OnClickNextBtn()    // 'Next Stage' 버튼 클릭시
    {
        SceneManager.LoadScene("FirstToSecond");   // 2단계 게임 설명 화면으로 
    }
}
