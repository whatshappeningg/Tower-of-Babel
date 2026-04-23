using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
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

    #endregion

    #region Public Methods
    public void FlyUp()
    {
        if (Energy > 0)
        {
            _targetRB.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
            Flying = false;
    }
    public void FlyHorizontal(float direction)
    {
        _targetRB.AddForce(Vector2.right * _horizontalForce * direction);

    }

    public void Regenerate()
    {
        Energy += _energyRegenerationRatio;
    }

    public void AddEnergy(float energy)
    {
        Energy += energy;
    }

    #endregion

    #region Private Methods
    #endregion
}