using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    public delegate void GameDelegate();
    public static event GameDelegate Fireball;
    GameObject player;
    public GameObject projectile;
    PlayerController PlayerControllerScript;
    public float ProjectileSpeed;

    // =================== //

    private void Start()
    {
        player = this.gameObject;
        PlayerControllerScript = player.GetComponent<PlayerController>();

    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerController.ShootProjectile += ShootProjectile;
    }

    private void OnDisable()
    {
        PlayerController.ShootProjectile -= ShootProjectile;
    }

    // Method to clone the projectile prefab and give it velocity in a set direction
    public void ShootProjectile()
    {
        //Debug.Log("SHOTTING");
        if (PlayerControllerScript.direction == "up")
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.up * ProjectileSpeed);
            Destroy(bullet, PlayerControllerScript.lifetime);
        }
        else if (PlayerControllerScript.direction == "down")
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.down * ProjectileSpeed);
            Destroy(bullet, PlayerControllerScript.lifetime);
        }
        else if (PlayerControllerScript.direction == "left")
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.left * ProjectileSpeed);
            Destroy(bullet, PlayerControllerScript.lifetime);
        }
        else if (PlayerControllerScript.direction == "right")
        {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody2D>().AddForce(Vector3.right * ProjectileSpeed);
            Destroy(bullet, PlayerControllerScript.lifetime);
        }

        Fireball();
    }
}
