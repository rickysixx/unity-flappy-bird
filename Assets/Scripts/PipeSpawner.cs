using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeContainerReference;

    [SerializeField]
    private float spawnRate = 1f,
                  minHeight = -1f,
                  maxHeight = 1f,
                  minGap = 9f,
                  maxGap = 9f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipes), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipes));
    }

    private void SpawnPipes()
    {
        GameObject spawnedPipeContainer = Instantiate(pipeContainerReference, transform.position, Quaternion.identity);
        PipeContainer pipeContainerComponent = spawnedPipeContainer.GetComponent<PipeContainer>();
        float gap = Random.Range(minGap, maxGap);
        Vector3 topPipePosition = pipeContainerComponent.TopPipe.transform.position;
        Vector3 bottomPipePosition = pipeContainerComponent.BottomPipe.transform.position;

        spawnedPipeContainer.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        topPipePosition.y = gap / 2;
        bottomPipePosition.y = -topPipePosition.y;
        pipeContainerComponent.TopPipe.transform.position = topPipePosition;
        pipeContainerComponent.BottomPipe.transform.position = bottomPipePosition;

        Debug.Log("Spawned a pipe pair at [(" + spawnedPipeContainer.transform.position.x + ", " + spawnedPipeContainer.transform.position.y + ") with a gap of [" + gap + "].");
    }
}
