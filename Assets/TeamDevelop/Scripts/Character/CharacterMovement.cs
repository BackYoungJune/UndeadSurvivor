using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------		
    
    
    public Player Player;
    //public float MovementSpeed { get; private set; }
    //--------------------------------------------------------					
    // ���� �ʵ� ����					
    //--------------------------------------------------------	



    [Space, Header("�÷��̾� ���� ����")]
    //[SerializeField, Range(0f, 6f)] private float moveSpeed = 6.0f;
    [SerializeField, ReadOnly] private Vector3 CurrentMovement;

    private Vector3 movementVector;
    private float acceleration = 0f;
    private float deceleration = 100.0f;
    private Vector2 lerpedInput = Vector2.zero;
    private Vector2 normalizedInput = Vector2.zero;
    private float Acceleration = 10.0f;
    private float movementSpeed;
    private float walkSpeed = 6.0f;
    //private float runSpeed = 10.0f;
    private float idleThreshold = 0.2f;

    void Awake()
    {
        Player = GetComponent<Player>();
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
        normalizedInput = input.normalized;
        movementVector = Vector2.zero;

        if (normalizedInput.magnitude < Mathf.Epsilon)
        {
            acceleration = Mathf.Lerp(acceleration, 0f,  Time.deltaTime * deceleration);
            lerpedInput = Vector2.Lerp(lerpedInput, lerpedInput * acceleration, Time.deltaTime * deceleration);
        }
        else
        {
            acceleration = Mathf.Lerp(acceleration, 1f, Time.deltaTime * Acceleration);
            lerpedInput = Vector2.ClampMagnitude(normalizedInput, acceleration);
        }

        movementVector.x = lerpedInput.x;
        movementVector.y = 0f;
        movementVector.z = lerpedInput.y;

        // ���߿�  walkSpeed�� MovementSpeed {get; set;} ���� walk run ���� �޾Ƽ� ������
        movementSpeed = walkSpeed;

        movementVector *= movementSpeed;
        if (input.magnitude < idleThreshold && Player.CurrentMovement.magnitude < idleThreshold)
        {
            movementVector = Vector3.zero;
        }
        Player.SetMovement(movementVector);
    }
}
