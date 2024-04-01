using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Shmup
{
    public class CambiarColorTexto : MonoBehaviour
    {
        public TextMeshProUGUI texto; // Si estás utilizando TextMeshPro
                                       //private Text texto; // Si estás utilizando Text estándar de Unity

        private void Start()
        {
            // Obtener el componente TextMeshPro o Text
            texto = GetComponent<TextMeshProUGUI>(); // Si estás utilizando TextMeshPro
                                                     //texto = GetComponent<Text>(); // Si estás utilizando Text estándar de Unity

            // Comenzar la corutina para cambiar el color del texto
            StartCoroutine(CambiarColorCadaXSegundos(0.3f));
        }

        private IEnumerator CambiarColorCadaXSegundos(float tiempo)
        {
            while (true)
            {
                // Cambiar el color del texto a amarillo
                texto.color = Color.yellow;

                // Esperar un segundo
                yield return new WaitForSeconds(tiempo);

                // Cambiar el color del texto a blanco
                texto.color = Color.white;

                // Esperar otro segundo
                yield return new WaitForSeconds(tiempo);
            }
        }
    }
}
