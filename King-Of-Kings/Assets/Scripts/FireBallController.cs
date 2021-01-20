using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FireBallController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    // =================== //
   
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Box")
        {
            Destroy(this.gameObject);
        }
    }
}
