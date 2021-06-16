using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
   private static MusicManager _instance;

   public static MusicManager instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = GameObject.FindObjectOfType<MusicManager>();
            
            DontDestroyOnLoad(_instance.gameObject);
         }
         return _instance;
      }
   }

   private void Awake()
   {
      if (_instance == null)
      {
         Debug.Log("null");
         _instance = this;
         DontDestroyOnLoad(this);
      }
      else
      {
         if (this != _instance)
         {
            Play();
            Debug.Log("ThisIsNotNull");
            Destroy(this.gameObject);
         }
      }
   }

   private void Update()
   {
      if (this != _instance)
      {
         _instance = null;
      }
   }

   private void Play()
   {
      GetComponent<AudioListener>();
   }
}
