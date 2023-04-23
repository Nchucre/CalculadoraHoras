using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<string> nomesEscolas;
    public List<int> valoresHoraAula;
    public List<int> listaMensal;
    public int escolaPosition;
    public static Controller instance;

    private void Awake()
    {
        LoadDados();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SalvarDados()
    {
        for(int i = 0; i < nomesEscolas.Count; i++)
        {
            string escolaIndex = "nomesEscolas" + i;
            PlayerPrefs.SetString(escolaIndex, nomesEscolas[i]);
            string valorIndex = "valorHora" + i;
            PlayerPrefs.SetInt(valorIndex, valoresHoraAula[i]);
            string mensalIndex = "listaMensal" + i;
            PlayerPrefs.SetInt(mensalIndex, listaMensal[i]);
        }

        PlayerPrefs.SetInt("tamanhoLista", nomesEscolas.Count);
    }

    public void LoadDados()
    {
        int tamanhoListas = PlayerPrefs.GetInt("tamanhoLista");
        for(int i = 0; i < tamanhoListas; i++)
        {
            string escolaIndex = "nomesEscolas" + i;
            nomesEscolas.Add(PlayerPrefs.GetString(escolaIndex));
            string valorIndex = "valorHora" + i;
            valoresHoraAula.Add(PlayerPrefs.GetInt(valorIndex));
            string mensalIndex = "listaMensal" + i;
            listaMensal.Add(PlayerPrefs.GetInt(mensalIndex));
        }
    }
}
