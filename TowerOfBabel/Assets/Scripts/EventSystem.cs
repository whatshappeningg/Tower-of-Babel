using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputController _inputController;
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Player _player;
    [SerializeField] private ItemHammer _itemHammer;
    [SerializeField] private ItemScroll1 _itemScroll1;
    [SerializeField] private ItemScroll2 _itemScroll2;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        _inputController.IsFlying += OnFly;
        _inputController.IsFlyingHorizontal += OnFlyHorizontal;
        _inputController.IsNotFlying += OnNotFlying;
        _inputController.IsWalking += OnWalking;
        _inputController.IsMoving += OnMoving;
        _inputController.IsNotMoving += OnNotMoving;

        _player.OnGround += OnGround;

    }

    #endregion

    #region Private Methods
    private void OnFly()
    {
        _player.Flying = true;
        _jetpack.FlyingUp = true;
    }
    private void OnFlyHorizontal()
    {
        _jetpack.Direction = _inputController.Direction;
        _jetpack.FlyingUp = false;
        _jetpack.FlyingHorizontal = true;
    }

    private void OnNotFlying()
    {
        _jetpack.FlyingUp = false;
        _jetpack.FlyingHorizontal = false;
    }

    private void OnWalking()
    {
        _player.Direction = _inputController.Direction;
        _player.Flying = false;
        _player.Moving = true;
    }
    private void OnMoving()
    {
        _player.ManageDirection(_inputController.Direction);
    }
    private void OnNotMoving()
    {
        _jetpack.FlyingUp = false;
        _jetpack.FlyingHorizontal = false;
        _player.Flying = false;
        _player.Moving = false;
        _player.NotMoving = true;
    }

    private void OnGround()
    {
        _jetpack.FlyingUp = false;
        _jetpack.FlyingHorizontal = false;
        _jetpack.Regenerate();
    }

    #endregion
}
