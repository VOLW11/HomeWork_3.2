using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int Coin {  get; private set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;

    private Rigidbody _rigidbody;

    private string axisHorizontal = "Horizontal";
    private string axisVertical = "Vertical";

    private float _yInput;
    private float _xInput;
    private float _deadZone = 0.05f;

    private bool _isJump;
    private int _coinsValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _yInput = Input.GetAxisRaw(axisVertical);
        _xInput = Input.GetAxisRaw(axisHorizontal);

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
        if (_isJump)
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Force);
    }

    public void AddCoins()
    {
        _coinsValue ++;

        Coin =_coinsValue;
    }
}
