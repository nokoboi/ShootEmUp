using Shmup;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int puntosEnemigo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        // Comprobar si el objeto con el que se colisionó es una bala
        if (other.gameObject.tag == "Bullet")
        {
            // Destruir el objeto bala
            Destroy(other.gameObject);  // Destruye la bala
            Destroy(gameObject);        // Destruye este objeto
            GameManager.instance.AddEnemys(puntosEnemigo);
        }
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);        // Destruye este objeto
            GameManager.instance.SubtractLife(1);
            Debug.Log("Te ha dado un enemigo");
        }
    }
}
