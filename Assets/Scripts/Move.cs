using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { RIGHT, LEFT, UP, DOWN}

public class Move : MonoBehaviour
{
    [SerializeField] Direction dir = 0;
    [SerializeField] float speed = 10f;

    Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        switch (dir)
        {
            case Direction.RIGHT:
                moveDir = Vector2.right;
                break;
            case Direction.LEFT:
                moveDir = Vector2.left;
                break;
            case Direction.UP:
                moveDir = Vector2.up;
                break;
            default:
                moveDir = Vector2.down;
                break;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }
}
