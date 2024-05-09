using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursorOnLoad : MonoBehaviour
{
    void Start()
    {
        // Unlock the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

