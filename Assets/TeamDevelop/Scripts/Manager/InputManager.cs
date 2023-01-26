using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------		
    public float xMove { get; private set; }
    public float yMove { get; private set; }





    //--------------------------------------------------------					
    // ���� �ʵ� ����					
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
