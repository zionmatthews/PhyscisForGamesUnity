using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RagdollTrigger : MonoBehaviour
{
    private Animator ragdoll;
   
    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ragdoll.enabled = !ragdoll.enabled;
            
        }

        
            
    } 
    
}
