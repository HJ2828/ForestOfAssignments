using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour  // 타이머 코드
{
    [SerializeField] float setTime = 10.0f; // 시간 설정
    [SerializeField] Text timerText;    // 타이머 텍스트
    [SerializeField] GameObject TimeOver;   // 타임 오버 텍스트

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = setTime.ToString();    // time 텍스트 ui
        Time.timeScale = 1.0f;  // 시간 흐름
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime > 0) // 시간이 0보다 크면
        {
            setTime -= Time.deltaTime;  // 1초씩 줄어들음
        }
        else if(setTime <= 0)
        {
            Time.timeScale = 0;     // 0에서 줄어들지 않고 멈춤
            //SceneManager.LoadScene("FirstToSecond");   // 두번째 게임 전 설명 화면으로 
            TimeOver.SetActive(true);   // 타임 오버 활성화
        }
        timerText.text = Mathf.Round(setTime).ToString();   // 시간 소수점 버리고, 표시

    }
}
