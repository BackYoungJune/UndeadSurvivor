using UnityEngine;
using UnityEngine.Pool;

public class IPoolManager : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------	
    public void Get(Enemy _createEnemy, Transform parent = null)
    {
        parentTranform = parent;
        createEnemy = _createEnemy;
        enemyPool.Get();
    }

    public Enemy[] prefabs;
    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    public IObjectPool<Enemy> enemyPool;
    private Enemy createEnemy;
    private Transform parentTranform = null;

    void Awake()
    {
        enemyPool = new ObjectPool<Enemy>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, OnDestroyEnemy, maxSize: 20);    
    }

    Enemy CreateEnemy()
    {
        Enemy obj = Instantiate(createEnemy, parentTranform);
        obj.SetManagedPool(enemyPool);
        obj.EnemyInit();

        return obj;
    }

    void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.EnemyInit();
    }

    void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    void OnDestroyEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }

}
