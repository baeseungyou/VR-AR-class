using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    Vector2 startPos;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //스와이프 길이 계산
        if (Input.GetMouseButtonDown(0)) { //마우스를 클릭하면
            this.startPos = Input.mousePosition; //마우스를 클릭한 좌표
        }
        else if (Input.GetMouseButtonUp(0)) {
            Vector2 endPos = Input.mousePosition; //마우스에서 손가락을 떼었을 때 좌표
            float swipeLength = endPos.x - this.startPos.x;

            this.speed = swipeLength / 500.0f; //스와이프 길이로 처음 속도를 결정
            if (this.speed > 0)
             audio.Play();
        }

        transform.Translate(this.speed, 0, 0); //이동
        this.speed *= 0.98f; //감속
    }
    public void Restart(){
    transform.position = new Vector3(-7, -3.7f, 0); //초기 위치
  }
}
