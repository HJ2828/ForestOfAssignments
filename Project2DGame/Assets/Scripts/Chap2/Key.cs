using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Key : MonoBehaviour    // 화살표 오브젝트 관련 코드
{
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")    // 플레이어와 닿으면
        {
            Destroy(this.gameObject);   // 파괴
        }
    }
}
