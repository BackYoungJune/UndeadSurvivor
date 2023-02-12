using UnityEngine;
using UnityEngine.Pool;

public class IPoolManager : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------	
    public GameObject Get(GameObject _createObject, Transform parent = null)
    {
        parentTranform = parent;
        createObject = _createObject;
        GameObject obj = objPool.Get();
        return obj;
    }

    public GameObject[] prefabs;
    //--------------------------------------------------------					
    // ���� �ʵ� ����					
    //--------------------------------------------------------	
    public IObjectPool<GameObject> objPool;
    private GameObject createObject;
    private Transform parentTranform = null;

    void Awake()
    {
        objPool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestroyObject, maxSize:100);    
    }

    GameObject CreateObject()
    {
        GameObject obj = Instantiate(createObject, parentTranform);
        obj.GetComponent<PoolInterface<GameObject>>().SetManagedPool(objPool);
        return obj;
    }

    void OnGetObject(GameObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    void OnReleaseObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    void OnDestroyObject(GameObject obj)
    {
        Destroy(obj.gameObject);
    }

}
