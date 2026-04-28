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

        _itemHammer.HammerCollision += OnHammerCollision;
        _itemScroll1.Scroll1Collision += OnScroll1Collision;
        _itemScroll2.Scroll2Collision += OnScroll2Collision;
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
    private void OnHammerCollision()
    {
        Debug.Log("Hammer Collision");
        _jetpack.AddEnergy(_itemHammer.POSITIVE_HEAL);
    }
    private void OnScroll1Collision()
    {
        Debug.Log("Scroll1 Collision");
        if (_player.Flying)
            _jetpack.GetComponent<Rigidbody2D>().AddForce(Vector2.down * _itemScroll1.SCROLL1_FORCE);
        else
            if (_jetpack.transform.position.y > 1)
                _jetpack.transform.Translate(Vector2.down * _itemScroll1.SCROLL1_DOWN_POS);

    }
    private void OnScroll2Collision()
    {
        Debug.Log("Scroll2 Collision");
        _jetpack.AddEnergy(_itemScroll2.SCROLL2_DAMAGE);

    }
    #endregion
}
