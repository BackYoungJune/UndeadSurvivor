using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //--------------------------------------------------------					
    // 외부 참조 함수 & 프로퍼티					
    //--------------------------------------------------------		

    public Transform[] spawnPoints;
    public Enemy[] prefabs;


    //--------------------------------------------------------					
    // 내부 필드 변수					
    //--------------------------------------------------------	
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        //if(timer > 0.4f)
        //{
        //    timer = 0;
        //    Spawn();
        //}
        if(Input.GetKeyDown(KeyCode.K))
        {
            for(int i = 0; i < 10; i++)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        int num = Random.Range(0, 2);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        //Managers.Pool.Get(num, spawnPoints[spawnPoint]);
        Managers.IPool.Get(prefabs[num], spawnPoints[spawnPoint]);
    }
}
