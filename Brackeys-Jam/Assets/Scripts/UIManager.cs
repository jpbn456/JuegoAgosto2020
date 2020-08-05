using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] pestanias;
    public GameObject[] paneles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void LikeODislike(int estado)//-1 para dislike 1 para like
    {
        if(GameManager.cuentaActiva == null)
        {
            AbrirPanel(0);
        }
        else
        {

        }
    }
}
