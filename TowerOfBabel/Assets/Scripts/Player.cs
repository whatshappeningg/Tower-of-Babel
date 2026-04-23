using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    #region Properties
    public bool IsFlying { get; set; }
    public event Action OnGround;
    #endregion

    #region Fields
    [SerializeField] private float _playerSpeed = 5f;
    private Animator _anim;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private bool _onGround;

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
            OnGround?.Invoke();
            _anim.SetBool("Flying", false);
        }
    }
    #endregion

    #region Public Methods
    public void Movement(float direction)
    {
        _anim.SetBool("Walking", true);
        _rb.velocity = new Vector2(direction * _playerSpeed, _rb.velocity.y);

    }

    public void NoMovement()
    {
        _anim.SetBool("Walking", false);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }

    public float ManageDirection(float direction)
    {
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") && !IsFlying)
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