using Shmup;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeathSceneController : MonoBehaviour
{
    [SerializeField] private GameObject deathCanvas, alertaMoneda;
    private GameObject player;
    [SerializeField] private TextMeshProUGUI[] countdown;
    [SerializeField] private TextMeshProUGUI[] texto;
    private float countdownFloat;
    [SerializeField] private InputActionReference moneda;
    private bool flashing = false;
    private bool returningToMain = false;
    [SerializeField] private CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        countdownFloat = float.Parse(countdown[0].text);
    }

    private void OnEnable()
    {
        moneda.action.performed += CreditRevive;
    }

    private void OnDisable()
    {
        moneda.action.performed -= CreditRevive;
    }

    // Update is called once per frame
    void Update()
    {

        if (countdownFloat > 0f)
        {
            cameraController.enabled = false;
            StartCoroutine(PlayerFlashing());
            countdownFloat -= Time.deltaTime;
            countdown[0].text = ((int)countdownFloat).ToString();
            countdown[1].text = ((int)countdownFloat).ToString();
        }
        else
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        if (!returningToMain)
        {
            returningToMain = true;
            countdown[0].text = "";
            countdown[1].text = "";
            alertaMoneda.SetActive(false);
            texto[0].text = "FIN DEL JUEGO";
            texto[1].text = "FIN DEL JUEGO";
            Debug.Log("Fin del juego");
            GameManager.instance.monedas = 0;
            GameManager.instance.puntos = 0;
            yield return new WaitForSeconds(3f);
            GameManager.instance.partidaIniciada = false;
            GameManager.instance.vidas = 1;
            SceneManager.LoadScene("MenuCinematica");
        }

    }

    private IEnumerator PlayerFlashing()
    {
        if (!flashing)
        {
            flashing = true;
            player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.25f);
            player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.25f);
            player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            flashing = false;
        }
    }

    private void CreditRevive(InputAction.CallbackContext context)
    {
        if (!returningToMain)
        {
            cameraController.enabled = true;
            StopCoroutine(EndGame());
            StopCoroutine(PlayerFlashing());
            player.GetComponentInChildren<SpriteRenderer>().enabled = true;
            flashing = false;
            countdownFloat = 11f;
            GameManager.instance.vidas = 1;
            gameObject.SetActive(false);
            GameManager.instance.StartInvulnerability();
        }
    }


}
