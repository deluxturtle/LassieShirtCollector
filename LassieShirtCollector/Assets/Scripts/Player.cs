using UnityEngine;
using System.Collections;

enum AnimName
{
    Idle,
    WalkRight,
    WalkLeft
}

enum PlayerState
{
    Standing,
    MovingRight,
    MovingLeft
}

/// <summary>
/// Author: Andrew Seba
/// Description: Controls the player movement.
/// </summary>
public class Player : MonoBehaviour {

    [Header("Player Settings")]
    public float speed = 2f;
    [Header("Misc")]
    [Tooltip("Place the game controller object here from hierarchy.")]
    public GameController gameController;

    private PlayerState pState = PlayerState.Standing;
    private string animParameter = "animNum";
    private Animator animator;
    private Vector2 swipeCurPos;
    private Vector2 middleScreenPos = new Vector2(0.5f, 0.5f);
    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
        if(gameController == null)
        {
            gameController = GameObject.FindObjectOfType<GameController>();
            if(gameController == null)
            {
                Debug.Log("No Game controller assigned and/or found in scene. Check Scene.");
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

        #region ControllerInput
        Vector2 controllerInput = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += new Vector3(controllerInput.x, 0) * speed * Time.deltaTime;
        if(controllerInput.x > 0.2f)
        {
            pState = PlayerState.MovingRight;
        }
        else if(controllerInput.x < -0.2f)
        {
            pState = PlayerState.MovingLeft;
        }
        else
        {
            pState = PlayerState.Standing;
        }
        #endregion

        #region TouchInput
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                swipeCurPos = touch.position;
                if(Camera.main.ScreenToViewportPoint(swipeCurPos).x < middleScreenPos.x)
                {
                    pState = PlayerState.MovingLeft;
                }
                else
                {
                    pState = PlayerState.MovingRight;
                }
            }
            else
            {
                pState = PlayerState.Standing;
            }
        }
        #endregion

        //Do animation
        switch (pState)
        {
            case PlayerState.Standing:
                animator.SetInteger(animParameter, (int)AnimName.Idle);
                break;
            case PlayerState.MovingRight:
                animator.SetInteger(animParameter, (int)AnimName.WalkRight);
                break;
            case PlayerState.MovingLeft:
                animator.SetInteger(animParameter, (int)AnimName.WalkLeft);
                break;
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shirt")
        {
            gameController.AddShirt();
            Destroy(other.gameObject);
        }
    }
}
