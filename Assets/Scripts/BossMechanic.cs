using Shmup;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    public int vidaboss;
    private void Start()
    {
        vidaboss = GameManager.instance.vidaBoss;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            GameManager.instance.SubtractLifeBoss(1);
            Debug.Log("Boss"+vidaboss);
            if(GameManager.instance.vidaBoss<=0)
            {
                Destroy(gameObject);
            }
           
        }
    }
}
