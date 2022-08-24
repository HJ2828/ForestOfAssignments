using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeEffect : MonoBehaviour // ȭ�� ���̵� �ƿ� �ڵ�
{
    [SerializeField] Image image;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;

    private int imgA = 0;   // �̹��� ���̵� ������Ʈ ���� Ƚ��

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;  // �ð� �帧
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;
        if((GameOver.activeSelf == true) || (GameClear.activeSelf == true)) // ���ӿ����� ����Ŭ���� �ؽ�Ʈ�� Ȱ��ȭ �Ǹ�
        {
            if (color.a < 1)    // ���� ����
            {
                color.a += Time.deltaTime;  // 1�ʿ� ����

                image.color = color;

                imgA++; // ���İ� 1�� ����
                print(imgA);
            }
        }

        if(imgA == 30)  // 30�� ������Ʈ �Ǹ�
        {
            Time.timeScale = 0; // �ð� ����
            if (GameOver.activeSelf == true)
            {
                SceneManager.LoadScene("BadEnding");   // ��� �������� 
            }
            if (GameClear.activeSelf == true)
            {
                SceneManager.LoadScene("HappyEnding");   // ���� �������� 
            }
        }
    }
}
