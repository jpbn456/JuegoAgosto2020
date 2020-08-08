using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerGame : MonoBehaviour
{
    public AudioSource sonido;
    float puntaje = 0;
    public float puntajeBoton;
    public float defaultSpeed;
    public Image imagenBarra;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntaje += Time.deltaTime * defaultSpeed;
        puntaje = Mathf.Clamp(puntaje, 0, 1);
        imagenBarra.fillAmount = puntaje;
        if(puntaje >= 1)
        {
            this.gameObject.SetActive(false);
        }

    }
    public void AgregarPuntosBoton()
    {
        puntaje += puntajeBoton;
    }
    private void OnEnable()
    {
        puntaje = 0;
        sonido.Play();
    }
}
