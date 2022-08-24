using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondToThird : MonoBehaviour    // 2�ܰ迡�� 3�ܰ�� �Ѿ�� UI �ڵ�
{
    public GameObject text1;    // UI �ؽ������ ������Ʈ�� ����
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    private int count = 1;

    // Start is called before the first frame update
    void Start()

    {   // ù ȭ�鿡 ����� �ؽ�Ʈ�� Ȱ��ȭ ���ְ� ������ ��Ȱ��ȭ
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(false);
        text4.SetActive(false);
    }

    public void OnClickNextBtn()    // '->' ��ư Ŭ����
    {
        if (count == 1)  // ù ���������� �ι�° ��������
        {
            text1.SetActive(false); // ù������ �ؽ�Ʈ ��Ȱ��ȭ. �ι�° ������ �ؽ�Ʈ Ȱ��ȭ
            text2.SetActive(false);
            text3.SetActive(true);
            text4.SetActive(true);
            count++;
        }
        else    // �ι�° ���������� ���� ���� ȭ�� ����
        {
            SceneManager.LoadScene("ThirdScene");   // 3�ܰ� ���� ȭ������ 
        }
    }
}
