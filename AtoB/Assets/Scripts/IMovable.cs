using UnityEngine;
using System.Collections;

public interface IMovable
{
    void Move();
    void StopMovement(bool shouldStop);
}
