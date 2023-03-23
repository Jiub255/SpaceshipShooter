using System.Collections;
using UnityEngine;

public class Bullet : Projectile
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{gameObject.name} hit {collision.name}.");
        
        // TODO: Use IDamageable interface instead of inheriting from Health? Or do both? 
        // Because then you could just look for IDamageable on projectile scripts, could include objects/buildings and other stuff. 
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.GetHurt(_damage);
        }

        // Start coroutine where you disable the sprite renderer for the bullet and activate
        // an explosion particle child object for a quick second. Then you deactivate the bullet, and reenable the 
        // bullet sprite and deactivate the particle effect child in OnDisable. 
        StartCoroutine(BulletHitEffect());
        //gameObject.SetActive(false);
    }

    private IEnumerator BulletHitEffect()
    {
        // Disable bullet sprite. 
        GetComponent<SpriteRenderer>().enabled = false;

        // Play particle effect. 
        _impactParticleEffect.Play();

        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }

    protected override void OnDisable()
    {
        // Reenable bullet sprite renderer.
        GetComponent<SpriteRenderer>().enabled = true;
    }
}