using UnityEngine;

public class LastCollider : MonoBehaviour
{
    #region Fields
    private Jetpack _jetpack;
    #endregion

    #region Unity Callbacks
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _jetpack = other.GetComponent<Jetpack>();
            _jetpack.Energy = 0f;
        }
    }

    #endregion
}
