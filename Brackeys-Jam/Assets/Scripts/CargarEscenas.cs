using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargarEscenas : MonoBehaviour
{
    public Image panel;
    float valor = 0;
    float speed = 5;
    string escenaACargar;
    public void CargarEscenaDefault(string escena)
    {
        //valor = 0;
        escenaACargar = escena;
        StartCoroutine("TransicionSalida");
        
    }
    IEnumerator TransicionSalida()
    {
        while(valor <= 0.9f)
        {
            valor += Time.deltaTime * speed;
            Mathf.Clamp(valor, 0, 1);
            Color color = panel.color;
            color.a = valor;
            panel.color = color;
            yield return new WaitForSeconds(0.01f);
        }

        SceneManager.LoadScene(escenaACargar);

    }
}
