using UnityEngine;
using System.Collections;

public class Flasher : MonoBehaviour
{
    public Animator animator;

    public void StartAnimation()
    {
        int random = Random.Range(1, 4);
        animator.SetInteger("FlashType", random);
    }
}
