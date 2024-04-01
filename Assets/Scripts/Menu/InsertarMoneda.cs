using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shmup
{
    public class InsertarMoneda : MonoBehaviour
    {
        public TextMeshProUGUI textoMoneda1;
        public TextMeshProUGUI textoMoneda2;
        private void Update()
        {
            // Detectar si se presiona la barra espaciadora
            if (Input.GetKeyDown(KeyCode.Space))
            {

                // Llamar al método AgregarMonedas del GameManager para agregar una moneda
                GameManager.instance.AgregarMonedas(1);

            }
            if (GameManager.instance.monedas > 0)
            {
                textoMoneda1.fontSize = 24;
                textoMoneda2.fontSize = 24;
                textoMoneda1.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa cualquier boton para continuar.";
                textoMoneda2.text = "Tienes " + GameManager.instance.monedas + " monedas. Pulsa cualquier boton para continuar.";
            }
        }
    }
}
