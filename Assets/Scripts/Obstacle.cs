using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float PosY { get; set; }
    public GameObject Prefab { get; set; }

    public Obstacle(float posY = 1.2f, GameObject prefab = null)
    {
        this.PosY = posY;
        this.Prefab = prefab;
    }
}