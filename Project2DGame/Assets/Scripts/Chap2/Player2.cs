using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour    // 2�ܰ� �÷��̾�(�簢�� �ڽ�) ���� �ڵ�
{
    Rigidbody2D rigid;

    bool keyUp, keyRight, keyLeft, keyDown, keySpace;   // ���� Ű�� ȭ��ǥ �̹����� ������ �Ǵ�
    public static int count = 1;    // ���ٿ� 8��, ù ���� �� 1��
    Vector3 pos = new Vector3(-7, 1, 0);    // �÷��̾� ��ġ ����

    public static int score2 = 0;   // ����
    [SerializeField]    
    private Text scoretext; // ���� �ؽ�Ʈ

    [SerializeField] GameObject TimeOver;   // �� ui�� ������Ʈ��...
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        transform.position = pos;   // �÷��̾� ��ġ(�÷��̾�: �簢�ڽ�)
    }

    // Update is called once per frame
    void Update()
    {
        keyCheck(); // ����Ű�� ȭ��ǥ ������Ʈ ��ġ���� Ȯ�� �Լ� ȣ��

        GameEnd();  // ������ ������ ȣ��
    }

    private void playerMove()   // �÷��̾� �̵�
    {
        if(count <= 7)  // 1 ~ 7��°
        {
            transform.Translate(2, 0, 0); // �̵� (������)
            count++;    // �ڸ��� ����
        }
        else if(count > 7)  // 8��°
        {
            transform.position = pos;   // ó�� ��ġ��
            count = 1;  // 1�� ����
        }

        score2++;   // ���� ����
        scoretext.text = "���� �ذ�: " + score2 + " / " + (score2 / 8); // ���� �ݿ��ؼ� UI ��Ÿ����

    }

    private void keyCheck() // ����Ű�� ȭ��ǥ�� ������ Ȯ��
    {
        if (keyUp && Input.GetKeyDown(KeyCode.UpArrow)) // ��
        {
            playerMove();
        }
        if (keyRight && Input.GetKeyDown(KeyCode.RightArrow)) //��
        {
            playerMove();
        }
        if (keyLeft && Input.GetKeyDown(KeyCode.LeftArrow)) // ��
        {
            playerMove();
        }
        if (keyDown && Input.GetKeyDown(KeyCode.DownArrow)) // ��
        {
            playerMove();
        }
        if (keySpace && Input.GetKeyDown(KeyCode.Space))    // �����̽���
        {
            playerMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // �浹 ���� Ȯ��(����Ű�� ȭ��ǥ������Ʈ ��ġ ���� Ȯ���ϱ� ����)
    {
        if (collision.gameObject.tag == "up")   // ��
        {
            keyUp  = true;  // ���� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyUp true��
        }
        if (collision.gameObject.tag == "right")    // ��
        {
            keyRight  = true;  // ������ ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyRight true��
        }
        if (collision.gameObject.tag == "left") // ��
        {
            keyLeft = true;  // ���� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyLeft true��
        }
        if (collision.gameObject.tag == "down") // ��
        {
            keyDown = true;  // �Ʒ��� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyDown true��
        }
        if (collision.gameObject.tag == "space")    // �����̽���
        {
            keySpace  = true;  // �����̽��� ������Ʈ�� ����Ű ��ġ�� keySpace true��
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)      // �÷��̾ ȭ��ǥ �̹����� ���
    {
        if (collision.gameObject.tag == "up")   // ��
        {
            keyUp = false;  // ���� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyUp false��
        }
        if (collision.gameObject.tag == "right")    // ��
        {
            keyRight  = false;  // ������ ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyRight false��
        }
        if (collision.gameObject.tag == "left") // ��
        {
            keyLeft = false;  // ���� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyLeft false��
        }
        if (collision.gameObject.tag == "down") // ��
        {
            keyDown = false;  // �Ʒ��� ȭ��ǥ ������Ʈ�� ����Ű ��ġ�� keyDown false��
        }
        if (collision.gameObject.tag == "space")    // �����̽���
        {
            keySpace  = false;  // �����̽��� ������Ʈ�� ����Ű ��ġ�� keySpace false��
        }
    }

    // �ð� ���� �� ������ ���� ���� ���
    private void GameEnd()
    {
        if (TimeOver.activeSelf == true)    // �ð��� ���� �Ǿ��ٸ�
        {
            if(score2 > 50) // 50������ ���ٸ�
            {
                GameClear.SetActive(true);  // ���� Ŭ���� �ؽ�Ʈ Ȱ��ȭ
            }
            else // 50 �Ʒ�
            {
                GameOver.SetActive(true);   // ���� ���� �ؽ�Ʈ Ȱ��ȭ
            }   
        }
    }
}
