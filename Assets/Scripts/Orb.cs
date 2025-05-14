using System;
using UnityEngine;

public class Orb : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            OrbDeath();
        }
    }

    public void OrbDeath()
    {
        GameManager.instance.currentOrbs--;
        Destroy(gameObject);
    }
}
