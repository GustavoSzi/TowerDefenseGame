using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHealthPoints = 5;
    
    int currentHealthPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHealthPoints--;

        if (currentHealthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
