using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    public delegate void GameDelegate();
    ProjectileController ProjectileControllerScript;
    public float currentmagic = 50;

    // =================== //

    private void Start()
    {
        ProjectileControllerScript = this.gameObject.GetComponent<ProjectileController>();
    }

    private void OnEnable()
    {
        ProjectileController.Fireball += Fireball;
    }

    private void OnDisable()
    {
        ProjectileController.Fireball -= Fireball;
    }

    public void Fireball()
    {
        RemoveMagic(10);
    }

    public void RemoveMagic(int magic)
    {
        currentmagic -= magic;
    }
}
