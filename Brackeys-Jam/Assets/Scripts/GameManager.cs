﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Cuenta cuentaActiva;
    public static int pestaniaActiva;
    public static int cantidadLikes;
    public static int cantidadDislikes;
    public static float tiempoMax;
    public static float tiempoActual = 0;
    public static bool gameOver = false;
    public static int minutosRestantes=0;
    public static int segundosRestantes = 0;
    private void Awake()
    {
        tiempoMax = PlayerPrefs.GetFloat("TiempoPartida") * 60;
    }
    private void Update()
    {
        minutosRestantes = ((int)((tiempoMax - tiempoActual)/60)) % 1;
        segundosRestantes = (int)((tiempoMax - tiempoActual) - (minutosRestantes * 60));
        if(tiempoActual < tiempoMax)
        {
            tiempoActual += Time.deltaTime;
        }
        else
        {
            gameOver = true;
        }
        
        
    }


}
