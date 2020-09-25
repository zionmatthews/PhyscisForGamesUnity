using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(Animator))]
public class PlayerMovementBehavior : MonoBehaviour
{
    private CharacterController _controller = null;
    private Animator _animator = null;

    public float speed;
    public float pushPower;
    public float turnRate;
    public float turn;

    private GameObject ragdoll;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        
        if( Input.GetKey(KeyCode.W))
        {
            _animator.SetInteger("condition", 1);
            movement = new Vector3(0, 0, 1);
            movement *= speed;
            movement = transform.TransformDirection(movement);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetInteger("condition", 0);
            movement = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetInteger("condition", 1);
            movement = new Vector3(0, 0, -1);
            movement *= speed;
            movement = transform.TransformDirection(movement);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetInteger("condition", 0);
            movement = new Vector3(0, 0, 0);
        }

        turn += Input.GetAxis("Horizontal") * turnRate * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, turn, 0);

        _controller.Move(movement * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody otherRB = hit.rigidbody; ;
        if (otherRB == null || otherRB.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3f)
            return;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        otherRB.AddForceAtPosition(pushDirection * pushPower, hit.point);
    }

   
}
