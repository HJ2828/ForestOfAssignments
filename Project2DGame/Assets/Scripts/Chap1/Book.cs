using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Book : MonoBehaviour   // å ������Ʈ ���� �ڵ�
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")    // ���� ������
        {
            Destroy(this.gameObject);   // �ı�
            GameManager.instance.Score();   // Score()ȣ��
        }
        if (collision.gameObject.tag == "Player")   // �÷��̾�� ������
        {
            Destroy(this.gameObject);   // �ı�
        }
    }
}
