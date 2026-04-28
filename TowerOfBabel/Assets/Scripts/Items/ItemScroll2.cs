using UnityEngine;
using System;

public class ItemScroll2 : Item
{

    # region Properties
    public event Action Scroll2Collision;
    public int SCROLL2_DAMAGE = -20;
    #endregion

    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Recolected();

        if (collision.gameObject.tag == "Player")
        {
            Scroll2Collision?.Invoke();
            // Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            // jetpack.AddEnergy(NOSE_DAMAGE);
            Recolected();
        }
    }
    #endregion

}