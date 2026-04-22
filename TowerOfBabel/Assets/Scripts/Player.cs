using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] private InputController _inputController;
    [SerializeField] private float _playerSpeed = 5f;
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _anim.SetBool("Flying", _inputController.IsFlying);
        _anim.SetBool("Walking", _inputController.IsWalking);
    }
    #endregion

    #region Public Methods
    public void Movement(float direction)
    {
        direction /= Mathf.Abs(direction);
        //transform.position += _playerSpeed * direction * Time.deltaTime * Vector3.right;
        //_rb.AddForce(Vector2.right * _playerSpeed * direction);
        _rb.velocity = new Vector2(direction * _playerSpeed, _rb.velocity.y);

        if (direction < 0)
            _spriteRenderer.flipX = false;
        else if (direction > 0)
            _spriteRenderer.flipX = true;
    }

    public void NoMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }
    #endregion

    #region Private Methods
    #endregion

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         _jetpack.Flying = false;
    //     }
    // }
}