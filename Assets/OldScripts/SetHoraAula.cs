using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHoraAula : MonoBehaviour
{
    [SerializeField] private TMP_InputField InputFieldText;
    [SerializeField] private TMP_Text horaAulaText;
    [SerializeField] private TMP_Text valorMensalText;
    public string valorEntrada;
    // Start is called before the first frame update
    void Start()
    {
        //valorMensalText.text = "Mensal: " + PlayerPrefs.GetInt("valorMensal").ToString();
    }

    private void OnEnable()
    {
        valorMensalText.text = "Mensal: " + PlayerPrefs.GetInt("valorMensal").ToString();
        horaAulaText.text = "Valor Hora/Aula atual: " + PlayerPrefs.GetInt("valorHoraAula");
    }

    // Update is called once per frame
    void Update()
    {
        valorEntrada = InputFieldText.text;
    }

    public void SalvaValorHoraAula()
    {
        int valorEntradaToInt = int.Parse(valorEntrada);
        PlayerPrefs.SetInt("valorHoraAula", valorEntradaToInt);
        horaAulaText.text = "Valor Hora/Aula atual: " + valorEntradaToInt.ToString();
    }
}
