using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [Header ("Paineis")]
    [SerializeField] private GameObject panelConfirmaReset;
    [SerializeField] private GameObject panelConfig;

    [Header ("SFX")]
    [SerializeField] private GameObject somLigadoButton;
    [SerializeField] private GameObject somDesligadoButton;
    [SerializeField] private List<AudioClip> listaSFX;
    public AudioListener sfx;
    // Start is called before the first frame update
    void Start()
    {
        sfx = Camera.main.GetComponent<AudioListener>();
        AtivaDesativaSom();
    }

    // Update is called once per frame
    void Update()
    {
        //AtivaDesativaSom();
    }

    public void AtivaDesativaSom()
    {
        if(PlayerPrefs.GetInt("SFX") == 0)
        {
           //sfx.enabled = false;
            this.GetComponent<AudioSource>().enabled = false;
            somDesligadoButton.SetActive(true);
            somLigadoButton.SetActive(false);
        }
        else
        {
            //sfx.enabled = true;
            this.GetComponent<AudioSource>().enabled = true;
            somDesligadoButton.SetActive(false);
            somLigadoButton.SetActive(true);
        }
    }

    public void SimResetButton()
    {
        PlayerPrefs.SetInt("valorMensal", 0);
        panelConfig.SetActive(false);
        panelConfig.SetActive(true);
        panelConfirmaReset.SetActive(false);
    }

    public void SfxButton()
    {
        if(PlayerPrefs.GetInt("SFX") == 0)
        {
            Debug.Log("Liga");
            PlayerPrefs.SetInt("SFX", 1);
            AtivaDesativaSom();
            /*this.GetComponent<AudioSource>().enabled = true;
            somDesligadoButton.SetActive(false);
            somLigadoButton.SetActive(true);*/
        }
        else
        {
            Debug.Log("Desliga");
            PlayerPrefs.SetInt("SFX", 0);
            AtivaDesativaSom();
            /*this.GetComponent<AudioSource>().enabled = false;
            somDesligadoButton.SetActive(true);
            somLigadoButton.SetActive(false);*/
        }
    }

    public void PlaySFX(int index)
    {
        this.GetComponent<AudioSource>().PlayOneShot(listaSFX[index]);
    }
}
