using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); //게임 오브젝트에서 리지드바디 컴포넌트 찾아 할당
        bulletRigidbody.velocity = transform.forward * speed; //리지드바디 속도 = 앞쪽 방향 * 속력
        
        Destroy(gameObject, 3f); //3초 후에 자신의 게임 오브젝트 파괴
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //트리거 충돌 시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player") { //충돌한 게임 오브젝트가 Player 태그를 가진 경우
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null) { //PlayerController 가져오는 데 성공했다면,
                playerController.Die(); //PlayerController 컴포넌트의 Die() 메서드 실행
            }
        }
    }
}
