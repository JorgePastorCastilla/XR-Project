using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public float spawnInterval = 1.0f;
    public GameObject ghostPrefab;
    
    public float minDistanceToEdge = 0.5f;
    public MRUKAnchor.SceneLabels spawnsLabels;
    public float normalOffset = -1.5f;

    public int maxGhosts = 20;
    public int currentGhosts = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            StartCoroutine(SpawnGhosts());
    }

    private IEnumerator SpawnGhosts()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (currentGhosts < maxGhosts)
            {
                SpawnGhost();
            }
            
        }
        // Instantiate(ghostPrefab, transform.position, Quaternion.identity);
    }

    private void SpawnGhost()
    {
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minDistanceToEdge,
            LabelFilter.Included(spawnsLabels), out Vector3 pos, out Vector3 norm);
        if (hasFoundPosition)
        {
            Vector3 randomPosition = pos + norm * normalOffset;
            randomPosition.y = 0f;
            Instantiate(ghostPrefab, randomPosition, Quaternion.identity);
            currentGhosts++;
        }
    }
}
