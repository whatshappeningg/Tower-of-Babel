using UnityEngine;
using System;

public class PlayerLevelDetectorUp : MonoBehaviour
{
    #region Fields
    [SerializeField] private EdgeCollider2D _edgeColliderDown;

    #endregion

    #region Properties
    public event Action OnLevelChange;

    #endregion

    #region Unity Callbacks
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<BoxCollider2D>().enabled = true;
            GetComponent<EdgeCollider2D>().enabled = false;
            _edgeColliderDown.enabled = true;

            OnLevelChange?.Invoke();
        }
    }

    #endregion
}
