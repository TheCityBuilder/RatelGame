using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject Enemies;
    void Start()
    {
        GameObject Enemies = GetComponent<GameObject>();
        currentHealth = maxHealth;
        
    }
    public void TakeDamage(int damage)
	{
        currentHealth -= damage;
		if (currentHealth <= 0)
		{
            Destroy(Enemies);
		}


	}
    
}
