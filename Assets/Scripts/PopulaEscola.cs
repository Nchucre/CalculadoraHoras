using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopulaEscola : MonoBehaviour
{
    public int index;
    public string nomeEscola;
    public int valorHoraAula;
    public GameObject telaEscola;
    public GameObject telaInicial;
    public TMP_Text nomeEscolaText;
    public TMP_Text valorHoraAulaText;
    public Controller controladorScript;
    // Start is called before the first frame update
    void Start()
    {
        //controladorScript = Controller.instance;
    }

    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PopulaDadosEscola()
    {
        Controller.instance.escolaPosition = index;
        nomeEscolaText.text = controladorScript.nomesEscolas[index];
        valorHoraAulaText.text = controladorScript.valoresHoraAula[index].ToString();
        telaEscola.SetActive(true);
        telaInicial.SetActive(false);
    }

    public void Indexador()
    {
        //n = index;
        nomeEscolaText.text = Controller.instance.nomesEscolas[0];
    }
}
