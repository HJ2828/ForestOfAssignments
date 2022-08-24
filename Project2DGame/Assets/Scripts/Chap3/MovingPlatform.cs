using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour   // �����̴� ����
{
    Vector3 firstPos;
    Rigidbody2D rigid;
    float distance = 10f;   // ���� �Ÿ�
    Vector3 moveX = new Vector3(3, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        firstPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);   // ���� ��ġ
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveX * Time.deltaTime);    // ���� �̵�
        Vector3 pos = transform.position;
        
        if (pos.x -  firstPos.x > distance)    // ������ �Ÿ� > ���� �Ÿ�
        {
            moveX *= -1;    // ���� �ٲ�(�������� �̵�)
        }
        if (pos.x - firstPos.x < 0)    // ù ��� ��ġ�� ���� �ٽ� �������� �̵�
        {
            moveX *= -1;    // ���� �ٲ�(�������� �̵�)
        }
    }
}
