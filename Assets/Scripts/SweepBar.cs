using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepBar : MonoBehaviour
{
    [SerializeField] Transform rect1;
    [SerializeField] Transform rect2;
    [SerializeField] float moveTime = 0.5f;

    SpriteRenderer[] sp1;
    SpriteRenderer[] sp2;

    float alpha1;
    float alpha2;
    float smooth1;
    float smooth2;

    bool isSp1Up;
    bool isSp2Up;

    private void Awake()
    {
        sp1 = rect1.GetComponentsInChildren<SpriteRenderer>();
        sp2 = rect2.GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        alpha1 = 1;
        alpha2 = 0;
        isSp1Up = true;
        isSp2Up = false;
        setAlpha(sp1, alpha1);
        setAlpha(sp2, alpha2);
    }

    private void setAlpha(SpriteRenderer[] sp, float a)
    {
        foreach (SpriteRenderer sprite in sp)
        {
            Color tmp = sprite.color;
            tmp.a = a;
            sprite.color = tmp;
        }
    }

    void Update()
    {
        if (isSp1Up)
        {
            isSp2Up = fadeRects(sp1, sp2, rect1);
        }
        if (isSp2Up)
        {
            isSp1Up = fadeRects(sp2, sp1, rect2);
        }
    }

    bool fadeRects(SpriteRenderer[] spTop, SpriteRenderer[] spBottom, Transform rectMoving)
    {
        //Apagar el de arriba
        alpha1 = Mathf.SmoothDamp(alpha1, 0, ref smooth1, moveTime);
        if (alpha1 <= 0.05) alpha1 = 0;
        setAlpha(spTop, alpha1);

        //Encender el de abajo
        alpha2 = Mathf.SmoothDamp(alpha2, 1, ref smooth2, moveTime);
        if (alpha2 >= 0.95) alpha2 = 1;
        setAlpha(spBottom, alpha2);

        //Mover el de arriba a abajo
        if (alpha1 == 0 && alpha2 == 1)
        {
            rectMoving.Translate(Vector3.down);
            alpha1 = 1f;
            alpha2 = 0f;
            return true;
        }
        return false;
    }
}
