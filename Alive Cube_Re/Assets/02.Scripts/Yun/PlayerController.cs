﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance = null;

    private AudioSource _audio;
    public AudioClip intro_audio;
    public AudioClip mapMaking_audio;
    public AudioClip mapMakingEnd_audio;
    public AudioClip countDown_audio;
    public AudioClip gameOver_audio;


    public static int coint = 0;

    public bool playerDie = false;

    private void OnEnable()
    {
        IntroAnimation.IntroAudio += MapMaking_Audio;
    }
    private void OnDisable()
    {
        IntroAnimation.IntroAudio -= MapMaking_Audio;
    }

    void Start()
    {
        instance = this;

        _audio = GetComponent<AudioSource>();
        _audio.clip = intro_audio;
        _audio.Play();

        Debug.Log(AttackController.playerHp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CUBE"))
        {
            
            Debug.Log("맞았다!!!");
            AttackController.playerHp--;
            Debug.Log("PlayerHP : " + AttackController.playerHp);
            
        }
    }
    

    void Update()
    {
        if(!playerDie && AttackController.playerHp <= 0)
        {            
            Debug.Log("Game Over");
            _audio.PlayOneShot(gameOver_audio);
            playerDie = true;
        }
    }

    public void MapMaking_Audio()
    {
        _audio.Stop();
        _audio.PlayOneShot(mapMaking_audio);

    }
    public void _IntroAudio()
    {
        _audio.PlayOneShot(mapMakingEnd_audio);
    }

    public void CountDown_Audio()
    {
        _audio.PlayOneShot(countDown_audio);

    }
}