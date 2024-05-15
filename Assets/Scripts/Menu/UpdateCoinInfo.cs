using Shmup;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateCoinInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text1, text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = GameManager.instance.monedas.ToString();
        text2.text = GameManager.instance.monedas.ToString();
    }
}
