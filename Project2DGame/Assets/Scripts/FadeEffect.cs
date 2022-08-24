using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeEffect : MonoBehaviour // 화면 페이드 아웃 코드
{
    [SerializeField] Image image;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;

    private int imgA = 0;   // 이미지 페이드 업데이트 도는 횟수

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  // 시간 흐름
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;
        if((GameOver.activeSelf == true) || (GameClear.activeSelf == true)) // 게임오버나 게임클리어 텍스트가 활성화 되면
        {
            if (color.a < 1)    // 투명도 증가
            {
                color.a += Time.deltaTime;  // 1초에 증가

                image.color = color;

                imgA++; // 알파값 1씩 증가
                print(imgA);
            }
        }

        if(imgA == 30)  // 30번 업데이트 되면
        {
            Time.timeScale = 0; // 시간 멈춤
            if (GameOver.activeSelf == true)
            {
                SceneManager.LoadScene("BadEnding");   // 배드 엔딩으로 
            }
            if (GameClear.activeSelf == true)
            {
                SceneManager.LoadScene("HappyEnding");   // 해피 엔딩으로 
            }
        }
    }
}
