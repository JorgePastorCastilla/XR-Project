using UnityEngine;
using UnityEngine.AI;

public class GhostMove : MonoBehaviour
{
    public NavMeshAgent agent;

    public float speed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 destination = Camera.main.transform.position;
        FindDestination();
        // agent.SetDestination(destination);
        agent.speed = speed;
    }

    public void FindDestination()
    {
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orb");

        float? minDistance = null;
        Vector3 destination = gameObject.transform.position;
        foreach (GameObject orb in orbs)
        {
            float distance = Vector3.Distance(gameObject.transform.position, orb.transform.position);

            if (minDistance == null || distance < minDistance)
            {
                minDistance = distance;
                destination = orb.transform.position;
            }
        }
        agent.SetDestination(destination);
    }
}
