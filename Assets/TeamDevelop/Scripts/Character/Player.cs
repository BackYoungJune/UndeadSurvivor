using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		




    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();    
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();


    }

    void Move()
    {
        Vector2 input = new Vector2(Managers.Input.xMove, Managers.Input.yMove);
        if (input.magnitude < Mathf.Epsilon) return;


    }
}
