using System;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    public NavMeshAgent agent;
    
    public Animator animator;
    public bool dead = false;

    public void Kill()
    {
        dead = true;
        agent.enabled = false;
        animator.SetTrigger("Death");
        GameManager.instance.ghostSpawner.currentGhosts--;
        if (GameManager.instance.ghostsRemainingToKill > 0)
        {
            GameManager.instance.ghostsRemainingToKill--;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (GameManager.instance.gameIsOver && !dead)
        {
            Kill();
        }
    }
}
