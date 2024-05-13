using Shmup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public GameObject panel1Jugador;
    public GameObject panel2Jugadores;
    public Image imagenAvion;
    private int currentIndex = 0; // Índice actual en el array de sprites
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.njugadores == 1)
        {
            panel1Jugador.SetActive(true);
            panel2Jugadores.SetActive(false);
        } else if (GameManager.instance.njugadores == 2)
        {
            panel1Jugador.SetActive(false);
            panel2Jugadores.SetActive(true);
        }
        imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveNext()
    {
        // Incrementa el índice y si es igual al tamaño del array, vuelve a 0
        currentIndex = (currentIndex + 1) % GameManager.instance.spriteJugador.Length;
        imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex]; // Actualiza el sprite mostrado
    }

    public void MovePrevious()
    {
        // Decrementa el índice y si es menor a 0, establece al último sprite del array
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = GameManager.instance.spriteJugador.Length - 1;
        }
        imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex]; // Actualiza el sprite mostrado
    }
    public void Level1Scene()
    {
        GameManager.instance.naveElegida = currentIndex;
        GameManager.instance.partidaIniciada = true;
        SceneManager.LoadScene("Level1");
    }
}
