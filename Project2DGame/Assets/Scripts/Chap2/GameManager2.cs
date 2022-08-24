using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour   // 2단계 ui 관련 코드
{
    public GameObject btnNext;  // 각 ui들을 오브젝트로...
    public GameObject TimeOver;
    public GameObject black;

    // Update is called once per frame
    void Update()
    {
        if(TimeOver.activeSelf == true) // 타임 오버 활성화되면
        {
            btnNext.SetActive(true);    // 다음 버튼도 활성화
            black.SetActive(true);    // 검정배경도 활성화
        }
    }

    public void OnClickNextBtn()    // 'Next Stage' 버튼 클릭시
    {
        SceneManager.LoadScene("SecondToThird");   // 3단계 게임 설명 화면으로 
    }
}