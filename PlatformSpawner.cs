using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab; //생성할 발판의 원본 프리팹
    public int count = 3; //생성할 발판의 개수

    public float timeBetSpawnMin = 1.25f; //다음 배치까지의 시간 간격 최솟값
    public float timeBetSpawnMax = 2.25f; //다음 배치까지 시간 간격 최대값
    float timeBetSpawn; //다음 배치까지의 시간 간격

    public float yMin = -3.5f; //배치할 위치의 최소 y값
    public float yMax = 1.5f; //배치할 위치의 최대 y값
    float xPos = 20f; //배치할 위치의 x값

    GameObject[] platforms; //미리 생성할 발판들
    int currentIndex = 0; // 사용할 현재 순번의 발판

    Vector2 poolPosition = new Vector2(0, -25); //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    float lastSpawnTime; //마지막 배치 시점

    // Start is called before the first frame update
    void Start()
    {
        platforms = new GameObject[count]; //count만큼 공간을 가지는 새로운 발판 배열 생성
        for (int i = 0; i < count; i++) {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity); //platformPrefab을 원본으로 새 발판을 poolPosition위치에 복제 생성 후 platform 배열에
        }
        lastSpawnTime = 0f; //마지막 배치 시점 초기화
        timeBetSpawn = 0f; //다음 배차까지의 시간 간격을 0으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover) {
            return; //게임 오버 상태에서는 동작하지 않음
        }

        if (Time.time >= lastSpawnTime + timeBetSpawn) {
            lastSpawnTime = Time.time; //마지막 배치 시점에서 timeBetSwan 이상 시간이 흘렀다면 기록된 마지막 배치 시점을 현재 시점으로 갱신
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); //다음 배치까지의 시간 간격을 timeBetSpawMax,Min에서
            float yPos = Random.Range(yMin, yMax); //배치할 위치의 높이를 yMin~Max에서 랜덤 설정

            //사용할 현재 순번의 발판 게임 오브젝틀르 비활성화하고 즉시 다시 활성화
            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true); //발판의 Platform 컴포넌트의 OnEnable 메서드가 실행됨

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos); //현재 순번의 발판을 오른쪽에 재배치
            currentIndex++; //순번 넘기기
            if (currentIndex >= count){
                currentIndex = 0; //마지막 순번에 도달했다면 순번을 리셋
            }
        }
    }
}
