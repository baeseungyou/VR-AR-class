using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target; //카메라가 따라갈 대상
    public float moveSpeed; //카메라가 얼마나 빠른 속도로
    private Vector3 targetPosition; //대상의 현재 위치 값
    public BoxCollider2D bound;

    private Vector3 minBound;
    private Vector3 maxBound;

    //박스 콜라이더 영역의 최소 최대 xyz값을 지님

    private Camera theCamera; //카메라의 반높이값을 구할 속성을 이용하기 위한 변수

    private float halfWidth;
    private float halfHeight; //카메라의 반너비, 반높이 값을 지닐 변수
    
    // Start is called before the first frame update
    void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min;
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
void Update()
{
    if(target != null)
    {
        targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

        // 부드러운 이동을 위한 Lerp 사용
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 바운딩 처리
        float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    }
}

}