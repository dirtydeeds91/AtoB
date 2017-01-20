using UnityEngine;
using System.Collections;

public class ParallaxComponent : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private SpriteRenderer sprite;
    
    private Vector2 positionToGo;

    public bool ShouldSpawnMore
    {
        get { return this.transform.position.x < 1; }
    }

	// Update is called once per frame
	void Update()
    {
        this.positionToGo.x = this.transform.position.x - movementSpeed;
        this.transform.position = Vector2.Lerp(this.transform.position, this.positionToGo, Time.deltaTime);
	}
}
