using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Animator animator;

    public void Kill()
    {
        agent.enabled = false;
        animator.SetTrigger("Death");
        GameManager.instance.ghostSpawner.currentGhosts--;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
