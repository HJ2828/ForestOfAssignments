using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingDoor : MonoBehaviour     // 3�ܰ� ���� ���� �����ϸ� ���� ������ �ڵ�
{
    public Text pressXText;

    [SerializeField] GameObject GameClear;   // ���� Ŭ����
    public GameObject FadeScript;   // ���̵� �ƿ� ��ũ��Ʈ ȣ�� ����
//    bool isPress;
    // Start is called before the first frame update
    void Start()
    {
        pressXText.gameObject.SetActive(false); // x Ű ������� �ؽ�Ʈ �������� ����
    }

    // Update is called once per frame
    void Update()
    {
        if(pressXText && Input.GetKeyDown(KeyCode.X))   // x Ű ������
        {
            GameClear.SetActive(true);   // ���� Ŭ���� �ؽ�Ʈ Ȱ��ȭ
            FadeScript.GetComponent<FadeEffect>();  // ���̵� �ƿ� ���ִ� �Լ� ȣ��
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // �÷��̾ ���� ���� �����ϸ�
    {
        if(collision.tag == "Player")
        {
            pressXText.gameObject.SetActive(true);  // x Ű ������� �ؽ�Ʈ ����
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // �÷��̾ ���� ������ �־�����(���� ���� ������)
    {
        if(collision.tag == "Player")
        {
            pressXText.gameObject.SetActive(false); // x Ű ������� �ؽ�Ʈ �����
        }
    }
}
