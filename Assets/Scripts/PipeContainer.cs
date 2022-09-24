using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeContainer : MonoBehaviour
{
    private float screenLeftEdge;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private GameObject topPipe,
                       bottomPipe;

    public GameObject TopPipe
    {
        get => topPipe;
    }

    public GameObject BottomPipe
    {
        get => bottomPipe;
    }

    private void Start()
    {
        // calculates screen left edge to destroy pipes when they go beyond it
        screenLeftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void DestroyWhenOffScreen()
    {
        if (transform.position.x < screenLeftEdge)
        {
            Destroy(gameObject);

            Debug.Log("Pipe destroyed.");
        }
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;

        DestroyWhenOffScreen();
    }
}
