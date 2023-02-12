using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Data
{
    public float spawnTime;
    public int spriteType;
    public int helath;
    public float speed;
}

[System.Serializable]
public class EnemyData
{
    public string discription;
    public Data Data;
}

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Object/EnemyData", order =int.MaxValue)]
public class CharacterData : ScriptableObject
{
    public EnemyData[] EnemyDatas;
}
