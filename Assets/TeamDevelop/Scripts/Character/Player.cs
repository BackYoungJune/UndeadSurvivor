using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		
    public void SetMovement(Vector3 movement)
    {
        orientedMovement = movement;
        orientedMovement.y = orientedMovement.z;
        orientedMovement.z = 0f;
        CurrentMovement = orientedMovement;
    }

    [ReadOnly] public Vector3 CurrentMovement = Vector3.zero;
    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Animator animatorBase;
    private Rigidbody2D rigidBody2D;
    private Vector3 orientedMovement = Vector3.zero;

    private int animID__MovementSpeed;
    private int animID_Dead;

    private string SpeedParameterName = "MovementSpeed";
    private string DeadParameterName = "Dead";

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        AnimatorInit();
    }

    void AnimatorInit()
    {
        animID__MovementSpeed = Animator.StringToHash(SpeedParameterName);
        animID_Dead = Animator.StringToHash(DeadParameterName);
    }

    void Update()
    {
        AnimatorUpdate();    
    }

    void FixedUpdate()
    {
        Move();
    }

    void LateUpdate()
    {
        Rotation();
    }

    void AnimatorUpdate()
    {
        Vector2 input = new Vector2(Managers.Input.xMove, Managers.Input.yMove);
        Vector2 normalInput = input.normalized;
        animatorBase.SetFloat(animID__MovementSpeed, normalInput.magnitude);
    }

    void Move()
    {
        Vector2 newMovement = rigidBody2D.position + (Vector2)CurrentMovement * Time.fixedDeltaTime;
        rigidBody2D.MovePosition(newMovement);
    }

    void Rotation()
    {
        if(Managers.Input.xMove != 0)
        {
            SpriteRenderer.flipX = Managers.Input.xMove < 0;
        }
    }
}
