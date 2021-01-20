using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemCollectionController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    MagicController MagicControllerScript;

    // =================== //
    void Start()
    {
        MagicControllerScript = GetComponentInParent<MagicController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ManaPotion")
        {
            Debug.Log("Player Collected Mana Potion");
            AddMana(25);
        }
    }

    public void AddMana(int ManaAmount)
    {
        MagicControllerScript.currentmagic += ManaAmount;
    }
}
