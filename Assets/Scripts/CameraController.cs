using UnityEngine;

namespace Shmup
{
    public class CameraController : MonoBehaviour 
    {
        [SerializeField] Transform player;
        [SerializeField] float speed = 2f;

        private void Start()
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        private void LateUpdate()
        {
            // Movemos la camara por el campo a una velocidad constante
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

    }
}
