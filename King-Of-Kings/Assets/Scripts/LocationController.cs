using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocationController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    [SerializeField] public TextMeshProUGUI locationText;    

    // =================== //

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plains_Biome")
        {
            Debug.Log("Entered Plains Biome");
            locationText.text = "Plains Biome";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plains_Biome")
        {
            Debug.Log("Exiting Plains Biome");
            locationText.text = "";
        }
    }
}
