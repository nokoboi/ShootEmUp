using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance; // Singleton para acceder fácilmente al GameManager desde otros scripts
        public int monedas; // Variable para el recuento de monedas

        private void Awake()
        {
            // Asegurar que solo haya una instancia del GameManager en la escena
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // No destruir el objeto GameManager al cambiar de escena
            }
            else
            {
                Destroy(gameObject); // Destruir cualquier instancia adicional del GameManager
            }
        }

        // Método para agregar monedas al recuento
        public void AgregarMonedas(int cantidad)
        {
            monedas += cantidad;
            Debug.Log("Se han agregado " + cantidad + " monedas. Total de monedas: " + monedas);
        }

    }
}
