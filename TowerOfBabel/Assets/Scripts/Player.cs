using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    #region Properties
    public bool _onGround;
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
        if (!_onGround)
            _anim.SetBool("Flying", true);
        else
        {
            _anim.SetBool("Flying", false);
            _anim.SetBool("Walking", _inputController.IsWalking);
        }
    }
    #endregion

    #region Public Methods
    public void Movement(float direction)
    {
        _rb.velocity = new Vector2(direction * _playerSpeed, _rb.velocity.y);

    }

    public void NoMovement()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public float ManageDirection(float direction)
    {
        direction /= Mathf.Abs(direction);
        if (direction < 0)
            _spriteRenderer.flipX = false;
        else if (direction > 0)
            _spriteRenderer.flipX = true;

        return direction;

    }
    #endregion

    #region Private Methods
    #endregion

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") && !_inputController.IsFlying)
        {
            _onGround = true;

        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            _onGround = false;

        }

    }
}