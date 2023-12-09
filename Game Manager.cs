using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 관련 라이브러리
using UnityEngine.SceneManagement; //씬 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; //게임 오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; //생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; //최고 기록을 표시할 텍스트 컴포넌트

    float surviverTime; //생존 시간
    bool isGameover; //게임오버 상태
    // Start is called before the first frame update
    void Start()
    {
        surviverTime = 0; //생존 시간 초기화
        isGameover = false; //게임오버 상태 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) { //게임오버가 아닌 동안
            surviverTime += Time.deltaTime; //생존 시간 갱신
            timeText.text = "Time: " + (int)surviverTime; // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
        }
        else {
            if (Input.GetKeyDown(KeyCode.R)) { // Game over 상태에서 R키를 누른 경우
                SceneManager.LoadScene("GameScene"); //Game Scene을 로드
            }
        }
    }

    //현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        isGameover = true; //현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true); //게임오버 텍스트 게임 오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime"); //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        if (surviverTime > bestTime) {
            bestTime = surviverTime; //이전까지의 최고 기록보다 현재 생존 시간이 더 크다면 최고 기록 값을 현재 생존 시간 값으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime); //변경된 최고 기록을 BestTime 키로 저장
        }
        recordText.text = "Best Time: " + (int)bestTime; //최고 기록을 recorText 텍스트 컴포넌트를 이용해 표시
    }
}