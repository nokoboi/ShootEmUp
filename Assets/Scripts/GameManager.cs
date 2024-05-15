using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Shmup
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance; // Singleton para acceder fácilmente al GameManager desde otros scripts

        public int njugadores;
        public int monedas; // Variable para el recuento de monedas
        public int puntos;
        public TextMeshProUGUI puntos1Text;
        public TextMeshProUGUI puntos2Text;
        public TextMeshProUGUI vidas1Text;
        public TextMeshProUGUI vidas2Text;
        public int vidas;
        public Sprite[] spriteJugador;
        public int naveElegida = 0;
        public bool derrotado = false;
        public bool partidaIniciada = false;
        public bool invulnerable = false;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Asegúrate de des-suscribirte para evitar memory leaks
        }

        // Este método se llama cada vez que se carga una nueva escena
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            InitializeUIComponents();
        }

        private void Start()
        {
            vidas = monedas;
            InitializeUIComponents();
            

        }

        private void InitializeUIComponents()
        {
            puntos1Text = FindComponentByTag<TextMeshProUGUI>("Puntos1");
            puntos2Text = FindComponentByTag<TextMeshProUGUI>("Puntos2");
            vidas1Text = FindComponentByTag<TextMeshProUGUI>("Vidas1");
            vidas2Text = FindComponentByTag<TextMeshProUGUI>("Vidas2");
        }

        private T FindComponentByTag<T>(string tag) where T : Component
        {
            GameObject obj = GameObject.FindWithTag(tag);
            if (obj != null)
            {
                return obj.GetComponent<T>();
            }
            else
            {
                Debug.LogWarning("No se encontró el objeto con tag " + tag + " en esta escena.");
                return null;
            }
        }

        private void Update()
        {
            if (puntos1Text != null) puntos1Text.text = puntos.ToString();
            if (puntos2Text != null) puntos2Text.text = puntos.ToString();
            if (vidas1Text != null) vidas1Text.text = vidas.ToString();
            if (vidas2Text != null) vidas2Text.text = vidas.ToString();

            if (vidas <= 0 && partidaIniciada)
            {
                derrotado = true;
            } else
            {
                derrotado = false;
            }

        }
        public void AgregarMonedas(int cantidad)
        {
            if (cantidad < 0) return; // Prevenir agregar cantidades negativas
            monedas += cantidad;
            Debug.Log("Se han agregado " + cantidad + " monedas. Total de monedas: " + monedas);
            vidas = monedas;
        }

        public void AddEnemys(int enemys)
        {
            if (enemys < 0) return; // Prevenir valores negativos
            puntos += enemys;
            Debug.Log("Has matado un enemigo, has ganado " + enemys + " puntos.");
        }

        public void SubtractLife(int life)
        {
            if (life < 0) return; // Prevenir restar una cantidad negativa de vidas
            vidas -= life;
            Debug.Log("Se han restado " + life + " vidas.");
            Debug.Log("Te quedan: " + vidas);
        }

        public IEnumerator Invulnerability()
        {
            invulnerable = true;
            yield return new WaitForSeconds(2f);
            invulnerable = false;
        }

        public void StartInvulnerability()
        {
            StartCoroutine(Invulnerability());
        }
    }
}
