using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoop : MonoBehaviour
{
    float width; //배경의 가로 길이

    void Awake(){
        // BoxCollider2D 컴포넌트의 Size 필드의 x값을 가로 길이로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //현재 위치가 원점에서 왼쪽으로 width 이상 이동했을 때, 위치를 재배치함.
        if (transform.position.x <= -width){
            Reposition();
        }
    }

    void Reposition(){
        //현재 위치에서 오른쪽으로 가로 길이 x2만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0f);
        transform.position = (Vector2)transform.position + offset;
    }
}
