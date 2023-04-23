using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalvarEscola : MonoBehaviour
{
    //public int novoOuEditar;
    // public int indexEditar;
    [SerializeField] private TMP_InputField inputNomeEscola;
    [SerializeField] private TMP_InputField inputValorHoraAula;
    [SerializeField] private List<GameObject> imagemVistoVerdeList;
    private Controller controladorScript;
    private string textNomeEscola;
    private int valorHoraAula;
    public bool podeSalvar;
    // Start is called before the first frame update
    void Start()
    {
        //novoOuEditar = 0;
        controladorScript = FindObjectOfType(typeof(Controller)) as Controller;
    }

    private void OnEnable()
    {
        podeSalvar = false;
        inputNomeEscola.text = null;
        inputValorHoraAula.text = null;
        for(int i = 0; i < imagemVistoVerdeList.Count; i++)
        {
            imagemVistoVerdeList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClicouNaEscola()
    {
        imagemVistoVerdeList[0].SetActive(false);
        imagemVistoVerdeList[2].SetActive(false);
        textNomeEscola = null;
    }

    public void ClicouNaHoraAula()
    {
        imagemVistoVerdeList[1].SetActive(false);
        imagemVistoVerdeList[3].SetActive(false);
        valorHoraAula = 0;
    }

    public void SalvaEscola()
    {
        if (inputNomeEscola.text.Length > 0)
        {
            textNomeEscola = inputNomeEscola.text;
            imagemVistoVerdeList[0].SetActive(true);
            podeSalvar = true;
            //Debug.Log(textNomeEscola);
        }
        else
        {
            textNomeEscola = null;
            imagemVistoVerdeList[2].SetActive(true);
            podeSalvar = false;
            //Debug.Log(textNomeEscola);
        }
    }

    public void SalvaHoraAula()
    {
        if (inputValorHoraAula.text.Length > 0)
        {
            valorHoraAula = int.Parse(inputValorHoraAula.text);
            imagemVistoVerdeList[1].SetActive(true);
            podeSalvar = true;
            //Debug.Log(valorHoraAula);
        }
        else
        {
            valorHoraAula = 0;
            imagemVistoVerdeList[3].SetActive(true);
            podeSalvar = false;
            //Debug.Log(valorHoraAula);
        }
    }

    public void ButtonSalvaDados(GameObject novaTelaPraAbrir)
    {
        if (controladorScript.nomesEscolas.Count < 5 && podeSalvar == true)
        {
            controladorScript.nomesEscolas.Add(textNomeEscola);
            controladorScript.valoresHoraAula.Add(valorHoraAula);
            controladorScript.listaMensal.Add(0);
            controladorScript.SalvarDados();
            novaTelaPraAbrir.SetActive(true);
            this.gameObject.SetActive(false);
        }

        /*if (novoOuEditar == 0) //novo
        {
            if (controladorScript.nomesEscolas.Count < 5 && podeSalvar == true)
            {
                controladorScript.nomesEscolas.Add(textNomeEscola);
                controladorScript.valoresHoraAula.Add(valorHoraAula);
                controladorScript.listaMensal.Add(0);
                controladorScript.SalvarDados();
                novaTelaPraAbrir.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
        
        if(novoOuEditar == 1) //editar
        {
            controladorScript.nomesEscolas[controladorScript.escolaPosition] = textNomeEscola;
            controladorScript.valoresHoraAula[controladorScript.escolaPosition] = valorHoraAula;
            controladorScript.SalvarDados();
            //novaTelaPraAbrir.SetActive(true);
            this.gameObject.SetActive(false);
        }
        if(Controller.instance.nomesEscolas.Count < 5 && podeSalvar == true)
        {
            Controller.instance.nomesEscolas.Add(textNomeEscola);
            Controller.instance.valoresHoraAula.Add(valorHoraAula);
            Controller.instance.listaMensal.Add(0);
            Controller.instance.SalvarDados();
        }*/
    }
}
