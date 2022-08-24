using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour     // 화살표 오브젝트 생성관련 코드
{
    Rigidbody2D rigid;
    public GameObject[] key1;   // 첫번째 화살표 오브젝트 부터 8번째 까지
    public GameObject[] key2;
    public GameObject[] key3;
    public GameObject[] key4;
    public GameObject[] key5;
    public GameObject[] key6;
    public GameObject[] key7;
    public GameObject[] key8;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        Spawn();    // 화살표 오브젝트 생성 함수 호출
    }

    private void Spawn()    // 화살표 생성 함수
    {
        SpawnItem(key1[RandNum()], new Vector2(-7, 1)); // 화살표 오브젝트 위치(고정)
        SpawnItem(key2[RandNum()], new Vector2(-5, 1)); // 상, 하, 좌, 우, 스페이스 바 5개 중 하나 랜덤으로 지정
        SpawnItem(key3[RandNum()], new Vector2(-3, 1));
        SpawnItem(key4[RandNum()], new Vector2(-1, 1));
        SpawnItem(key5[RandNum()], new Vector2(1, 1));
        SpawnItem(key6[RandNum()], new Vector2(3, 1));
        SpawnItem(key7[RandNum()], new Vector2(5, 1));
        SpawnItem(key8[RandNum()], new Vector2(7, 1));
    }

    private void SpawnItem(GameObject keys, Vector2 pos)    // 위치 설정
    {
        GameObject key = Instantiate(keys);
        key.transform.position = pos;
    }

    private int RandNum()   // 5개(상, 하, 좌, 우, 스페이스바) 중 하나 랜덤으로...
    {
        i = Random.Range(0, 5);
        return i;
    }

    private void OnTriggerExit2D(Collider2D collision)  // 오브젝트들 위 collider를 벗어나면(처음으로 플레이어가 돌아가면)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spawn();    // 화살표 오브젝트 8개 재생성
        }
    }
}
