using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValoresPrueba : MonoBehaviour
{
    public InputField tiempoPartida;
    public InputField tiempoEntreMiniMin;
    public InputField tiempoEntreMiniMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EmpezarPartida()
    {
        if(tiempoPartida.text != "")
        {
            PlayerPrefs.SetFloat("TiempoPartida", float.Parse(tiempoPartida.text));
        }
        else
        {
            PlayerPrefs.SetFloat("TiempoPartida", 3);
        }
        if(tiempoEntreMiniMin.text != "")
        {
            PlayerPrefs.SetFloat("TiempoEntreMinijuegosMin", float.Parse(tiempoEntreMiniMin.text));
        }
        else
        {
            PlayerPrefs.SetFloat("TiempoEntreMinijuegosMin", 10);
        }
        if (tiempoEntreMiniMax.text != "")
        {
            PlayerPrefs.SetFloat("TiempoEntreMinijuegosMax", float.Parse(tiempoEntreMiniMax.text));
        }
        else
        {
            PlayerPrefs.SetFloat("TiempoEntreMinijuegosMax", 15);
        }
        SceneManager.LoadScene("TitleScreen");
    }
}
