﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject[] pestanias;
    public GameObject[] paneles;
    public GameObject[] minijuegos;
    public GameObject gameOverGO;
    public Text tiempoRestanteText;
    public Text cantidadDislikes;
    int juegoActivo = 0;
    float tiempoEntreMiniMin;
    float tiempoEntreMiniMax;
    float tiempoEntreMini;
    float timer = 0;
    private void Awake()
    {
        tiempoEntreMiniMin = PlayerPrefs.GetFloat("TiempoEntreMinijuegosMin");
        tiempoEntreMiniMax = PlayerPrefs.GetFloat("TiempoEntreMinijuegosMax");
        tiempoEntreMini = Random.Range(tiempoEntreMiniMin, tiempoEntreMiniMax);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempoRestanteText.text = "Tiempo restante" + GameManager.minutosRestantes + ":" + GameManager.segundosRestantes;
        if (GameManager.gameOver)
        {
            gameOverGO.SetActive(true);
            cantidadDislikes.text = "Cantidad dislikes: " + GameManager.cantidadDislikes;
            return;
        }
        if (!EstaActivo(juegoActivo))
        {
            timer += Time.deltaTime;
            if (timer >= tiempoEntreMini)
            {
                juegoActivo = Random.Range(0, minijuegos.Length);
                minijuegos[juegoActivo].SetActive(true);
                timer = 0;
                tiempoEntreMini = Random.Range(tiempoEntreMiniMin, tiempoEntreMiniMax);
            }
        }
        else
        {
            Debug.Log("minijuegoActivo");
        }
        
        
    }
    bool EstaActivo(int juegoActivo)
    {
        return minijuegos[juegoActivo].activeSelf;
    }

    public void CambiarPestania(int pestaniaNueva)
    {
        for (int i = 0; i < pestanias.Length; i++)
        {
            if( i != pestaniaNueva)
            {
                pestanias[i].SetActive(false);
            }
            else
            {
                pestanias[i].SetActive(true);
            }
        }
    }
    public void AbrirPanel(int panel)
    {
        paneles[panel].SetActive(true);
    }
    public void AbrirOCerrarPanel(int panel)
    {
        paneles[panel].SetActive(!paneles[panel].activeSelf);
    }
    public void CargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

}
