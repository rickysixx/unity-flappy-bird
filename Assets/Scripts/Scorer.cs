using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bird birdComponent = collision.GetComponent<Bird>();

        if (birdComponent != null)
        {
            GameManager.Instance.IncreaseScore();

            Debug.Log("Bird successfully passed through a pipe. Score increased.");
        }
    }
}
