using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    public delegate void GameDelegate();
    public GameObject ManaPotion;
    public float BoxHealth = 100;

    // =================== //

    void Update()
    {
        if(BoxHealth <= 0)
        {
            //box.SetActive(false);
            GameObject potion = Instantiate(ManaPotion, transform.position, Quaternion.identity) as GameObject;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Projectile")
        {
            CauseDamage(50);
        }
    }

    public void CauseDamage(int Damage)
    {
        BoxHealth -= Damage;
    }
}
