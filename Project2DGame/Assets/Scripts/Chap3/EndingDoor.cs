using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDoor : MonoBehaviour     // 3단계 최종 문에 도달하면 엔딩 나오는 코드
{
    public Text pressXText;

    [SerializeField] GameObject GameClear;   // 게임 클리어
    public GameObject FadeScript;   // 페이드 아웃 스크립트 호출 위함
//    bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        pressXText.gameObject.SetActive(false); // x 키 누르라는 텍스트 보여지지 않음
    }

    // Update is called once per frame
    void Update()
    {
        if(pressXText && Input.GetKeyDown(KeyCode.X))   // x 키 누르면
        {
            GameClear.SetActive(true);   // 게임 클리어 텍스트 활성화
            FadeScript.GetComponent<FadeEffect>();  // 페이드 아웃 해주는 함수 호출
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 플레이어가 최종 문에 도달하면
    {
        if(collision.tag == "Player")
        {
            pressXText.gameObject.SetActive(true);  // x 키 누르라는 텍스트 나옴
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // 플레이어가 최종 문에서 멀어지면(문과 닿지 않으면)
    {
        if(collision.tag == "Player")
        {
            pressXText.gameObject.SetActive(false); // x 키 누르라는 텍스트 사라짐
        }
    }
}
