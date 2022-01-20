using System;
using System.Collections;
using System.Collections.Generic;
using Script.Model;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour {
    // Start is called before the first frame update
    private AudioSource _audioSource;
    // 跳跃
    public AudioClip[] jump;

    // 失败
    public AudioClip[] move;
    
    // 交互
    public AudioClip[] down;
    
    // Buff
    public AudioClip[] buff;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSE() {
        _audioSource.clip = jump[0];
        _audioSource.Play();
    }

    public void PlayMoveSE() {
        _audioSource.clip = move[0];
        _audioSource.Play();
    }

    public void PlayDownSE() {
        _audioSource.clip = down[0];
        _audioSource.Play();
    }
    
    /*private AudioSource _audioSource;
    private Service _service;
    
    void Start() {
        _audioSource = GetComponent<AudioSource>();
        _service = GameObject.Find("Service").GetComponent<Service>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        // 0.8-1.3 差0.5
        _audioSource.pitch = _service.forwardService.GetRunningSpeed()/10 * 0.5f + 0.3f;
    }*/
}
