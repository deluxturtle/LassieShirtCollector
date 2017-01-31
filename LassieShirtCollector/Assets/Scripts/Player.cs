using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject offScreenObj;
    private Vector2 swipeStartPos;
    private Vector2 swipeCurPos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                swipeStartPos = touch.position;
                Debug.Log("Began: " + swipeStartPos);
            }
            if(touch.phase == TouchPhase.Moved)
            {
                swipeCurPos = touch.position;
                Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(swipeCurPos);
                transform.position = new Vector3(worldTouchPos.x, worldTouchPos.y, 0);
                Debug.Log("Moved: " + swipeCurPos);
            }
            if(touch.phase == TouchPhase.Ended)
            {
                transform.position = offScreenObj.transform.position;
            }
        }


        
	}
}
