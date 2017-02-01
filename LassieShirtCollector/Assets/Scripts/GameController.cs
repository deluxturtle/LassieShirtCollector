using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Easily updates and can add score values through this object.
/// </summary>
public class GameController : MonoBehaviour {

    [Tooltip("Place the shirt amount text here.")]
    public Text shirtAmount;

    int shirtsCollected = 0;

    void Start()
    {
        if(shirtAmount == null)
            Debug.Log("No Shirt Amount text was assigned to the game controller in scene. Please assign Text Object.");
        else
            shirtAmount.text = shirtsCollected.ToString();
    }

    /// <summary>
    /// Adds one shirt to the score
    /// </summary>
	public void AddShirt()
    {
        shirtsCollected++;
        shirtAmount.text = shirtsCollected.ToString();
    }
}
