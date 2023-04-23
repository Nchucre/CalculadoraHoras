using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SomaHora : MonoBehaviour
{
    [SerializeField] private GameObject horaEntrada;
    [SerializeField] private GameObject horaSaida;
    [SerializeField] private TMP_Text horaAulaText;
    [SerializeField] private TMP_Text valorMensalText;
    private int valorHoraAula;
    // Start is called before the first frame update
    void Start()
    {
        //pegar o valor hora aula das configurações
        if(PlayerPrefs.HasKey("valorHoraAula") == false)
        {
            PlayerPrefs.SetInt("valorHoraAula", 0);
        }
        if(PlayerPrefs.HasKey("valorMensal") == false)
        {
            PlayerPrefs.SetInt("valorMensal", 0);
        }
        //valorHoraAula = PlayerPrefs.GetInt("valorHoraAula");
    }

    private void Update()
    {
        valorMensalText.text = "Mensal: " + PlayerPrefs.GetInt("valorMensal").ToString();
    }

    public void SomaButton()
    {
        valorHoraAula = PlayerPrefs.GetInt("valorHoraAula");
        System.TimeSpan horaEntradaTime = horaEntrada.GetComponent<InputTime>().horaString;
        System.TimeSpan horaSaidaTime = horaSaida.GetComponent<InputTime>().horaString;
        double tempoEntreAulas = horaSaidaTime.Subtract(horaEntradaTime).TotalMinutes;
        double valor = (tempoEntreAulas / 60) * valorHoraAula;
        horaAulaText.text = "Hora/Aula: " + valor;
        PlayerPrefs.SetInt("valorMensal", (int)valor + PlayerPrefs.GetInt("valorMensal"));
        //valorMensalText.text = "Mensal: " + PlayerPrefs.GetInt("valorMensal").ToString();
        Debug.Log("aa");
        //resetando os valores pra não somar duas vezes
        horaEntrada.GetComponent<InputTime>().horaString = System.TimeSpan.Zero;
        horaSaida.GetComponent<InputTime>().horaString = System.TimeSpan.Zero;
    }
}
