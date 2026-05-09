using UnityEngine;
using System;

public class PlayerLevelDetectorDown : MonoBehaviour
{
    #region Fields
    [SerializeField] private EdgeCollider2D _edgeColliderUp;

    #endregion

    #region Properties
    public event Action OnLevelChange;

    #endregion

    #region Unity Callbacks
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<BoxCollider2D>().enabled = false;
            GetComponent<EdgeCollider2D>().enabled = false;
            _edgeColliderUp.enabled = true;

            OnLevelChange?.Invoke();
        }
    }

    #endregion
}
