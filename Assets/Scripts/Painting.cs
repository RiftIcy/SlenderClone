using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Painting : MonoBehaviour
{
    // Material that's gonna be painted
    public Material paintedMaterial;
    private Renderer renderer;

    private bool isPainted = false;

    private GameObject gameLogic;

    public GameObject paintText;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        gameLogic = GameObject.FindWithTag("GameLogic");
        paintText.SetActive(false);
    }

    private void Update()
    {
        if(gameLogic.GetComponent<GameLogic>().pageCount >= 8)
        {
            paintText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("paintingLayer")))
                {
                    Debug.Log("Click Works");
                    if (hit.collider.gameObject == gameObject)
                    {
                        Debug.Log("Paint Works");
                        Paint();
                        paintText.SetActive(false);
                    }
                }
            }
        }
        
    }

    public void Paint()
    {
        if (paintedMaterial != null && !isPainted)
        {
            renderer.material = paintedMaterial;
            isPainted = true;
            if(isPainted == true)
            {
                SceneManager.LoadScene(4);
            }
        }
    }
}
