using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){ //왼쪽 화살표가 눌렸을 때 왼쪽으로 1 이동
            transform.Translate(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){ // 오른쪽 화살표가 눌렸을 때 오른쪽으로 1 이동
            transform.Translate(1, 0, 0);
        }
    }

    public void LButtonDown(){
        transform.Translate(-1, 0, 0); //왼쪽으로 1 이동
    }
    public void RButtonDown(){
        transform.Translate(1, 0, 0); //오른쪽으로 1 이동
    }
}
