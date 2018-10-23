using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int scoreGiven;
    public float HP;
    public float moveSpeed;
    private Player player;
    private Rigidbody2D enemy;

    public virtual void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        Difficulty();
    }

    public virtual void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 movePosition = new Vector2(-11, enemy.position.y);

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), movePosition, moveSpeed * Time.deltaTime);
    }

    public void Difficulty()
    {
        if (player.score >= 100)
        {
            HP *= player.score * 1.01f;
            moveSpeed *= player.score * 1.001f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
            HP -= player.damage;

        if (HP <= 0)
        {
            player.score += scoreGiven;
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (HP > 0)
            player.score -= scoreGiven;
        Destroy(this.gameObject);
    }
}
