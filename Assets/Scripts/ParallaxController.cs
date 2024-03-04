using UnityEngine;

namespace Shmup
{
    public class ParallaxController : MonoBehaviour 
    {
        [SerializeField] Transform[] backgrounds; // Array de capas de fondo
        [SerializeField] float smoothing = 10f; // Como de suave se va a ver el efecto Parallax
        [SerializeField] float multiplier = 15f; // Cuanto se mueve el efecto parallax

        Transform cam; // Referencia a la MainCamera
        Vector3 previousCamPos; // Posicion de la camara en el frame anterior

        private void Awake()
        {
            cam = Camera.main.transform;    
        }

        private void Start()
        {
            previousCamPos = cam.position;
        }

        private void Update()
        {
            for(var i = 0; i < backgrounds.Length; i++)
            {
                var parallax = (previousCamPos.y - cam.position.y) * (i * multiplier);
                var targetY = backgrounds[i].position.y + parallax;

                var targetPosition = new Vector3(backgrounds[i].position.x, targetY, backgrounds[i].position.z);
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, targetPosition, smoothing * Time.deltaTime);
            }

            previousCamPos = cam.position;
        }
    }
}
