using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Somar : MonoBehaviour
{
    [SerializeField] private GameObject TelaEditarEscola;
    [SerializeField] private GameObject PanelReset;
    [SerializeField] private GameObject horaEntrada;
    [SerializeField] private GameObject horaSaida;
    [SerializeField] private GameObject UltimoValorGO;
    [SerializeField] private TMP_Text UltimoValorText;
    [SerializeField] private TMP_Text valorMensalText;
    private int valorHoraAula;
    private int escolaPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        escolaPosition = Controller.instance.escolaPosition;
        valorHoraAula = PlayerPrefs.GetInt("valorHora" + escolaPosition);
        UltimoValorGO.SetActive(false);
        valorMensalText.text = PlayerPrefs.GetInt("listaMensal" + escolaPosition).ToString();
        //valorMensalGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SomarButton()
    {
        System.TimeSpan horaEntradaTime = horaEntrada.GetComponent<InputTime>().horaString;
        System.TimeSpan horaSaidaTime = horaSaida.GetComponent<InputTime>().horaString;
        double tempoEntreAulas = horaSaidaTime.Subtract(horaEntradaTime).TotalMinutes;
        double valor = (int)((tempoEntreAulas / 60) * valorHoraAula);
        UltimoValorText.text = valor.ToString();
        UltimoValorGO.SetActive(true);
        int mensal = PlayerPrefs.GetInt("listaMensal" + escolaPosition) + (int)valor;
        Controller.instance.listaMensal[escolaPosition] = mensal;
        valorMensalText.text = mensal.ToString();
        //valorMensalGO.SetActive(true);
        PlayerPrefs.SetInt("listaMensal" + escolaPosition, mensal);
        horaEntrada.GetComponent<InputTime>().horaString = System.TimeSpan.Zero;
        horaSaida.GetComponent<InputTime>().horaString = System.TimeSpan.Zero;
    }

    public void ResetarValorMensal()
    {
        Controller.instance.listaMensal[escolaPosition] = 0;
        PlayerPrefs.SetInt("listaMensal" + escolaPosition, 0);
        valorMensalText.text = "0";
        PanelReset.SetActive(false);
    }

    /*public void EditarEscola()
    {
        TelaEditarEscola.SetActive(true);
        TelaEditarEscola.GetComponent<SalvarEscola>().novoOuEditar = 1;
    }*/

    public void AbrirFecharPainelResetarValorMensal()
    {
        if(PanelReset.activeSelf)
        {
            PanelReset.SetActive(false);
        }
        else
        {
            PanelReset.SetActive(true);
        }
    }
}
