using UnityEngine;
using System;

public class ItemScroll2 : Item
{

    # region Properties
    public int SCROLL2_DAMAGE = -20;
    #endregion

    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            Recolected();

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Scroll2 Collision");
            Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();
            jetpack.AddEnergy(SCROLL2_DAMAGE);

            Recolected();
        }
    }
    #endregion

}