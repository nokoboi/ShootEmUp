using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour
{
    public Button[] arrayButtons;

    //public GameObject panelCreditos;


    private int indexBoton;




    private void Awake()
    {

    }
    
    private void Start()
    {
        

        indexBoton = 0;

        // Asegura de que haya al menos un botón en el arreglo

        if (arrayButtons.Length > 0)
        {
            //Debug.Log(arrayButtons.Length);
            //Debug.Log(arrayButtons[indexBoton].gameObject.GetComponentInChildren<TextMeshProUGUI>().text);
            EventSystem.current.SetSelectedGameObject(arrayButtons[indexBoton].gameObject);
        }

    }

    private void Update()
    {
        for (int i = 0; i < arrayButtons.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject == arrayButtons[i].gameObject)
            {
                indexBoton = i;

            }
        }
    }

    public void ClickOut()
    {
        EventSystem.current.SetSelectedGameObject(arrayButtons[indexBoton].gameObject);

    }

    public void ClickIn()
    {
        //Debug.Log("hola");
    }
    public void CargarNivel(int numeroNivel)
    {
        
    }
    public void Creditos()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SalirDelJuego()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            SalirDeLaAplicacion();
        #endif
    }


    private void SalirDeLaAplicacion()
    {
        // En una compilación, usar Application.Quit() para cerrar la aplicación
        Application.Quit();
    }
}
