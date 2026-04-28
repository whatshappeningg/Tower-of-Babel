using UnityEngine;
using System;

public class ItemHammer : Item
{
    # region Properties
    public event Action HammerCollision;
    public int POSITIVE_HEAL = 20;
    #endregion

    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Recolected();

        if (collision.gameObject.tag == "Player")
        {
            HammerCollision?.Invoke();
            //Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            //jetpack.AddEnergy(POSITIVE_HEAL);
            Recolected();
        }
    }
    #endregion

}