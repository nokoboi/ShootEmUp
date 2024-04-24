using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class SelectionStyleButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public UnityEngine.UI.Button boton;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textoSombra;
    private string contenidoTexto;
    private ColorBlock colores;

    // Start is called before the first frame update
    void Start()
    {
        contenidoTexto = texto.text;
        contenidoTexto = textoSombra.text;

        colores.normalColor = Color.clear;
        colores.highlightedColor = Color.clear;
        colores.pressedColor = Color.clear;
        colores.selectedColor = Color.clear;
        colores.disabledColor = Color.clear;
        boton.colors = colores;

        //textoBoton = boton.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnSelect(BaseEventData eventData)
    {
        texto.fontStyle = FontStyles.Underline;
        textoSombra.fontStyle = FontStyles.Underline;
        //audioSource.PlayOneShot(audioClip, 0.7f);


        //boton.GetComponentInChildren<TextMeshProUGUI>().fontStyle = FontStyles.Underline;
        //Debug.Log(boton.GetComponentInChildren<TextMeshProUGUI>().text);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        texto.fontStyle &= ~FontStyles.Underline;
        textoSombra.fontStyle &= ~FontStyles.Underline;

        //boton.GetComponentInChildren<TextMeshProUGUI>().fontStyle &= ~FontStyles.Underline;
        //Debug.Log(boton.GetComponentInChildren<TextMeshProUGUI>().text + "Quitado");
    }

}
