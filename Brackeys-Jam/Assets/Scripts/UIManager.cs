using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] pestanias;
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
}
