using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class InsertarMoneda : MonoBehaviour
    {
        public TextMeshProUGUI textoMoneda1;
        public TextMeshProUGUI textoMoneda2;
        public GameObject menuSeleccion;

        public bool limiteMonedas;

        [SerializeField]
        private InputActionReference moneda;

        [SerializeField] private InputActionReference playerSelection;
        [SerializeField] private GameObject noImplementado;

        private void OnEnable()
        {
            moneda.action.performed += SumarMoneda;
            playerSelection.action.performed += PlayerSelection;
        }

        private void OnDisable()
        {
            moneda.action.performed -= SumarMoneda;
            playerSelection.action.performed -= PlayerSelection;
        }

        private void SumarMoneda(InputAction.CallbackContext context)
        {
            // Detectar si se presiona la barra espaciadora
            if (!limiteMonedas/* && Input.GetKeyDown(KeyCode.Space)*/)
            {

                if (GameManager.instance.monedas < 2)
                {
                    // Llamar al método AgregarMonedas del GameManager para agregar una moneda
                    GameManager.instance.AgregarMonedas(1);
                }

                // Para que pare una vez tenga 2 monedas y aunque siga pulsando espacio no siga sumando monedas
                if (GameManager.instance.monedas >= 2)
                {
                    limiteMonedas = true;
                }

            }
        }

        private void Update()
        {

            
            if (GameManager.instance.monedas > 0)
            {
                textoMoneda1.fontSize = 24;
                textoMoneda2.fontSize = 24;
                textoMoneda1.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa boton 1P para continuar.";
                textoMoneda2.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa boton 1P para continuar.";
            }

            if (GameManager.instance.monedas >= 2)
            {
                textoMoneda1.gameObject.SetActive(false);
                textoMoneda2.gameObject.SetActive(false);

                menuSeleccion.SetActive(true);
            }
        }

        public void UnJugador()
        {
            GameManager.instance.njugadores = 1;
            SceneManager.LoadScene("LobbyScene");
        }

        public IEnumerator DosJugadores()
        {
            Debug.Log("Aún no está implementado.");
            noImplementado.SetActive(true);
            yield return new WaitForSeconds(2f);
            noImplementado.SetActive(false);
        }

        private void PlayerSelection(InputAction.CallbackContext context)
        {
            if (!context.ToString().Contains("Joystick  1"))
            {
                if (GameManager.instance.monedas >= 1)
                {
                    UnJugador();
                }
            } else
            {
                if (GameManager.instance.monedas >= 2)
                {
                    StartCoroutine(DosJugadores());
                }
            }
        }
    }
}
