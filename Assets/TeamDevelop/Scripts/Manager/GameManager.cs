using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;

    public float gameTime;
    public float maxGameTime = 2 * 10f;
    public int level = 0;
    public int MaxLevel = 4;

    void Update()
    {
        gameTime += Time.deltaTime;
        
        if(gameTime > maxGameTime)
        {
            gameTime = 0;
            level++;

            if(level > MaxLevel)
            {
                level = 0;
            }
        }
    }
}
