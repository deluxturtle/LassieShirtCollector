using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Moves the shirt down the screen;
/// </summary>
public class Shirt : MonoBehaviour {

    public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
	}
}
