using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //트리거 버튼 클릭
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger Clicked !!!");
        }
        //트랙패드 터치
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            //트랙패드의 터치 좌표값
            Vector2 pos = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Debug.LogFormat("Touch Position x={0}, y={1}", pos.x, pos.y);
        }
    }
}
