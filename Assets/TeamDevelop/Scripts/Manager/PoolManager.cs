using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹을 보관할 변수
    public GameObject[] prefabs;

    // 풀 담당을 하는 리스트들
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

        // 선택한 풀의 게임오브젝트 접근
            
        foreach(var item in pools[index])
        {
            if(!item.activeSelf)
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못찾았으면
        if(select == null)
        {
            // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], parent);
            pools[index].Add(select);
        }

        return select;
    }
}
