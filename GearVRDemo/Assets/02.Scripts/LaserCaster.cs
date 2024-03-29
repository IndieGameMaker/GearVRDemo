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
    //포인터 프리팹을 로드
    private GameObject pointerPrefab;
    //동적으로 생성해서 라인렌더러 끝에 위치시킬 객체
    private GameObject pointer;
    //Raycast 충돌한 지점의 정보를 반환할 구조체(Structure)
    private RaycastHit hit;

    void Start()
    {
        tr = GetComponent<Transform>();
        //프로젝트 뷰의 Resources 폴더에 있는 Line 에셋을 로드.
        mt = Resources.Load<Material>("Line");
        pointerPrefab = Resources.Load<GameObject>("Pointer");
        CreateLine();
    }

    void Update()
    {
        // (광선의 발사원점, 발사방향, 결괏값, 거리)
        if (Physics.Raycast(tr.position, tr.forward, out hit, range))
        {
            //라인렌더러의 끝좌표를 보정
            lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
            //포인터의 끝좌표를 보정
            pointer.transform.localPosition = tr.localPosition 
                                            - Vector3.forward * 0.1f
                                            + new Vector3(0, 0, hit.distance);
            //포인터의 각도 수정
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            pointer.transform.localPosition = tr.localPosition + new Vector3(0, 0, range);
            pointer.transform.LookAt(tr.position - pointer.transform.position);
        }
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

        //포인터 생성
        pointer = Instantiate(pointerPrefab
                            , transform.position + lineRenderer.GetPosition(1)
                            , Quaternion.identity
                            , transform);
    }
}
