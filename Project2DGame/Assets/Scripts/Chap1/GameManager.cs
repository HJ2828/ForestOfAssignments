using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour    // 1�ܰ� ������ ���� �Ŵ��� �ڵ�
{
    private static GameManager _instance;   // �̱�������: ���� �ѹ��� �޸� �Ҵ��ϰ� �ν��Ͻ��� ����� ����ϴ� ����
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public GameObject[] book;   // �������� ������(å �̹��� 2���� ���� ������Ʈ)

    private int i;  // �������� n��° �̹��� ����ϱ� ����
    private int score;  // ����
 
    [SerializeField]
    private Text scoretext; // ���� �ؽ�Ʈ

    [SerializeField] GameObject TimeOver;   // �� ui���� ������Ʈ��...
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject btnNext;
    [SerializeField] GameObject black;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreatebookRoutine());    // ������(�������� ������) ���� �ڷ�ƾ
    }

    // Update is called once per frame
    void Update()
    {
        GameEnd();  // ���� ���� �Լ� ȣ��
    }

    public void Score() // ���� ǥ��
    {
        score++;    // ���� ����
        scoretext.text = "Score: " + score; // ������ ���� �ؽ�Ʈ�� ǥ�� 
    }

    // �ڷ�ƾ�� �̿��� ������Ʈ ���� �������� ����
    IEnumerator CreatebookRoutine() // ��� �� ����
    {
        while (true)
        {
            CreatBook();    // ������ ���� �Լ� ȣ��
            yield return new WaitForSeconds(0.5f); // ���ð� 1�� �� ����
        }
    }

    private void RandBook() // ���� �Լ�
    {
        i = Random.Range(0, 2); // 2�� �� 1�� ���� �����ؼ� ���� i�� ������
    }

    private void CreatBook()    // ������ ���� �Լ�
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.09f, 0.91f), 1.1f, 0)); // ī�޶� �ȿ����� �����ǰ�(ī�޶� x��ǥ ������:0, ������:1, y��ǥ ���:1)

        // ���� ���� ���� pos�� z���� 0.0f��
        pos.z = 0.0f;

        RandBook(); // ���� �Լ� ȣ��

        Instantiate(book[i], pos, Quaternion.identity);    // ������Ʈ ���� // Quateranion.identity: ������Ʈ ȸ��X
    }

    // �ð� ���� �� ������ ���� ���� ���
    private void GameEnd()
    {
        if (TimeOver.activeSelf == true)    // �ð��� ���� �Ǿ��ٸ�
        {
            if (score > 50) // 50������ ������
            {
                GameClear.SetActive(true);
                btnNext.SetActive(true);    // ���� ��ư Ȱ��ȭ
                black.SetActive(true);    // ������� Ȱ��ȭ
            }
            else // 50�� �̸�
            {
                GameOver.SetActive(true);   // ���ӿ��� �ؽ�Ʈ Ȱ��ȭ
                btnNext.SetActive(true);    // ���� ��ư Ȱ��ȭ
                black.SetActive(true);    // ������� Ȱ��ȭ
            }
        }
    }

    public void OnClickNextBtn()    // 'Next Stage' ��ư Ŭ����
    {
        SceneManager.LoadScene("FirstToSecond");   // 2�ܰ� ���� ���� ȭ������ 
    }
}
