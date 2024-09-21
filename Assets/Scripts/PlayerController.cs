using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody _rigidbody;

    private string _axisHorizontal = "Horizontal";
    private string _axisVertical = "Vertical";

    private float _deadZone = 0.05f;
    private float _minJumpDistance = 2f;

    private bool _isJump;
    private bool isGrounded;

    public int CoinsValue { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isJump = Input.GetKeyDown(KeyCode.Space);

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 input = new Vector3 (Input.GetAxisRaw(_axisHorizontal), 0, Input.GetAxisRaw(_axisVertical));

        if (input.magnitude >= _deadZone)
        {
            _rigidbody.AddForce(input.normalized * _speed, ForceMode.Force);
        }
    }

    private void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, _minJumpDistance);

        if (_isJump && isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Force);
    }

    public void RemoveForces()
    {
        _rigidbody.isKinematic = true;
    }
}
