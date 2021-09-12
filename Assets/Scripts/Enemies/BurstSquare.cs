using UnityEngine;

[RequireComponent(typeof(BurstMovement))]
public class BurstSquare : MonoBehaviour
{
    BurstMovement move;

    public void SetInfo(float[] arguments)
    {
        Direction dir = (Direction)(int)arguments[0];
        float speed = arguments[1];
        move.SetInfo(dir, speed);
    }

    void Awake()
    {
        move = GetComponent<BurstMovement>();
    }
}