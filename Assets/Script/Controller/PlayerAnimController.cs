using System.Collections;
using System.Collections.Generic;
using Script.Model;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {
    private Service _service;
    private Animator _animator;
    // Start is called before the first frame update
    void Start() {
        _service = GameObject.Find("Service").GetComponent<Service>();
        _animator = GetComponent<Animator>();
    }

    public void PlayRunning() {
        _animator.SetBool("Jump", false);
        _animator.SetBool("JumpDown", false);
    }

    public void PlayJump() {
        _animator.SetBool("Jump", true);
        //_animator.SetBool("Jump", false);
    }

    public void PlayJumpDown() {
        _animator.SetBool("JumpDown", true);
    }
    
    // Update is called once per frame
    void Update() { }
}
