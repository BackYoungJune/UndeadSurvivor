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
}
