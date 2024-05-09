using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackStory : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        // Load the first scene of the game
        SceneManager.LoadScene(2); // Change the scene index if needed
    }
}
