using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class InsertarMoneda : MonoBehaviour
    {
        public TextMeshProUGUI textoMoneda1;
        public TextMeshProUGUI textoMoneda2;
        public GameObject menuSeleccion;

        public bool limiteMonedas;
        private void Update()
        {
            // Detectar si se presiona la barra espaciadora
            if (!limiteMonedas && Input.GetKeyDown(KeyCode.Space))
            {

                if(GameManager.instance.monedas < 3)
                {
                    // Llamar al método AgregarMonedas del GameManager para agregar una moneda
                    GameManager.instance.AgregarMonedas(1);
                }

                // Para que pare una vez tenga 3 monedas y aunque siga pulsando espacio no siga sumando monedas
                if (GameManager.instance.monedas >= 3)
                {
                    limiteMonedas = true;
                }

            }
            if (GameManager.instance.monedas > 0)
            {
                textoMoneda1.fontSize = 24;
                textoMoneda2.fontSize = 24;
                textoMoneda1.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa cualquier boton para continuar.";
                textoMoneda2.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa cualquier boton para continuar.";
            }

            if (GameManager.instance.monedas >= 3)
            {
                textoMoneda1.gameObject.SetActive(false);
                textoMoneda2.gameObject.SetActive(false);

                menuSeleccion.SetActive(true);
            }
        }

        public void UnJugador()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
