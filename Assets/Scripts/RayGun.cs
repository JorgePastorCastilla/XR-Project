using System.Collections;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    
    public OVRInput.RawButton shootingButton;  
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
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
        // lineRenderer.enabled = true;
        // yield return new WaitForSeconds(0.05f);
        // lineRenderer.enabled = false;
        
        Ray ray = new Ray(transform.position/*starting point*/, transform.forward/*direction*/);
        bool has_hit = Physics.Raycast(ray, out RaycastHit hit, 3f/*max distance*/, layerMask/*layermask con la que puede interactuar*/);
        
        Vector3 endPoint = Vector3.zero;
        if (has_hit)
        {
            endPoint = hit.point;    
            
            Ghost ghost = hit.transform.GetComponentInParent<Ghost>();

            if (ghost)
            {
                hit.collider.enabled = false;
                ghost.Kill();
            }
            
            Debug.Log($"Ray Hit: {hit.transform.name}");
        }
        else
        {
            Vector3 starting_point = lineRenderer.GetPosition(0);
            endPoint = lineRenderer.GetPosition(0) + Vector3.forward * 5f;
        }
        
        lineRenderer.SetPosition(1, endPoint);
        yield return new WaitForSeconds(0.1f);
        
        lineRenderer.SetPosition(1, lineRenderer.GetPosition(0) );
        
    }
}
