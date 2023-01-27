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
        xMove = Input.GetAxisRaw(xAxisName);
        yMove = Input.GetAxisRaw(yAxisName);
        if (Input.anyKeyDown == false) return;
    }
}
