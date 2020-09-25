using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour
{
    private float mcordz;   
    private void OnMouseDrag()
    {
        mcordz = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mousepoint = Input.mousePosition;
        mousepoint.z = mcordz;
        Vector3 FinalPos = Camera.main.ScreenToWorldPoint(mousepoint);
        transform.position = FinalPos;  

    }

    
}
