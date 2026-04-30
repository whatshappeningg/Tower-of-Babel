using UnityEngine;

public class PlayerLevelDetector : MonoBehaviour
{
    #region Unity Callbacks
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the level detector.");
            GetComponentInParent<BoxCollider2D>().enabled = true;
        }
    }

    #endregion
}
