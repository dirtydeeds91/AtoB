using UnityEngine;
using System.Collections;
using System;

public class LevelMover : MonoBehaviour, IMovable
{
    public float xMovementSpeed;
    public StopMovement stopMovement;

    private Vector2 newPosition;

    private bool shouldStop;

    private void Start()
    {
        stopMovement.AddObject(this);
    }

    public void Move()
    {
        if (shouldStop)
        {
            return;
        }

        newPosition.x = this.transform.position.x - xMovementSpeed;
        this.transform.position = Vector2.Lerp(this.transform.position,
                                               newPosition,
                                               Time.deltaTime);
    }

    public void StopMovement(bool shouldStop)
    {
        this.shouldStop = shouldStop;
    }

    private void Update()
    {
        Move();
    }
}
