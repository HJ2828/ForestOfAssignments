using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour    // ȭ��ǥ ������Ʈ ���� �ڵ�
{
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")    // �÷��̾�� ������
        {
            Destroy(this.gameObject);   // �ı�
        }
    }
}
