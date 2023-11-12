using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
    [SerializeField]
    public GameObject selectedTower = null;

    public static TowersManager instance { get; private set; }

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
    }
}
