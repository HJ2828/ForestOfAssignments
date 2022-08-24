using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour   // 3�ܰ��� ī�޶� �ڵ�
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");    // �÷��̾ �������� �ϱ� ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; // �÷��̾��� �̵� ��ġ�� ī�޶� ��ġ�� �ϱ� ����

        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);   // ī�޶� ��ġ
    }
}
