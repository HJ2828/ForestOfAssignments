using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour   // 메인 메뉴 코드
{
    public void OnClickPlayBtn()    // Play버튼 클릭시
    {
        SceneManager.LoadScene("MainToFirst");   // 첫게임 전 설명화면으로
    }

    public void OnClickQuitBtn()    // Quit버튼 클릭시
    {
        Application.Quit(); // 종료
    }
}
