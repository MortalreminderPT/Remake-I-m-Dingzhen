using System.Collections;
using System.Collections.Generic;
using Script.Model;
using UnityEngine;

public class GameAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audioSource;
    private Service _service;
    
    void Start() {
        _audioSource = GetComponent<AudioSource>();
        _service = GameObject.Find("Service").GetComponent<Service>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        // 0.8-1.3 差0.5
        _audioSource.pitch = _service.forwardService.GetOriginalRunningSpeed()/10 * 0.5f + 0.3f;
    }
}
