using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody _rigidbody;

    private string _axisHorizontal = "Horizontal";
    private string _axisVertical = "Vertical";

    private float _yInput;
    private float _xInput;
    private float _deadZone = 0.05f;
    private float _minJumpDistance = 1.5f;

    private bool _isJump;
    private bool isGrounded;

    public int CoinsValue { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _yInput = Input.GetAxisRaw(_axisVertical);
        _xInput = Input.GetAxisRaw(_axisHorizontal);
        _isJump = Input.GetKeyDown(KeyCode.Space);

        JumpBall();
    }

    private void FixedUpdate()
    {
        MoveBall();
    }

    private void MoveBall ()
    {
        if (_yInput > _deadZone)
            _rigidbody.AddForce(Vector3.forward * _speed, ForceMode.Force);

        if (_yInput < -_deadZone)
            _rigidbody.AddForce(Vector3.back * _speed, ForceMode.Force);

        if (_xInput > _deadZone)
            _rigidbody.AddForce(Vector3.right * _speed, ForceMode.Force);

        if (_xInput < -_deadZone)
            _rigidbody.AddForce(Vector3.left * _speed, ForceMode.Force);
    }

    private void JumpBall()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, _minJumpDistance);

        if (_isJump && isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Force);
    }

    public void AddCoins()
    {
        CoinsValue ++;
    }
}
