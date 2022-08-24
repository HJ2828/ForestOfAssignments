using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Book : MonoBehaviour   // 책 오브젝트 관련 코드
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")    // 땅에 닿으면
        {
            Destroy(this.gameObject);   // 파괴
            GameManager.instance.Score();   // Score()호출
        }
        if (collision.gameObject.tag == "Player")   // 플레이어와 닿으면
        {
            Destroy(this.gameObject);   // 파괴
        }
    }
}
