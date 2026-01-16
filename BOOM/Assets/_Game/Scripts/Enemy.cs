using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField]private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; //the health you start with is the max HP



    }


    public void TakeDamage(int damageAmount) //handles enemy taking damage
    {
        currentHealth -= damageAmount;

        Debug.Log(name + " took " + damageAmount + " damage! HP Left: " + currentHealth);

        if (currentHealth<=0) 
        {
            Die();
        }
    
    }
    public void Die()
    {

        Debug.Log(name + "is dead!");

        //destroy enemy object
        Destroy(gameObject);
        
    }
}
