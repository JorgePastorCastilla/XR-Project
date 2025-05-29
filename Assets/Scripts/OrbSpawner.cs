using System;
using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public MRUKAnchor.SceneLabels spawnsLabels;
    public float minDistanceToEdge = 0.0f;
    public GameObject orbPrefab;
    
    
    
    public void SpawnOrbs()
    {
        for (int i = 0; i < GameManager.instance.maxOrbs; i++)
        {
            SpawnOrb();
        }
        GameManager.instance.gameIsReady = true;
    }
    public IEnumerator SpawnOrbsCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SpawnOrbs();
        StopCoroutine(SpawnOrbsCoroutine());
    }
    public void SpawnOrb()
    {
        Vector3 pos = Vector3.zero;
        Vector3 norm = Vector3.zero;
        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        bool hasFoundPosition = false;
        while (!hasFoundPosition)
        {
            Debug.Log("TRY FIND ORB LOCATION");
            hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, minDistanceToEdge,
                LabelFilter.Included(spawnsLabels), out pos, out norm);
        }
        
        Debug.Log("TRY SPAWN ORB");
        Vector3 randomPosition = pos + norm;
        randomPosition.y = 1f;
        Instantiate(orbPrefab, randomPosition, Quaternion.identity);
        GameManager.instance.currentOrbs++;
    }

    void Start()
    {
        StartCoroutine(SpawnOrbsCoroutine());
    }
    
}
