using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public static PlayerManager instance;
    

    public int healthPoints;

    [SerializeField]
    private int maxHealthPoints = 5;

    [HideInInspector]
    public bool isDead = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        healthPoints = maxHealthPoints;
    }

    public void AddHealthPoints(int amount) 
    {
        healthPoints += amount;
    }

    public void SubtractHealthPoints(int amount)
    {
        healthPoints -= amount;
        if(healthPoints <= 0)
        {
            isDead = true;
            Debug.Log("Dead!");
        }
    }
}
