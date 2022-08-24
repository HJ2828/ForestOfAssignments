using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour  // Ÿ�̸� �ڵ�
{
    [SerializeField] float setTime = 10.0f; // �ð� ����
    [SerializeField] Text timerText;    // Ÿ�̸� �ؽ�Ʈ
    [SerializeField] GameObject TimeOver;   // Ÿ�� ���� �ؽ�Ʈ

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = setTime.ToString();    // time �ؽ�Ʈ ui
        Time.timeScale = 1.0f;  // �ð� �帧
    }

    // Update is called once per frame
    void Update()
    {
        if(setTime > 0) // �ð��� 0���� ũ��
        {
            setTime -= Time.deltaTime;  // 1�ʾ� �پ����
        }
        else if(setTime <= 0)
        {
            Time.timeScale = 0;     // 0���� �پ���� �ʰ� ����
            //SceneManager.LoadScene("FirstToSecond");   // �ι�° ���� �� ���� ȭ������ 
            TimeOver.SetActive(true);   // Ÿ�� ���� Ȱ��ȭ
        }
        timerText.text = Mathf.Round(setTime).ToString();   // �ð� �Ҽ��� ������, ǥ��

    }
}
