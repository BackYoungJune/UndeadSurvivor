using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public void Init()
    {
        switch(id)
        {
            case 0:
                {
                    speed = -150;
                    Batch();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void Batch()
    {
        for (int i = 0; i < count; i++)
        {

        }
    }

    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;





    void Update()
    {
        
    }
}
