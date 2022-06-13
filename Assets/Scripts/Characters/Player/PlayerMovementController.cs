using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody2D _body;
    private float _scaleX;
    private float _scaleY;

    private float _moveDirection;
    private float _moveSpeed = 5.0f;

    [SerializeField] private GroundTrigger _groundTrigger;
    [SerializeField] private LayerMask _groundLayerMask;
    private bool _isJumpPressed = false;
    private bool _isJumping = false;
    private float _jumpVelocity = 400f;
    private float _cayoteJumpDuration = 0.25f;
    private float _jumpTimer = 0f;
    private float _groundDetectorRad = 0.1f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
        _scaleY = transform.localScale.y;
    }

    private void Update()
    {
        MoveDirectionHandler();
        JumpInputHandler();
    }

    private void FixedUpdate()
    {
        MovementHandler();
        JumpingForceHandler();
    }

    private void MoveDirectionHandler()
    {
        _moveDirection = Input.GetAxisRaw("Horizontal");

        if (_moveDirection > 0)
        {
            transform.localScale = new Vector2(_scaleX, _scaleY);
        }
        else if (_moveDirection < 0)
        {
            transform.localScale = new Vector2(-_scaleX, _scaleY);
        }
    }

    private void JumpInputHandler()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _isJumpPressed = true;
        }
        else
        {
            _isJumpPressed = false;
        }

        /*_isOnGround = Physics2D.OverlapCircle(_bottomPoint.position, _groundDetectorRad, _groundLayerMask);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isOnGround)
            {
                _isJumping = true;
            }
        }*/
    }

    private void MovementHandler()
    {
        _body.AddForce(new Vector2(_moveDirection * 20.0f, 0.0f));
        if (Mathf.Abs(_body.velocity.x) > _moveSpeed)
        {
            _body.velocity = new Vector2(_moveDirection * _moveSpeed, _body.velocity.y);
        }
    }

    private void JumpingForceHandler()
    {
        if (_groundTrigger.IsGrounded)
        {
            _jumpTimer = _cayoteJumpDuration;
        }
        else
        {
            if (_jumpTimer >= 0)
            {
                _jumpTimer -= Time.fixedDeltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (_isJumpPressed)
        {
            if (_jumpTimer > 0)
            {
                _body.velocity = new Vector2(_body.velocity.x, _jumpVelocity * Time.fixedDeltaTime);
                if (!_isJumping)
                {
                    _isJumping = false;
                }
            }
        }
    }
}
