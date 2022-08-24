using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour    // 떨어지는 발판 코드
{
    [SerializeField]
    float fallSec = 0.5f, destroySec = 2f; 
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)  // 플레이어와 닿으면 떨어짐
    {
        if(collision.gameObject.name == "player")
        {
            Invoke("FallPlatform", fallSec);    // Invoke() : 주어진 시간이 지난 뒤, 지정된 함수를 실행하는 함수
            Destroy(gameObject, destroySec);    // destorySec초 후 오브젝트 파괴
        }
    }

    void FallPlatform()
    {
        rigid.isKinematic = false;  // 아래로 떨어지게...
    }
}
