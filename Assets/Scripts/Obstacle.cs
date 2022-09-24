using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird birdComponent = collision.GetComponent<Bird>();

        if (birdComponent != null)
        {
            Debug.Log("Player hit an obstacle. Game over.");

            GameManager.Instance.GameOver();
        }
    }
}
