using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Managers
{
    public static InputManager Input
    {
        get
        {
            if (input == null) input = GameObject.FindObjectOfType<InputManager>();
            return input;
        }
    }
    private static InputManager input;

    public static GameManager Game
    {
        get
        {
            if(game == null) game = GameObject.FindObjectOfType<GameManager>();
            return game;
        }
    }
    private static GameManager game;

    public static PoolManager Pool
    {
        get
        {
            if(pool == null) pool = GameObject.FindObjectOfType<PoolManager>();
            return pool;
        }
    }
    private static PoolManager pool;

    public static IPoolManager IPool
    {
        get
        {
            if(ipool == null) ipool = GameObject.FindObjectOfType<IPoolManager>();
            return ipool;
        }
    }
    private static IPoolManager ipool;
}
