using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add an onClick listener to the button
        button.onClick.AddListener(OnMainMenuClicked);
    }

    // Function to be called when the "Main Menu" button is clicked
    public void OnMainMenuClicked()
    {
        // Load the first scene of the game
        SceneManager.LoadScene(0); // Change the scene index if needed
    }
}
