using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    void Start()
    {
        // Get the Button component attached to this GameObject
        Button button = GetComponent<Button>();

        // Add an onClick listener to the button
        button.onClick.AddListener(OnQuit);
    }
    public void OnQuit()
    {
            Application.Quit();
    }
}
