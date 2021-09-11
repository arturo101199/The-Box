using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float tpSpeed = 5f;
    [SerializeField] TPShadow shadow = null;

    float x;
    float y;
    bool isTeleporting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        getMovementInput();
        if (isTeleporting) moveToShadow();
        else if (Input.GetButtonDown("Jump"))
        {
            if (!isTeleporting) 
            {
                if (!shadow.IsPlaced) shadow.Place();
                else
                {
                    isTeleporting = true;
                    Time.timeScale = 0f;
                }
            }
        }
        else move();
    }
    
    void getMovementInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }

    void moveToShadow()
    {
        Vector3 myPos = transform.position;
        Vector3 shadowPos = shadow.GetPos();

        transform.position = Vector3.MoveTowards(myPos, shadowPos, Time.unscaledDeltaTime * tpSpeed);
        if (myPos == shadowPos)
        {
            isTeleporting = false;
            Time.timeScale = 1f;
            shadow.ChasePlayer();
        }
    }

    void move()
    {
        Vector2 movement = new Vector2(x, y);
        movement = Vector2.ClampMagnitude(movement, 1f);
        transform.Translate(movement * Time.deltaTime * speed);
        float clampedX = Mathf.Clamp(transform.position.x, -5.8f, 5.8f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.8f, 4.8f);
        transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

}
