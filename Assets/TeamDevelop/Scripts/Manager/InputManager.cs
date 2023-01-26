using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		
    public float xMove { get; private set; }
    public float yMove { get; private set; }





    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    private string xAxisName = "Horizontal";
    private string yAxisName = "Vertical";



    void Update()
    {
        if (Input.anyKey == false) return;

        xMove = Input.GetAxis(xAxisName);
        yMove = Input.GetAxis(yAxisName);

    }
}
