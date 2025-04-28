using System.Collections;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    
    public OVRInput.RawButton shootingButton;  
    public LineRenderer lineRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Debug.Log("Shoot");
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot(){
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        lineRenderer.enabled = false;
    }
}
