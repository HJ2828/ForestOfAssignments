using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour   // 2�ܰ� ui ���� �ڵ�
{
    public GameObject btnNext;  // �� ui���� ������Ʈ��...
    public GameObject TimeOver;
    public GameObject black;

    // Update is called once per frame
    void Update()
    {
        if(TimeOver.activeSelf == true) // Ÿ�� ���� Ȱ��ȭ�Ǹ�
        {
            btnNext.SetActive(true);    // ���� ��ư�� Ȱ��ȭ
            black.SetActive(true);    // ������浵 Ȱ��ȭ
        }
    }

    public void OnClickNextBtn()    // 'Next Stage' ��ư Ŭ����
    {
        SceneManager.LoadScene("SecondToThird");   // 3�ܰ� ���� ���� ȭ������ 
    }
}