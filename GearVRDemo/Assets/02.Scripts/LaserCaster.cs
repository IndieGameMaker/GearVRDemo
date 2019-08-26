using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    //동적으로 생성할 라인렌더러 컴포넌트를 저장할 변수
    private LineRenderer lineRenderer;
    private Transform tr;

    //레이저의 거리
    public float range = 10.0f;

    void Start()
    {
        CreateLine();
    }

    //라인렌더러를 생성하는 함수
    void CreateLine()
    {
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        //속성을 설정
        lineRenderer.useWorldSpace = false;
    }
}
