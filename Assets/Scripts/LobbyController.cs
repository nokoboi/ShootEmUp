using Shmup;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public GameObject panel1Jugador;
    public GameObject panel2Jugadores;
    public Image imagenAvion;
    private int currentIndex = 0; // Índice actual en el array de sprites
    // Start is called before the first frame update

    public InputReader input;

    public bool joystickPressed;

    [SerializeField]
    private InputActionReference start;

    private void OnEnable()
    {
        start.action.performed += Level1Scene;
    }

    private void OnDisable()
    {
        start.action.performed -= Level1Scene;
    }

    void Start()
    {
        input = GetComponent<InputReader>();

        if (GameManager.instance.njugadores == 1)
        {
            panel1Jugador.SetActive(true);
            panel2Jugadores.SetActive(false);
        }
        else if (GameManager.instance.njugadores == 2)
        {
            panel1Jugador.SetActive(false);
            panel2Jugadores.SetActive(true);
        }
        imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {

        if (input.Move.x != 0)
        {
            if (!joystickPressed)
            {
                joystickPressed = true;
                if (input.Move.x > 0)
                    MoveNext();
                else if (input.Move.x < 0)
                    MovePrevious();
            }
        }
        else
        {
            joystickPressed = false;
        }
    }
    public void MoveNext()
    {
        Debug.Log("entra");
        input = GetComponent<InputReader>();

        if (input.Move.x > 0)
        {
            // Incrementa el índice y si es igual al tamaño del array, vuelve a 0
            currentIndex = (currentIndex + 1) % GameManager.instance.spriteJugador.Length;
            imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex]; // Actualiza el sprite mostrado

        }

    }

    public void MovePrevious()
    {
        Debug.Log("Resul: " + input.Move.x);
        input = GetComponent<InputReader>();
        if (input.Move.x < 0)
        {
            // Decrementa el índice y si es menor a 0, establece al último sprite del array
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = GameManager.instance.spriteJugador.Length - 1;
            }
            imagenAvion.sprite = GameManager.instance.spriteJugador[currentIndex]; // Actualiza el sprite mostrado

        }



    }
    public void Level1Scene(InputAction.CallbackContext context)
    {
        GameManager.instance.naveElegida = currentIndex;
        GameManager.instance.partidaIniciada = true;
        SceneManager.LoadScene("Level1");
    }

    public void Level1SceneButton()
    {
        GameManager.instance.naveElegida = currentIndex;
        GameManager.instance.partidaIniciada = true;
        SceneManager.LoadScene("Level1");
    }

}
