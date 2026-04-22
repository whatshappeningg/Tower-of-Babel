using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    #region Properties
    public bool IsFlying { get; set; }
    public bool IsWalking { get; set; }

    #endregion

    #region Fields
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Player _player;


    #endregion

    #region Unity Callbacks
    void Start()
    {
        IsFlying = false;
        IsWalking = false;
    }
    void Update()
    {
        if (IsFlying)
        {// Horizontal fly
            if (Input.GetAxis("Horizontal") < 0)
                _jetpack.FlyHorizontal(Jetpack.Direction.Left);

            else if (Input.GetAxis("Horizontal") > 0)
                _jetpack.FlyHorizontal(Jetpack.Direction.Right);
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            IsWalking = true;
            _player.Movement(Input.GetAxis("Horizontal"));

        }
        else
        {
            _player.NoMovement();
            IsWalking = false;
        }

        // Vertical fly
        if (Input.GetAxis("Vertical") > 0)
            IsFlying = true;

        else
            IsFlying = false;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
