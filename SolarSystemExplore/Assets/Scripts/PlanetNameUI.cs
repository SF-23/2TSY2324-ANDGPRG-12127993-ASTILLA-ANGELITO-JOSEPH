using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetNameUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI PlanetName;
    [SerializeField] string PlanetNameText;
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Player")) 
        {
            PlanetName.SetText(PlanetNameText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            PlanetName.SetText("");
        }
    }
}
