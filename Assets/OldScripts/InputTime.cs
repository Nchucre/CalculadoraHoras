using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputTime : MonoBehaviour
{
    [SerializeField] private TMP_InputField InputFieldText;
    [SerializeField] private TMP_Text OutputText;
    [SerializeField] private TMP_Text horaOutputText;
    public System.TimeSpan horaString;
    public string entradaSaida;
    //[SerializeField] private TMP_Text inicioOutputHora;
    public string valoresEntrada;
    public List<char> vetorEntrada;
    //public List<int> valoresEntradaToInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        OutputText.text = "";
        horaOutputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        valoresEntrada = InputFieldText.text;
    }

    public void TextoEntradaSaida(string texto)
    {
        entradaSaida = texto;
    }

    public void AdicionaTextoHora()
    {
        if(valoresEntrada.Length < 3)
        {
            SaidaErro(0);
        }
        else
        {
            if (vetorEntrada != null)
            {
                vetorEntrada.Clear();
            }

            foreach (char i in valoresEntrada)
            {
                vetorEntrada.Add(i);
            }

            if (vetorEntrada.Count < 4)
            {
                vetorEntrada.Add('0');
                for (int i = vetorEntrada.Count - 1; i > 0; i--)
                {
                    vetorEntrada[i] = vetorEntrada[i - 1];
                }
                vetorEntrada[0] = '0';
            }

            valoresEntrada = null;
            InputFieldText.text = null;
            //SaidaTextoHora(vetorEntrada);


            List<int> valoresEntradaToInt = new List<int>();
            for(int i = 0; i < vetorEntrada.Count; i++)
            {
                valoresEntradaToInt.Add((int)char.GetNumericValue(vetorEntrada[i]));
            }
            SaidaTextoHora(valoresEntradaToInt);
        }
    }

    public void SaidaTextoHora(List<int> valoresEntrada)
    {
        OutputText.gameObject.SetActive(true);
        horaOutputText.gameObject.SetActive(true);
        //horaOutputText.gameObject.SetActive(true);
        if (valoresEntrada[0] > 1)
        {
            SaidaErro(0); 
        }
        else if(valoresEntrada[2] > 5)
        {
            SaidaErro(1);
        }
        else
        {
            OutputText.text = entradaSaida;
            string tempo = valoresEntrada[0].ToString() + valoresEntrada[1].ToString() + ":" + valoresEntrada[2].ToString() + valoresEntrada[3].ToString();
            horaOutputText.text = tempo;
            horaString = System.TimeSpan.Parse(tempo);
            //Debug.Log(horaString);
            //inicioOutputText.transform.GetChild(0).gameObject.SetActive(true);
            //inicioOutputHora.text = valoresEntrada[0] + valoresEntrada[1] + ":" + valoresEntrada[2] + valoresEntrada[3];
        }
    }

    public void SaidaErro(int erroHoraOuMinuto)
    {
        //Debug.Log("Erro");
        if(erroHoraOuMinuto == 0)
        {
            OutputText.text = "Hora incorreta";
            horaOutputText.gameObject.SetActive(false);
        }
        if(erroHoraOuMinuto == 1)
        {
            OutputText.text = "Minutos incorretos";
            horaOutputText.gameObject.SetActive(false);
        }
    }
}
