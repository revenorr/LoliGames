using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Laser : MonoBehaviour

{
    private LineRenderer lineRenderer;
    public LayerMask layerMask;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
       
    }

    void LateUpdate()
    {
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, layerMask))
        
            {
            
                if (hit.collider)
                {
                lineRenderer.SetPosition(1, hit.point);
                }

            }
            else lineRenderer.SetPosition(1, transform.forward * 5000);
        
        
    }

}



