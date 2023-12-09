using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
     public GameObject PickUpPrefab; // 코인 프리팹
    public float spawnInterval = 0.5f; // 코인 생성 간격 (초)
    private float timer; // 경과 시간 저장 변수

    void Start()
    {
        timer = 0f; // 타이머 초기화
    }

    void Update()
    {
        timer += Time.deltaTime; // 경과 시간 누적

        // 일정 시간 간격으로 코인 생성
        if (timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f; // 타이머 재설정
        }
    }

    void SpawnCoin()
    {
        // 코인을 생성할 위치를 무작위로 결정
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));

        // 코인을 생성
        Instantiate(PickUpPrefab, spawnPosition, Quaternion.identity);
    }
}