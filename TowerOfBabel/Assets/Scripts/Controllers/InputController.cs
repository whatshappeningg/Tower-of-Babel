using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{
    #region Properties
    public float Direction { get; set; }
    public event Action IsFlying;
    public event Action IsFlyingHorizontal;
    public event Action IsNotFlying;
    public event Action IsWalking;
    public event Action IsMoving;
    public event Action IsNotMoving;

    #endregion

    #region Fields
    private bool _isFlying;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        _isFlying = false;
    }
    void Update()
    {
        Direction = CalculateDirection(Input.GetAxis("Horizontal"));

        // Horizontal Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            IsMoving?.Invoke();

            if (_isFlying)
            {
                IsFlyingHorizontal?.Invoke();

            }
            else
            {
                IsWalking?.Invoke();

            }
        }
        else
        {
            IsNotMoving?.Invoke();
        }

        // Vertical Movement
        if (Input.GetAxis("Vertical") > 0)
        {
            IsFlying?.Invoke();
            _isFlying = true;
        }
        else
        {
            IsNotFlying?.Invoke();
            _isFlying = false;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }

    #endregion

    #region Private Methods
    private float CalculateDirection(float axis)
    {
        if (axis < 0)
            return -1;
        else if (axis > 0)
            return 1;
        else
            return 0;
    }

    #endregion
}
