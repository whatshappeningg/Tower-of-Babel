using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jetpack : MonoBehaviour
{
    #region Properties
    public float Energy { get; set; }

    #endregion

    #region Fields
    [SerializeField] private Rigidbody _target;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;

    private bool _flying = false;

    #endregion

    #region Unity Callbacks
    void Start()
    {
        Energy = _maxEnergy;

    }

    void FixedUpdate()
    {
        if (_flying)
        {
            DoFly();
        }
    }

    #endregion

    #region Public Methods
    public void FlyUp()
    {
        _flying = true;

    }

    public void StopFlying()
    {
        _flying = false;

    }


    public void Regenerate()
    {
        Energy += _energyRegenerationRatio * Time.fixedDeltaTime;
        if (Energy > _maxEnergy)
            Energy = _maxEnergy;
    }

    public void RegenerateExtra(float energy)
    {
        Energy += energy;
        if (Energy > _maxEnergy)
            Energy = _maxEnergy;

        if (Energy < 0)
            Energy = 0;
    }

    public void FlyMovement(bool leftMovement)
    {
        if (leftMovement)
            _target.AddForce(Vector2.left * _horizontalForce);

        else
            _target.AddForce(Vector2.right * _horizontalForce);


    }

    #endregion

    #region Private Methods
    private void DoFly()
    {
        _target.AddForce(Vector2.up * _flyForce);
        Energy -= _energyFlyingRatio * Time.fixedDeltaTime;
    }

    # endregion
}
