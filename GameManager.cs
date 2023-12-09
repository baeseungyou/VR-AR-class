using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//게임 오버 상태를 표현하고, 게임 점수와 UI를 관리하는 게임 매니저
//씬에는 단 하나의 게임 매니저만 존재할 수 있음.

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //싱글톤을 할당할 전역 변수

    public bool isGameover = false; //게임 오버 상태
    public Text scoreText; //점수를 출력할 UI 텍스트
    public GameObject gameoverUI; //게임 오버시 활성화 할 UI 게임 오브젝트

    int score = 0; //게임 점수

    //게임 시작과 동시에 싱글톤을 구성
    void Awake(){
        if (instance == null){
            instance = this; //싱글톤 변수 instance가 비어있다면 (null) 그곳에 자기 자신을 할당
        }
        else {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!"); //씬에 두 개 이상의 게임 매니저 오브젝트가 존재한다는 의미
            Destroy(gameObject); //싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0)) { // 게임 오버 상태에서 마우스 왼쪽 버튼을 클릭하면
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 씬 재시작
        }
    }

    public void AddScore(int newScore){
        if (!isGameover){
            score += newScore;
            scoreText.text = "Score : " + score; 
        }
    }

    public void OnPlayerDead(){
        isGameover = true; //현재 상태를 게임오버 상태로 변경
        gameoverUI.SetActive(true); //게임 오버 UI를 활성화
    }
}
