﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCaster : MonoBehaviour
{
    //동적으로 생성할 라인렌더러 컴포넌트를 저장할 변수
    private LineRenderer lineRenderer;
    private Transform tr;

    //레이저의 거리
    public float range = 10.0f;
    //
    public Color defaultColor = Color.white;
    //머티리얼 로드
    private Material mt;

    void Start()
    {
        //프로젝트 뷰의 Resources 폴더에 있는 Line 에셋을 로드.
        mt = Resources.Load<Material>("Line");
        CreateLine();
    }

    //라인렌더러를 생성하는 함수
    void CreateLine()
    {
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        //속성을 설정
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.SetPosition(1, new Vector3(0, 0, range));
        //머티리얼을 생성해서 대입
        // Material mt = new Material(Shader.Find("Unlit/Color"));
        // mt.color = defaultColor;
        lineRenderer.sharedMaterial = mt;
    }
}
