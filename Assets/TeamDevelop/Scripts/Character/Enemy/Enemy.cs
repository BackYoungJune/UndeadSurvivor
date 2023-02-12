using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, PoolInterface<GameObject>
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		
    public void SetManagedPool(IObjectPool<GameObject> pool, Transform parent = null)
    {
        Managedpool = pool;
    }

    public void DestroyPool()
    {
        if(this != null)
        {
            Managedpool.Release(this.gameObject);
        }
    }

    public void Init()
    {
        if (animator == null || rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
            animator = spriteRenderer.GetComponent<Animator>();
        }

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
        animator.runtimeAnimatorController = animatorController[enemyData.Data.spriteType];
        speed = enemyData.Data.speed;
        maxHealth = health = enemyData.Data.helath;
    }

    public void SetData(EnemyData data)
    {
        enemyData = null;
        enemyData = data;
    }

    public RuntimeAnimatorController[] animatorController;
    public float health;
    public float maxHealth;

    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    [SerializeField, Range(0, 6f)] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private bool isLive;
    private Rigidbody2D target;
    private IObjectPool<GameObject> Managedpool;
    private Animator animator;
    private EnemyData enemyData;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = spriteRenderer.GetComponent<Animator>();
    }

    void OnEnable()
    {
        isLive = true;
        health = maxHealth;
        target = Managers.Game.Player.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isLive) return;
        Vector2 dirVec = target.position - rigid.position;
        Vector3 playerDir = target.transform.position - transform.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;

        // 랜덤한 위치를 잡는다(원 기준)
        Vector3 RadiusPoint = Random.onUnitSphere;
        RadiusPoint.z = 0;
        Vector3 desPos = target.transform.position + RadiusPoint * 10.0f;

        float distance = Vector3.Distance(target.transform.position, transform.position);
        if(distance > 15.0f)
        {
            transform.position = desPos;
        }
    }

    void LateUpdate()
    {
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            health -= collision.GetComponent<Bullet>().damage;

            // Live
            if (health > 0)
            {

            }
            else
            {
                Dead();
            }
        }
    }

    void Dead()
    {
        DestroyPool();
    }


}
