using UnityEngine;
using System.Collections;

enum AnimName
{
    Idle,
    WalkRight,
    WalkLeft
}

/// <summary>
/// Author: Andrew Seba
/// Description: Controls the player movement.
/// </summary>
public class Player : MonoBehaviour {

    private string animParameter = "animNum";
    private Animator animator;
    private Vector2 swipeCurPos;
    private Vector2 middleScreenPos = new Vector2(0.5f, 0.5f);
    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                swipeCurPos = touch.position;
                if(Camera.main.ScreenToViewportPoint(swipeCurPos).x < middleScreenPos.x)
                {
                    animator.SetInteger(animParameter, (int)AnimName.WalkLeft);
                }
                else
                {
                    animator.SetInteger(animParameter, (int)AnimName.WalkRight);

                }
            }
            else
            {
                animator.SetInteger(animParameter, (int)AnimName.Idle);
            }
        }


        
	}
}
