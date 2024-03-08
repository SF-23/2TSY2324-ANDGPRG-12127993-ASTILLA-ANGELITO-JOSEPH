using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Material towerMat;
    [SerializeField] public float buildTimer;

    public void Buildable()
    {
        towerMat.color = Color.green;
    }
    public void NonBuildable()
    {
        towerMat.color = Color.red;
    }

    public void Build()
    {
        // animation 
        towerMat.color = Color.white;
    }

    public void Building()
    {
        towerMat.color = Color.yellow;
    }
}
