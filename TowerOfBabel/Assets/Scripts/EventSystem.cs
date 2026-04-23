using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputController _inputController;
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Player _player;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        _inputController.IsFlying += OnFly;
        _inputController.IsFlyingHorizontal += OnFlyHorizontal;
        _inputController.IsWalking += OnWalking;
        _inputController.IsMoving += OnMoving;
        _inputController.IsNotMoving += OnNotMoving;

        _player.OnGround += OnGround;
    }

    #endregion

    #region Private Methods
    private void OnFly()
    {
        _player.IsFlying = true;
        _jetpack.FlyUp();
    }
    private void OnFlyHorizontal()
    {
        _player.IsFlying = true;
        _jetpack.FlyHorizontal(_inputController.Direction);
    }
    private void OnWalking()
    {
        _player.IsFlying = false;
        _player.Movement(_inputController.Direction);
    }
    private void OnMoving()
    {
        _player.ManageDirection(_inputController.Direction);
    }
    private void OnNotMoving()
    {
        _player.NoMovement();
    }

    private void OnGround()
    {
        _player.IsFlying = false;
        _jetpack.Regenerate();
    }
    #endregion
}
