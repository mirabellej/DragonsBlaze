﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{

    private void Awake()
    {

        // if more than one music player in scene
        // destroy ourselves
        // els

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
  

}
