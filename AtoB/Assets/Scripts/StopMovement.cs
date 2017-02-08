using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StopMovement : MonoBehaviour
{
    private List<IMovable> movingObjects;
    private bool isGameStopped;

    public void OnEnable()
    {
        this.movingObjects = new List<IMovable>();
        this.isGameStopped = true;
    }

    public void AddObject(IMovable movable)
    {
        movingObjects.Add(movable);
        movable.StopMovement(this.isGameStopped);
    }

    public void OnGameStart()
    {
        this.isGameStopped = false;
        ChangeState();
    }

    public void OnGameEnd()
    {
        this.isGameStopped = true;
        ChangeState();
    }

    private void ChangeState()
    {
        foreach (var obj in movingObjects)
        {
            if (obj == null)
            {
                continue;
            }
            obj.StopMovement(this.isGameStopped);
        }
    }
}
