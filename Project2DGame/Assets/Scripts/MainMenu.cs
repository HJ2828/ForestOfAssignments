using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour   // ���� �޴� �ڵ�
{
    public void OnClickPlayBtn()    // Play��ư Ŭ����
    {
        SceneManager.LoadScene("MainToFirst");   // ù���� �� ����ȭ������
    }

    public void OnClickQuitBtn()    // Quit��ư Ŭ����
    {
        Application.Quit(); // ����
    }
}
