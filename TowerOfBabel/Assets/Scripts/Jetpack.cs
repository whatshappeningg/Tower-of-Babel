using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    public enum Direction
    {
        Left,
        Right
    }

    #region Properties
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    public bool Flying { get; set; }
    #endregion

    #region Fields		
    [SerializeField] private InputController _inputController;
    [SerializeField] private Player _player;

    private Rigidbody2D _targetRB;
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _targetRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Energy = _maxEnergy;
    }

    void FixedUpdate()
    {
        if (_inputController.IsFlying)
            DoFly();

        //Le quitamos el signo a la velocidad si es negativa.
        //Luego si es menor de 0.1, consideramos que estamos parados y cargamos
        if (_player._onGround)
            Regenerate();
    }

    #endregion

    #region Public Methods
    public void FlyUp()
    {
        Flying = true;
    }
    public void StopFlying()
    {
        Flying = false;
    }

    public void Regenerate()
    {
        Energy += _energyRegenerationRatio;
    }

    public void AddEnergy(float energy)
    {
        Energy += energy;
    }

    public void FlyHorizontal(float direction)
    {
        _targetRB.AddForce(Vector2.right * _horizontalForce * direction);

    }
    #endregion

    #region Private Methods
    private void DoFly()
    {
        if (Energy > 0)
        {
            _targetRB.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
            Flying = false;
    }
    #endregion
}