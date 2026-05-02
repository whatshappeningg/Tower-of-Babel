using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
    #region Properties
    public bool Flying { get; set; }
    public bool Moving { get; set; }
    public bool NotMoving { get; set; }
    public float Direction { get; set; }
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
    void FixedUpdate()
    {
        if (Moving)
        {
            Movement(Direction);
        }
        else if (NotMoving && _onGround)
        {
            NoMovement();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform") && !Flying)
        {
            _onGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            Flying = true;
            _onGround = false;

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
        Debug.Log("Velocity change");
        _anim.SetBool("Walking", false);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
    }
    public void ManageDirection(float direction)
    {
        if (direction < 0)
            _spriteRenderer.flipX = false;
        else if (direction > 0)
            _spriteRenderer.flipX = true;
    }

    #endregion

}