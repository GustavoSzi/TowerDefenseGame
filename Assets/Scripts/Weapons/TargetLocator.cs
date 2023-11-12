using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField]
    private Transform weapon;

    private EnemyMovement target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        if(target != null) { 
            weapon.transform.LookAt(target.transform.position);
        }
    }
}
