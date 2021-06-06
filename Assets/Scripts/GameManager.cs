using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;

    private float platformCount = 500;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(5f, 2f);
            spawnPosition.x = Random.Range(-5f, 5f);
            Instantiate(platformPrefab, spawnPosition, quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Destroyer") == true)
        {
            
        }
    }
}
