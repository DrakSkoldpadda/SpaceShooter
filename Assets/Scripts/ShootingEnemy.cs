using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject projectile;
    private float attackCD;
    public int damage;
    public float projectileSpeed = 25;
    
    public bool shootingEnemy;

    public override void Update()
    {
        base.Update();

        if (shootingEnemy == true)
            Shoot();
    }

    void Shoot()
    {
        GameObject newProjectile;
        float resetAttackCD = 0.4f;
        attackCD -= Time.deltaTime;

        if (attackCD <= 0)
        {
            attackCD = resetAttackCD;
            newProjectile = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, 0f));
            newProjectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * projectileSpeed, ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(newProjectile.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
