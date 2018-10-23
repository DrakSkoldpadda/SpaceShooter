using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingEnemy : ShootingEnemy
{
    public float dodgingSpeed;

    private Vector2 choosenDirection;

    public override void Start()
    {
        base.Start();

        choosenDirection = new Vector2(transform.position.x, 2);
    }

    public override void Update()
    {
        base.Update();

        Dodge();
    }

    void Dodge()
    {
        //Detta är en bra programmerad kod
        Vector2 topPosition = new Vector2(transform.position.x - 2, 2);
        Vector2 botPosition = new Vector2(transform.position.x - 2, -2);

        Vector2 position = transform.position;

        if (position.y >= topPosition.y - 0.15f)
        {
            choosenDirection = botPosition;
        }
        else if (position.y <= botPosition.y + 0.15f)
        {
            choosenDirection = topPosition;
        }

        Direction(choosenDirection);
    }

    void Direction(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, dodgingSpeed * Time.deltaTime);
    }
}