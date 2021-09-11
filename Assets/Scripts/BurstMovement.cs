using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMovement : MonoBehaviour
{
    [SerializeField] Direction dir = 0;
    [SerializeField] float speed = 10f;

    const float INIT_ANIM_TIME = 2f;

    Vector2 moveDir = Vector2.zero;
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer >= INIT_ANIM_TIME)
            transform.Translate(moveDir * speed * Time.deltaTime, Space.World);
        else timer += Time.deltaTime;
    }
}
