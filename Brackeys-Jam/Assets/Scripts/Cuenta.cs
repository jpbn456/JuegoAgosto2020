using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Cuenta
{
    public string nombreUsuario;
    public string contrasenia;
    //0 nomral, -1 dislike, 1 like
    public int estadoBoton = 0;
}
