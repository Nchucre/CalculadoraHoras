using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreFechaMenus : MonoBehaviour
{
    public void AbreFecha(GameObject menu)
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
