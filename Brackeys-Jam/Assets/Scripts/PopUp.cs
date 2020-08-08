using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public AudioSource sonido;
    public GameObject[] popUpsGO;
    int popUpActivos;
    bool inicializado = false;
    void Start()
    {
        
    }
    void Update()
    {
        if (inicializado)
        {
            if(ContarPopUpsCerrados() == popUpsGO.Length)
            {
                inicializado = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    private void OnEnable()
    {
        StartCoroutine("InicializarJuego");
    }
    public void CerrarPopUp(int posicionPopUp)
    {
        popUpsGO[posicionPopUp].SetActive(false);
    }
    IEnumerator InicializarJuego()
    {
        popUpActivos = Random.Range(1, popUpsGO.Length);

        for (int i = 0; i < popUpActivos; i++)
        {
            popUpsGO[i].SetActive(true);
            sonido.Play();
            yield return new WaitForSeconds(.1f);
        }
        inicializado = true;
        
    }
    int ContarPopUpsCerrados()
    {
        int cant = 0;
        for (int i = 0; i < popUpsGO.Length; i++)
        {
            if (!popUpsGO[i].activeSelf) cant++;
        }
        return cant;
    }
}
