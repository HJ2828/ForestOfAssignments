using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour   // 움직이는 발판
{
    Vector3 firstPos;
    Rigidbody2D rigid;
    float distance = 10f;   // 지정 거리
    Vector3 moveX = new Vector3(3, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        firstPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);   // 시작 위치
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveX * Time.deltaTime);    // 우측 이동
        Vector3 pos = transform.position;
        
        if (pos.x -  firstPos.x > distance)    // 움직인 거리 > 지정 거리
        {
            moveX *= -1;    // 방향 바꿈(좌측으로 이동)
        }
        if (pos.x - firstPos.x < 0)    // 첫 출발 위치로 가면 다시 우측으로 이동
        {
            moveX *= -1;    // 방향 바꿈(우측으로 이동)
        }
    }
}
