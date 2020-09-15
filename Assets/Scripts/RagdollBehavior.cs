using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollBehavior : MonoBehaviour
{
    private Animator _animator = null;
    private CharacterController _controller = null;

    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public bool ragdollEnabled
    {
        get { return !_animator.enabled; }
        set
        {
            _controller.enabled = !value;
            _animator.enabled = !value;
            foreach (Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = !value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        ragdollEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
