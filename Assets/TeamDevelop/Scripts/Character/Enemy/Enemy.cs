using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------		
    public void SetManagedPool(IObjectPool<Enemy> pool, Transform parent = null)
    {
        Managedpool = pool;
    }

    //  �ӽ��ڵ�
    public void InvokeDestroyPool(float time)
    {
        Invoke("DestroyPool", time);
    }

    public void DestroyPool()
    {
        if(this != null)
        {
            Managedpool.Release(this);
        }
    }

    public void EnemyInit()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    //--------------------------------------------------------					
    // ���� �ʵ� ����					
    //--------------------------------------------------------	
    [SerializeField, Range(0, 6f)] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private bool isLive = true;
    private Rigidbody2D target;
    private IObjectPool<Enemy> Managedpool;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
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

        // ������ ��ġ�� ��´�(�� ����)
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
}
