using UnityEditor.PackageManager;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Speed Settings")]
    [SerializeField] float speed = 20f;
    public int damage;
    Enemy enemy;

    private Rigidbody2D rb;
    



    void Start()
    {
       //Rigidbody2D reference
        rb = GetComponent<Rigidbody2D>();
        if ( rb != null )
            rb.gravityScale = 0;

        //Set the bullet's velocity to move to the right
        rb.linearVelocity = transform.right * speed;
        //BulletDirection(this);

        //Destroy the bullet after 2 seconds to avoid memory leaks
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(50);
            //Debug.Log("Bullet collided with " + collision.name);
            //Destroy the bullet on collision with any object
            Destroy(gameObject);


        }
       


    }

   

}

