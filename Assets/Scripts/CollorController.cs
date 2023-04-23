using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollorController : MonoBehaviour
{
    public List<Image> PanelsImagesButtons;
    public List<TMP_Text> Textos;
    public Color corPrincipal;
    public Color corSecundaria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < PanelsImagesButtons.Count; i++)
        {
            PanelsImagesButtons[i].color = corPrincipal;
        }
    }
}
