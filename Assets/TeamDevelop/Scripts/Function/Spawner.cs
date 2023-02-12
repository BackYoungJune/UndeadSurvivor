using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //--------------------------------------------------------					
    // �ܺ� ���� �Լ� & ������Ƽ					
    //--------------------------------------------------------		

    public Transform[] spawnPoints;
    public GameObject prefabs;
    public CharacterData characterData;

    //--------------------------------------------------------					
    // ���� �ʵ� ����					
    //--------------------------------------------------------	
    private float timer = 0;
    private int level;
    private float spawnTime;

    void Update()
    {
        timer += Time.deltaTime;
        level = Managers.Game.level;
        spawnTime = characterData.EnemyDatas[level].Data.spawnTime;

        if (timer > spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        //int num = Random.Range(0, 2);
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject obj = Managers.IPool.Get(prefabs, parent: spawnPoints[spawnPoint]);
        obj.GetComponent<Enemy>().SetData(characterData.EnemyDatas[level]);
        obj.GetComponent<Enemy>().Init();
    }
}
