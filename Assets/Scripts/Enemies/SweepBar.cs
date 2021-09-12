using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
public class SweepBar : MonoBehaviour, IEnemySpawn
{
    Move move;

    public void SetInfo(float[] arguments)
    {
        Direction dir = (Direction)(int)arguments[0];
        float speed = arguments[1];
        move.SetInfo(dir, speed);
    }

    void Awake()
    {
        move = GetComponent<Move>();
    }
}
