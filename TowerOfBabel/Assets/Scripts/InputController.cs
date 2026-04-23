using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        float direction = _player.ManageDirection(Input.GetAxis("Horizontal"));
        _player.ManageDirection(Input.GetAxis("Horizontal"));

        // Horizontal Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (IsFlying)
            {
                _jetpack.FlyHorizontal(direction);

            }
            else
            {
                IsWalking = true;
                _player.Movement(direction);

            }
        }
        else
        {
            _player.NoMovement();
            IsWalking = false;
        }

        // Vertical Movement
        if (Input.GetAxis("Vertical") > 0)
            IsFlying = true;
        else
            IsFlying = false;

        if (Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");

    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
