using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transicion : MonoBehaviour
{
    public Image panel;

    float valor = 1;
    float speed = 3f;
    void Start()
    {
        valor = 1;
    }

    void Update()
    {
        valor -= Time.deltaTime * speed;
        Mathf.Clamp(valor, 0, 1);
        Color color = panel.color;
        color.a = valor;
        panel.color = color;
        if(valor<= 0.1f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
