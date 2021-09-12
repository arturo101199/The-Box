using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    [SerializeField] Animator rightWall = null;
    [SerializeField] Animator leftWall = null;
    [SerializeField] Animator topWall = null;
    [SerializeField] Animator bottomWall = null;

    int openId;
    int closeId;

    private void Awake()
    {
        openId = Animator.StringToHash("Open");
        closeId = Animator.StringToHash("Close");
    }

    public void OpenWall(Direction dir)
    {
        switch (dir)
        {
            case Direction.RIGHT: rightWall.SetTrigger(openId);
                break;
            case Direction.LEFT: leftWall.SetTrigger(openId);
                break;
            case Direction.UP: topWall.SetTrigger(openId);
                break;
            default: bottomWall.SetTrigger(openId);
                break;
        }
    }

    public void CloseWall(Direction dir)
    {
        switch (dir)
        {
            case Direction.RIGHT: rightWall.SetTrigger(closeId);
                break;
            case Direction.LEFT: leftWall.SetTrigger(closeId);
                break;
            case Direction.UP: topWall.SetTrigger(closeId);
                break;
            default: bottomWall.SetTrigger(closeId);
                break;
        }
    }
}
