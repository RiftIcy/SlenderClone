using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseText;

    private bool isPaused = false;

    void Start()
    {
        if (pauseText != null)
            pauseText.SetActive(false);
    }

    void Update()
    {
        // Check for input to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (isPaused)
            return;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;
            if (pauseText != null)
                pauseText.SetActive(true);
            // Lock the cursor
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f;
            if (pauseText != null)
                pauseText.SetActive(false);
            // Unlock the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
