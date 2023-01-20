using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private GameObject enemies;
    
    private void Start()
    {
	    currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
	{
        currentHealth -= damage;
		if (currentHealth <= 0)
		{
            Destroy(enemies);
		}
	}
    
}
