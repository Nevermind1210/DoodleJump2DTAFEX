using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject score;
    public GameObject player;
    public GameObject platformPrefab;
    private GameObject myPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);
            GeneratePlatform();
        }
        else if (collision.gameObject.tag == "Player")
        {
            gameOver.SetActive(true);
            score.SetActive(false);
        }
    }
    
    private void GeneratePlatform()
    {
        myPlat = Instantiate(platformPrefab,
            new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f,  1f))), 
            Quaternion.identity); // we clone the platform by these ranges and by 14 each time so you can't see it spawning makes it more natural.
    }
}