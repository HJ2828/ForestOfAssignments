using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondToThird : MonoBehaviour    // 2단계에서 3단계로 넘어가는 UI 코드
{
    public GameObject text1;    // UI 텍스드들을 오브젝트로 설정
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    private int count = 1;

    // Start is called before the first frame update
    void Start()

    {   // 첫 화면에 띄어줄 텍스트만 활성화 해주고 나머지 비활성화
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(false);
        text4.SetActive(false);
    }

    public void OnClickNextBtn()    // '->' 버튼 클릭시
    {
        if (count == 1)  // 첫 페이지에서 두번째 페이지로
        {
            text1.SetActive(false); // 첫페이지 텍스트 비활성화. 두번째 페이지 텍스트 활성화
            text2.SetActive(false);
            text3.SetActive(true);
            text4.SetActive(true);
            count++;
        }
        else    // 두번째 페이지에서 다음 게임 화면 으로
        {
            SceneManager.LoadScene("ThirdScene");   // 3단계 게임 화면으로 
        }
    }
}
