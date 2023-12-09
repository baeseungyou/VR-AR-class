using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //사망시 재생할 오디오 클립
    public float jumpForce = 700f; //점프 힘

    int jumpCount = 0; //누적 점프 횟수 
    bool isGrounded = false; // 바닥에 닿았는지 나타냄
    bool isDead = false; //사망 상태

    Rigidbody2D playerRigidbody; //사용할 리지드바디 컴포넌트
    Animator animator; //사용할 애니메이터 컴포넌트
    AudioSource playerAudio; //사용할 오디오 소스 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead){
            return; //사망 시 처리를 더 이상 진행하지 않고 종료
        }

        //마우스 왼쪽 버튼을 눌렀으며 && 최대 점프 횟수(2)에 도달하지 않았다면
        if (Input.GetMouseButtonDown(0) && jumpCount < 2) {
            jumpCount++; //점프 횟수 증가
            playerRigidbody.velocity = Vector2.zero; //점프 직전에 속도를 순간적으로 제로로 변경
            playerRigidbody.AddForce(new Vector2(0, jumpForce)); //리지드바디 위쪽으로 힘을 주기
            playerAudio.Play(); //오디오 소스 재생 
        }
        //마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면 (위로 상승 중)
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0) {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; //현재 속도를 절반으로 변경
        }

        animator.SetBool("Grounded", isGrounded); //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
    }

    private void Die(){
        animator.SetTrigger("Die"); //애니메이터의 Die 트리거 파라미터를 셋팅

        playerAudio.clip = deathClip; //오디오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.Play(); //사망 효과음 재생

        playerRigidbody.velocity = Vector2.zero; //죽음을 제로로 변경
        isDead = true; //사망 상태를 true로 변경

        GameManager.instance.OnPlayerDead(); //게임 매니저의 게임오버 처리 실행
    }

     void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Dead" && !isDead){
            Die(); //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면 Die() 실행
        }
    }

     void OnCollisionEnter2D(Collision2D collision){
        if (collision.contacts[0].normal.y > 0.7f){
            isGrounded = true;
            jumpCount = 0; //누적 점프 횟수를 0으로 리셋
        }
     }
      void OnCollisionExit2D(Collision2D collision) {
        isGrounded = false; //어떤 콜라이더에서 떼어진 경우 isGrounded를 false로 변경
     }
}
