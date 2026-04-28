using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

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
    public bool FlyingUp { get; set; }
    public bool FlyingHorizontal { get; set; }
    public float Direction { get; set; }
    #endregion

    #region Fields		
    private Rigidbody2D _targetRB;
    [SerializeField] private float _energy;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    private Vector2 _force;

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
        if (FlyingUp)
        {
            FlyUp();
        }

    }

    #endregion

    #region Public Methods
    public void FlyUp()
    {
        if (Energy > 0)
        {
            if (FlyingHorizontal)
            {
                Debug.Log("Flying Horizontal: " + Direction * _horizontalForce);
                _targetRB.velocity = new Vector2(Direction * _horizontalForce, _flyForce);
            }
            //_force = (Vector2.up * _flyForce) + (Vector2.right * _horizontalForce * Direction);

            else
                _targetRB.velocity = new Vector2(_targetRB.velocity.x, _flyForce);

            //_force = Vector2.up * _flyForce;

            //_targetRB.AddForce(_force);

            Energy -= _energyFlyingRatio;
        }

    }
    // public void FlyUp()
    // {
    //     if (Energy > 0)
    //     {
    //         float y = _flyForce;
    //         if (FlyingHorizontal)
    //             float x = Direction * _horizontalForce;
    //         else
    //             float x = _targetRB.velocity.x;



    //             _targetRB.velocity = new Vector2(x, y);
    //         {
    //             _targetRB.velocity = new Vector2(_targetRB.velocity.x, _flyForce);
    //         }

    //         Energy -= _energyFlyingRatio;
    //     }
    // }

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