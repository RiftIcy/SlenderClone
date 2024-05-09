using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add an onClick listener to the button
        button.onClick.AddListener(OnPlayAgainClicked);
    }

    // Function to be called when the "Play Again" button is clicked
    public void OnPlayAgainClicked()
    {
        // Load the first scene of the game
        SceneManager.LoadScene(1); // Change the scene index if needed
    }
}
