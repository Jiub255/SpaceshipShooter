using UnityEngine;

public class Bullet : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{gameObject.name} hit {collision.name}.");
        
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.GetHurt(_damage);
        }

        // Start coroutine where you disable the sprite renderer for the bullet and activate
        // an explosion particle child object for a quick second. Then you deactivate the bullet, and reenable the 
        // bullet sprite and deactivate the particle effect child in OnDisable. 
        gameObject.SetActive(false);
    }

    protected override void OnDisable()
    {
        // Reenable bullet sprite renderer.

        // Deactivate particle effect child object. 

    }
}