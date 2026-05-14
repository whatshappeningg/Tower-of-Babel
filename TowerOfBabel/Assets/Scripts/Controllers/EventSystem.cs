using Unity.VisualScripting;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    #region Fields
    [SerializeField] private InGameController _inGameController;
    [SerializeField] private UIController _uiController;
    [SerializeField] private InputController _inputController;
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerLevelDetectorUp _playerLevelDetectorUp1;
    [SerializeField] private PlayerLevelDetectorUp _playerLevelDetectorUp2;
    [SerializeField] private PlayerLevelDetectorUp _playerLevelDetectorUp3;
    [SerializeField] private PlayerLevelDetectorUp _playerLevelDetectorUp4;
    [SerializeField] private PlayerLevelDetectorDown _playerLevelDetectorDown1;
    [SerializeField] private PlayerLevelDetectorDown _playerLevelDetectorDown2;
    [SerializeField] private PlayerLevelDetectorDown _playerLevelDetectorDown3;
    [SerializeField] private PlayerLevelDetectorDown _playerLevelDetectorDown4;

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

        _playerLevelDetectorUp1.OnLevelChange += () => OnLevelChange(true);
        _playerLevelDetectorUp2.OnLevelChange += () => OnLevelChange(true);
        _playerLevelDetectorUp3.OnLevelChange += () => OnLevelChange(true);
        _playerLevelDetectorUp4.OnLevelChange += () => OnLevelChange(true);

        _playerLevelDetectorDown1.OnLevelChange += () => OnLevelChange(false);
        _playerLevelDetectorDown2.OnLevelChange += () => OnLevelChange(false);
        _playerLevelDetectorDown3.OnLevelChange += () => OnLevelChange(false);
        _playerLevelDetectorDown4.OnLevelChange += () => OnLevelChange(false);

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
    private void OnLevelChange(bool upDown)
    {
        string level = _inGameController.ChangeLevel(upDown);
        _uiController.UpdateLevelText(level);
    }

    #endregion
}
