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

        public GameObject noImplementado;

        public bool limiteMonedas;

        [SerializeField]
        private InputActionReference moneda;
        [SerializeField] private InputActionReference playerSelection;

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
            // Llamar al m�todo AgregarMonedas del GameManager para agregar una moneda
            GameManager.instance.AgregarMonedas(1);
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

            if (GameManager.instance.monedas <= 0)
            {
                textoMoneda1.text = "Inserta moneda";
                textoMoneda2.text = "Inserta moneda";

                textoMoneda1.gameObject.SetActive(true);
                textoMoneda2.gameObject.SetActive(true);
            }
        }

        public void UnJugador()
        {
            menuSeleccion.SetActive(false);

            GameManager.instance.njugadores = 1;
            SceneManager.LoadScene("LobbyScene");
        }

        public void DosJugadoresMenu()
        {
            StartCoroutine(DosJugadores());
        }

        public IEnumerator DosJugadores()
        {
            Debug.Log("A�n no est� implementado.");
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
