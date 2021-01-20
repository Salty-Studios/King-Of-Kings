using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // ====[REFERENCES]==== //

    public delegate void GameDelegate();
    public static event GameDelegate ShootProjectile;
    private Rigidbody2D rb;
    private float moveSpeed = 4f;
    Vector2 movement;
    //public Animator animator;
    [HideInInspector] public string direction;
    private GameObject player;
    private SpriteRenderer playerSprite;
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;
    public float lifetime = 5;
    ProjectileController ProjectileControllerScript;
    MagicController MagicControllerScript;
    private float currentMagic;

    // =================== //
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = this.gameObject;
        playerSprite = player.GetComponent<SpriteRenderer>();
        ProjectileControllerScript = player.GetComponent<ProjectileController>();
        MagicControllerScript = player.GetComponent<MagicController>();
        direction = "down";
    }

    // Update is called once per frame
    void Update()   //Update is called once per frame
    {
        currentMagic = MagicControllerScript.currentmagic;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        // Sideways movement
        // Right
        if (movement.x > 0.01)
        {
            direction = "right";
        }
        // Left
        else if (movement.x < -0.01)
        {
            direction = "left";
        }

        // Vertical movement
        // Up
        if (movement.y > 0.01)
        {
            direction = "up";
        }
        // Down
        else if (movement.y < -0.01)
        {
            direction = "down";
        }

        ChangeSprite();
        if (Input.GetKeyDown("space") & currentMagic >0){
            ShootProjectile();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeSprite()
    {
        if(direction == "left")
        {
            playerSprite.sprite = Left;
        } else if(direction == "right")
        {
            playerSprite.sprite = Right;
        } else if(direction == "down")
        {
            playerSprite.sprite = Down;
        } else if(direction == "up")
        {
            playerSprite.sprite = Up;
        }
    }
}