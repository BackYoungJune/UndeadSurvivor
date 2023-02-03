using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �������� ������ ����
    public GameObject[] prefabs;

    // Ǯ ����� �ϴ� ����Ʈ��
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for(int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index, Transform parent = null)
     {
        GameObject select = null;

        // ������ Ǯ�� ���ӿ�����Ʈ ����
            
        foreach(var item in pools[index])
        {
            if(!item.activeSelf)
            {
                // �߰��ϸ� select ������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // ��ã������
        if(select == null)
        {
            // ���Ӱ� �����ϰ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], parent);
            pools[index].Add(select);
        }

        return select;
    }
}
