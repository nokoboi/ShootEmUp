using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shmup
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        [SerializeField] float smoothness = 0.1f;
        [SerializeField] float leanAngle = 15f;
        [SerializeField] float leanSpeed = 5f;
        public PlayerController instance;

        [SerializeField] GameObject model;

        [Header("Camera Bounds")]
        [SerializeField] Transform cameraFollow;
        [SerializeField] float minX = -8f;
        [SerializeField] float maxX = 8f;
        [SerializeField] float minY = -4f;
        [SerializeField] float maxY = 4f;

        [SerializeField] GameObject bulletPrefab;
        [SerializeField] float bulletSpeed = 10f;

        InputReader input;

        Vector3 currentVelocity;
        Vector3 targetPosition;

        [SerializeField]
        private InputActionReference shoot;

        //Eleccion Sprite Avion
        public GameObject spriteAvion;

        // Sonido de la bala
        public AudioSource bala;


        private void OnEnable()
        {
            shoot.action.performed += Disparar;
        }

        private void OnDisable()
        {
            shoot.action.performed -= Disparar;
        }

        private void Disparar(InputAction.CallbackContext context)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletSpeed * Time.deltaTime, ForceMode.Impulse);

            bala.Play();

            Destroy(bullet, 1);
        }

        private void Start()
        {
            input = GetComponent<InputReader>();

            spriteAvion.GetComponent<SpriteRenderer>().sprite = GameManager.instance.spriteJugador[GameManager.instance.naveElegida];

        }


        private void Update()
        {
            targetPosition += new Vector3 (input.Move.x, input.Move.y, 0f) * (speed * Time.deltaTime);

            // Calculamos la posicion maxima de X e Y para el jugador basadas en la vision de la camara
            var minPlayerX = cameraFollow.transform.position.x + minX;
            var maxPlayerX = cameraFollow.transform.position.x + maxX;
            var minPlayerY = cameraFollow.transform.position.y + minY;
            var maxPlayerY = cameraFollow.transform.position.y + maxY;

            // Clamp de la posicion del player respecto a la camara
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPlayerX, maxPlayerX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPlayerY, maxPlayerY);

            // Lerp de la posicion del player respecto a la del target
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothness);

            // Calcular la rotacion
            var targetRotationAngle = -input.Move.x * leanAngle;

            var currentYRotation = transform.localEulerAngles.y;
            var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

            // Aplicar la rotacion
            transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);

        }

        public bool ShootingTest()
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * bulletSpeed * Time.deltaTime, ForceMode.Impulse);

            Destroy(bullet, 1);
            return true;
        }


    }
}
