using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool MouseClicked = false;
    public static bool KeyPressed = false;
    public static bool TabPressed = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseClicked = true;
        }
        else
        {
            MouseClicked = false;
        }
        if(!MouseClicked && Input.anyKeyDown)
        {
            KeyPressed = true;
        }
        if (!Input.anyKeyDown)
        {
            KeyPressed = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            TabPressed = true;
        }
        else
        {
            TabPressed = false;
        }
    }
}
