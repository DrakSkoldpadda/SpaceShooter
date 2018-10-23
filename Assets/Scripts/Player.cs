using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject projectile;
    public int damage = 5;
    public float projectileSpeed = 30;
    private float attackCD;
    public float resetAttackCD = 0.2f;

    [Header("Player")]
    public float playerSpeed;
    public float constantSpeed = 2;
    public int HP;
    public int score;
    public float shakeDuration;
    private Rigidbody2D player;
    [HideInInspector]
    public bool haveLost;

    [Header("UI")]
    public GameObject lostObject;
    public TMP_Text lostText;
    public TMP_Text playerText;

    private CameraShake cameraShaker;

    // Use this for initialization
    void Start()
    {
        if (lostObject != null)
            lostObject.SetActive(false);

        if (player == null)
            player = GetComponent<Rigidbody2D>();

        if (cameraShaker == null)
            cameraShaker = GameObject.FindWithTag("CameraShaker").GetComponent<CameraShake>();

        haveLost = false;
    }

    void Update()
    {
        if (score <= -100)
            Lost();

        if (playerText != null)
            playerText.text = " Score: " + score + "\n HP: " + HP;
    }

    void FixedUpdate()
    {
        Move();

        Shoot();

        ConstantMovement();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        player.velocity = movement * playerSpeed * Time.deltaTime;
    }

    void ConstantMovement()
    {
        Vector2 defaultPosition;

        if (player.position == new Vector2(-5.5f, player.position.y))
            defaultPosition = new Vector2(-5.5f, 0);

        else
            defaultPosition = new Vector2(-5.5f, player.position.y);

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), defaultPosition, constantSpeed * Time.deltaTime);

    }

    void Shoot()
    {
        GameObject newProjectile;
        attackCD -= Time.deltaTime;

        if (attackCD <= 0)
        {
            attackCD = resetAttackCD;
            newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, 0f));
            newProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * projectileSpeed, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(newProjectile.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") || collision.CompareTag("Enemy") || collision.CompareTag("TankEnemy"))
        {
            if (collision.CompareTag("TankEnemy"))
                HP = 0;
            else
                HP--;

            cameraShaker.shakeDuration = shakeDuration;

            if (HP <= 0)
            {
                Lost();
            }
        }
    }

    void Lost()
    {
        haveLost = true;
        Time.timeScale = 0f;
        lostObject.SetActive(true);
        lostText.text = "You lost!\ngit gud";
    }
}
