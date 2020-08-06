using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
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
                this.gameObject.SetActive(false);
                inicializado = false;
            }
        }
    }
    private void OnEnable()
    {
        popUpActivos = Random.Range(1, popUpsGO.Length);
        
        for (int i = 0; i < popUpActivos; i++)
        {
            popUpsGO[i].SetActive(true);
        }
        inicializado = true;
    }
    public void CerrarPopUp(int posicionPopUp)
    {
        popUpsGO[posicionPopUp].SetActive(false);
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
