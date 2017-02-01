using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Controls the shirts that are spawning from the sky.
/// </summary>
public class ShirtSpawner : MonoBehaviour {

    [Tooltip("Place the shirt you want to spawn here.")]
    public GameObject shirt;

	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnShirts");
	}

    IEnumerator SpawnShirts()
    {
        while (true)
        {
            //get x pos of screen
            float xPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0)).x;
            Vector2 spawnPos = new Vector2(xPos, transform.position.y);
            Instantiate(shirt, spawnPos, Quaternion.identity);
            float random = Random.Range(0.5f, 2);
            yield return new WaitForSeconds(random);
            yield return null;
        }
    }
	
}
