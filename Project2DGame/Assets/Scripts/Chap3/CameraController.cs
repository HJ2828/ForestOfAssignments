using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour   // 3단계의 카메라 코드
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");    // 플레이어를 고정으로 하기 위해
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; // 플레이어의 이동 위치를 카메라 위치로 하기 위함

        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);   // 카메라 위치
    }
}
