using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float yMovement;

    private bool isJumping;
    private bool isPlaying;
    public StopMovement stopMovement;

    private void Start()
    {
        rigidBody.velocity = new Vector2(0f, 0f);
        this.isPlaying = false;
        this.isJumping = false;
        stopMovement.OnGameEnd();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!this.isPlaying)
            {
                animator.SetTrigger("Start");
                this.isPlaying = true;
                stopMovement.OnGameStart();
                return;
            }

            animator.SetTrigger("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        if (this.isJumping)
        {
            return;
        }

        this.isJumping = true;
        rigidBody.velocity = new Vector2(0f, this.yMovement);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            this.isJumping = false;
            return;
        }
        else if (other.tag == "Flasher")
        {
            Flasher flasher = other.GetComponent<Flasher>();
            flasher.StartAnimation();
        }

        Debug.Log("Died");
        Die();
    }

    public void Die()
    {
        animator.SetTrigger("Death");
        stopMovement.OnGameEnd();
    }
}
