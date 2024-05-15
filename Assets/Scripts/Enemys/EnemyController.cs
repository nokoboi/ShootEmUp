using Shmup;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int puntosEnemigo;
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] float bulletSpeed = 5f;
    private bool firing = false;
    public float distance;

    public int vidaboss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, GameObject.Find("Player").transform.position);

        if (distance <= 2.4f && !firing && !GameManager.instance.derrotado)
        {
            StartCoroutine(Shooting());
        }
    }

    IEnumerator Shooting()
    {
        firing = true;
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(-transform.up * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        yield return new WaitForSeconds(1.5f);
        firing = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!GameManager.instance.derrotado)
        {
            // Comprobar si el objeto con el que se colisionó es una bala
            if (other.gameObject.tag == "Bullet")
            {
                StopCoroutine(Shooting());
                // Destruir el objeto bala
                Destroy(other.gameObject);  // Destruye la bala
                Destroy(gameObject);        // Destruye este objeto
                GameManager.instance.AddEnemys(puntosEnemigo);
            }
            if (other.gameObject.tag == "Player" && !GameManager.instance.invulnerable)
            {
                Destroy(gameObject);        // Destruye este objeto
                GameManager.instance.SubtractLife(1);
                Debug.Log("Te ha dado un enemigo");
            }
        }
    }
}
