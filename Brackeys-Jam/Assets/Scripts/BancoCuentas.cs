using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BancoCuentas : MonoBehaviour
{
    public List<Cuenta> cuentas;
    public InputField usuario;
    public InputField contrasenia;

    public InputField usuarioLogIn;
    public InputField contraseniaLogIn;
    public GameObject avisoYaExistente;

    public GameObject logIn;
    public GameObject panelLogIn;
    public GameObject logOut;
    public Text nombreCuentaActiva;

    public Button likeButton;
    public Button dislikeButton;
    /*
    ColorBlock cb = b.colors;
    cb.normalColor = Color.white;
    b.colors = cb;
    */

    bool yaExiste = false;
    EventSystem system;
    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.TabPressed)
        {
            CambiarDeCampo();
        }
    }
    
    public void AgregarCuenta()
    {
        if (!yaExiste && EspaciosCompletos())
        {
            Cuenta cuentaNueva = new Cuenta();
            cuentaNueva.nombreUsuario = usuario.text;
            cuentaNueva.contrasenia = contrasenia.text;
            cuentaNueva.estadoBoton = 0;
            cuentas.Add(cuentaNueva);
            usuario.text = "";
            contrasenia.text = "";
        }
    }
    public void IniciarSesion()
    {
        bool usuarioExiste = false;
        bool contraseniaCorrecta = false;
        int i = 0;
        while(i< cuentas.Count && !usuarioExiste)
        {
            if(cuentas[i].nombreUsuario == usuarioLogIn.text)
            {
                usuarioExiste = true;
            }
            else i++;
        }
        i = 0;
        while (i<cuentas.Count && usuarioExiste && !contraseniaCorrecta)
        {
            if(cuentas[i].contrasenia == contraseniaLogIn.text)
            {
                contraseniaCorrecta = true;
            }
            else i++;
        }
        if(usuarioExiste && contraseniaCorrecta)
        {
            GameManager.cuentaActiva = cuentas[i];
            logOut.SetActive(true);
            nombreCuentaActiva.text = GameManager.cuentaActiva.nombreUsuario;
            usuarioLogIn.text = "";
            contraseniaLogIn.text = "";
            logIn.SetActive(false);
            InicializarBotonesLike();

        }
        else
        {
            //Mostrar Warning
            Debug.Log("datos incorrectos");
        }
    }
    public void CerrarSesion()
    {
        GameManager.cuentaActiva = null;
        logOut.SetActive(false);
        logIn.SetActive(true);
        panelLogIn.SetActive(false);
        CambiarColoresBotones(Color.white,Color.white);
    }
    bool EspaciosCompletos()
    {
        return (!(usuario.text == ""||contrasenia.text==""));
    }
    public void YaExistente()
    {
        int i = 0;
        while (i<cuentas.Count && !yaExiste )
        {
            if(usuario.text == cuentas[i].nombreUsuario)
            {
               
                yaExiste = true;
            }
            i++;
        }
        
        if (yaExiste)
        {
            avisoYaExistente.SetActive(true);
        }
        else
        {
            avisoYaExistente.SetActive(false);
        }
    }
    public void Editando()
    {
        yaExiste = false;
    }
    void CambiarDeCampo()
    {
        Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

        if (next != null)
        {

            InputField inputfield = next.GetComponent<InputField>();
            if (inputfield != null)
            {
                inputfield.OnPointerClick(new PointerEventData(system));  //if it's an input field, also set the text caret
            }
            system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
        }
        //else Debug.Log("next nagivation element not found");
    }
    public void AbrirPanelLogIn()
    {
        panelLogIn.SetActive(true);
    }
    public void AbrirOCerrarPanel()
    {
        panelLogIn.SetActive(!panelLogIn.activeSelf);
    }
    void InicializarBotonesLike()
    {
        if(GameManager.cuentaActiva.estadoBoton == 0)
        {
            CambiarColoresBotones(Color.white, Color.white);
        }
        else if(GameManager.cuentaActiva.estadoBoton == 1)
        {
            CambiarColoresBotones(Color.blue, Color.white);
        }
        else if(GameManager.cuentaActiva.estadoBoton == -1)
        {
            CambiarColoresBotones(Color.white, Color.blue);
        }
    }
    public void LikeODislike(int estado)//-1 para dislike 1 para like
    {
        if (GameManager.cuentaActiva == null)
        {
            AbrirPanelLogIn();
        }
        else
        {
            if(estado == GameManager.cuentaActiva.estadoBoton)
            {
                CambiarColoresBotones(Color.white, Color.white);
                cuentas[EncontrarCuentaActiva()].estadoBoton = 0;
                GameManager.cuentaActiva.estadoBoton = 0;
            }
            else
            {
                if(estado == -1)
                {
                    CambiarColoresBotones(Color.white,Color.blue);
                    cuentas[EncontrarCuentaActiva()].estadoBoton = -1;
                    GameManager.cuentaActiva.estadoBoton = -1;
                }
                else if (estado == 1)
                {
                    CambiarColoresBotones(Color.blue,Color.white);
                    cuentas[EncontrarCuentaActiva()].estadoBoton = 1;
                    GameManager.cuentaActiva.estadoBoton = 1;
                }
            }
            GameManager.cantidadDislikes = ContarDislike();
        }
    }
    int ContarDislike()
    {
        int j = 0;
        for (int i = 0; i < cuentas.Count; i++)
        {
            if (cuentas[i].estadoBoton == -1) j++;
        }
        return j;
    }
    int EncontrarCuentaActiva()
    {
        bool encontrado = false;
        int i = 0;
        while(i < cuentas.Count && !encontrado)
        {
            if(GameManager.cuentaActiva == cuentas[i])
            {
                encontrado = true;
            }
            else
            {
                i++;
            }
        }
        return i;
        
    }
    void CambiarColoresBotones(Color colorLike, Color colorDislike)
    {
        ColorBlock cb = likeButton.colors;
        cb.normalColor = colorLike;
        cb.highlightedColor = colorLike;
        likeButton.colors = cb;
        //
        cb = dislikeButton.colors;
        cb.normalColor = colorDislike;
        cb.highlightedColor = colorDislike;
        dislikeButton.colors = cb;
    }
}
