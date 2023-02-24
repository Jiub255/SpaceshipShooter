using UnityEngine;

public class CleanUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Deactivated {collision.gameObject.name}");
        collision.gameObject.SetActive(false);
    }
}