using System.Collections;
using Meta.XR.MRUtilityKit;
using Unity.AI.Navigation;
using UnityEngine;

public class RuntimeNavMeshBuilder : MonoBehaviour
{

    private NavMeshSurface navMeshSurface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavMesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildNavMesh()
    {
        StartCoroutine(BuildNavMeshRoutine());
    }

    public IEnumerator BuildNavMeshRoutine()
    {
        yield return new WaitForEndOfFrame();
        navMeshSurface.BuildNavMesh();
    }
}
