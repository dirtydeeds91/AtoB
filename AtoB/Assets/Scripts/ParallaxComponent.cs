using UnityEngine;
using System.Collections;
using System;

public class ParallaxComponent : MonoBehaviour, IMovable
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private SpriteRenderer sprite;
    
    private Vector2 positionToGo;
    private bool shouldStop;

    public bool ShouldSpawnMore
    {
        get { return this.transform.position.x < 1; }
    }

	// Update is called once per frame
	void Update()
    {
        Move();
	}

    public void Move()
    {
        if (shouldStop)
        {
            return;
        }

        this.positionToGo.x = this.transform.position.x - movementSpeed;
        this.transform.position = Vector2.Lerp(this.transform.position, this.positionToGo, Time.deltaTime);
    }

    public void StopMovement(bool shouldStop)
    {
        this.shouldStop = shouldStop;
    }
}
