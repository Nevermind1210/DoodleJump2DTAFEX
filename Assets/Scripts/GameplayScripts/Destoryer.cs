using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Destoryer : MonoBehaviour
{
    // This whole script will use tags and if the player hits it destroy it! 
    public GameObject player;
    public GameObject gameOver;
    public GameObject platformPrefab;
    
    private void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (collision2D.gameObject.name.StartsWith("Platform"))
        {
            Destroy(collision2D.gameObject);
            Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
        }
        else if (collision2D.gameObject.name.StartsWith("Player"))
        {
            gameOver.SetActive(true);

        }
    }
}
