using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxFlyTimeSeconds = 1f;
    void Update()
    {
        if(maxFlyTimeSeconds <= 0)
        {
            ReturnToPlayer();
        }        
        maxFlyTimeSeconds -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            
            other.GetComponent<Enemy>().TakeDamage(50);

            ReturnToPlayer();
        }
        if (other.CompareTag("Walls"))
        {
            ReturnToPlayer();
        }
    }

    void ReturnToPlayer()
    {
        Destroy(gameObject);
    }
}
