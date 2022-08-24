using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour    // �������� ���� �ڵ�
{
    [SerializeField]
    float fallSec = 0.5f, destroySec = 2f; 
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �÷��̾�� ������ ������
    {
        if(collision.gameObject.name == "player")
        {
            Invoke("FallPlatform", fallSec);    // Invoke() : �־��� �ð��� ���� ��, ������ �Լ��� �����ϴ� �Լ�
            Destroy(gameObject, destroySec);    // destorySec�� �� ������Ʈ �ı�
        }
    }

    void FallPlatform()
    {
        rigid.isKinematic = false;  // �Ʒ��� ��������...
    }
}
