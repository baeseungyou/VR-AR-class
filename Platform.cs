using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; //장애물 오브젝트들
    bool stepped = false; //플레이어 캐릭터가 밟았는가

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //충돌한 상대방의 태그가 Player이고 이전에 플레이어 캐릭터가 밟지 않았다면
        if (collision.collider.tag == "Player" && !stepped){
            stepped = true; //밟힘 상태를 참으로 변경
            GameManager.instance.AddScore(1); //점수 추가
        }
    }
    //컴포넌트가 활성화될 때마다 매번 실행되는 메서드
    void OnEnable()
    {
        stepped = false; //밟힘 상태를 리셋
        for (int i = 0; i<obstacles.Length; i++) { //장애물 수만큼 루프
            if (Random.Range(0, 3) == 0) {
                obstacles[i].SetActive(true); //현재 순번의 장애물을 1/3 확률로 활성화
            }
            else {
                obstacles[i].SetActive(false);
            }
        }
    }
}
