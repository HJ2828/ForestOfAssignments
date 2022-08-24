using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour     // ȭ��ǥ ������Ʈ �������� �ڵ�
{
    Rigidbody2D rigid;
    public GameObject[] key1;   // ù��° ȭ��ǥ ������Ʈ ���� 8��° ����
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
        Spawn();    // ȭ��ǥ ������Ʈ ���� �Լ� ȣ��
    }

    private void Spawn()    // ȭ��ǥ ���� �Լ�
    {
        SpawnItem(key1[RandNum()], new Vector2(-7, 1)); // ȭ��ǥ ������Ʈ ��ġ(����)
        SpawnItem(key2[RandNum()], new Vector2(-5, 1)); // ��, ��, ��, ��, �����̽� �� 5�� �� �ϳ� �������� ����
        SpawnItem(key3[RandNum()], new Vector2(-3, 1));
        SpawnItem(key4[RandNum()], new Vector2(-1, 1));
        SpawnItem(key5[RandNum()], new Vector2(1, 1));
        SpawnItem(key6[RandNum()], new Vector2(3, 1));
        SpawnItem(key7[RandNum()], new Vector2(5, 1));
        SpawnItem(key8[RandNum()], new Vector2(7, 1));
    }

    private void SpawnItem(GameObject keys, Vector2 pos)    // ��ġ ����
    {
        GameObject key = Instantiate(keys);
        key.transform.position = pos;
    }

    private int RandNum()   // 5��(��, ��, ��, ��, �����̽���) �� �ϳ� ��������...
    {
        i = Random.Range(0, 5);
        return i;
    }

    private void OnTriggerExit2D(Collider2D collision)  // ������Ʈ�� �� collider�� �����(ó������ �÷��̾ ���ư���)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spawn();    // ȭ��ǥ ������Ʈ 8�� �����
        }
    }
}
