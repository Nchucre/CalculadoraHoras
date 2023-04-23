using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulaInicialButtons : MonoBehaviour
{
    [SerializeField] private List<Button> listaButtons;
    [SerializeField] private List<Button> listaVerEscola;
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private Controller controladorScript;
    // Start is called before the first frame update

    private void Awake()
    {
        //controladorScript = this.GetComponent<Controller>();
    }
    void Start()
    {
        
    }

    private void OnEnable()
    {
        if(controladorScript.nomesEscolas.Count == 0)
        {
            for(int i = 1; i < listaButtons.Count; i++)
            {
                listaButtons[i].gameObject.SetActive(false);
            }

            listaButtons[0].onClick = listaButtons[listaButtons.Count - 1].onClick;
            listaButtons[0].transform.GetChild(0).GetComponent<TMP_Text>().text = "Nova Instituição";
            listaButtons[0].gameObject.SetActive(true);
        }
        else
        {
            for (int i = 1; i < listaButtons.Count; i++)
            {
                listaButtons[i].gameObject.SetActive(false);
            }

            int tamanhoLista = controladorScript.nomesEscolas.Count;
            for(int i = 0; i < tamanhoLista; i++)
            {
                listaButtons[i].onClick = listaVerEscola[i].onClick;
                //listaButtons[i].onClick = listaButtons[listaButtons.Count - 1].onClick;
                listaButtons[i].transform.GetChild(0).GetComponent<TMP_Text>().text = controladorScript.nomesEscolas[i];
                listaButtons[i].transform.GetChild(1).gameObject.SetActive(false);
                listaButtons[i].gameObject.SetActive(true);
            }
            if (tamanhoLista < 5)
            {
                listaButtons[tamanhoLista].onClick = listaButtons[listaButtons.Count - 1].onClick;
                listaButtons[tamanhoLista].transform.GetChild(0).GetComponent<TMP_Text>().text = "Nova Instituição";
                listaButtons[tamanhoLista].gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
