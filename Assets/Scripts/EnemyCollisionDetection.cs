using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle the collision between enemy and player
            Debug.Log("Enemy collided with the player!");
            // Add your logic here, such as damaging the player, triggering a game over, etc.
        }
    }
}
