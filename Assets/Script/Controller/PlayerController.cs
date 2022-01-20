using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Script.Components;
using Script.Components.Reverse;
using Script.Model;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Controller {
    public class PlayerController : MonoBehaviour {
        public Service service;

        // Update is called once per frame

        private void OnCollisionEnter(Collision other) {
            if (other.collider.CompareTag(tag: "Trap")) {
                service.playerCollisionService.TrapCollision(_findTrapParent(other.gameObject));
                GetComponentInChildren<PlayerAnimController>().PlayJumpDown();
                service.playerStateService.GameOver();
            }
            if (other.collider.CompareTag(tag: "Reverse")) {
                service.reverseMapService.ReverseCommand(_findTrapParent(other.gameObject).GetComponent<ReverseBlock>().reverseAngle);
                GetComponentInChildren<PlayerAnimController>().PlayJump();
            }
            else {
                //if (other.contacts[0].normal.z != 0) {
                //    Debug.Log(other.contacts[0].normal.z==1||other.contacts[0].normal.z==-1);
                //    GetComponentInChildren<PlayerAnimController>().PlayJumpDown();
                //}
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag(tag: "Trap"))
                service.playerCollisionService.TrapCollision(_findReverseParent(other.gameObject));
            if (other.CompareTag(tag: "Reverse"))
                service.reverseMapService.ReverseCommand(_findTrapParent(other.gameObject).GetComponent<ReverseBlock>().reverseAngle);

        }

        private GameObject _findTrapParent(GameObject trap) {
            while (trap.GetComponent<BaseBlock>() == null)
                trap = trap.transform.parent.gameObject;
            return trap;
        }

        private GameObject _findReverseParent(GameObject reverse) {
            while (reverse.GetComponent<BaseBlock>() == null)
                reverse = reverse.transform.parent.gameObject;
            return reverse;
        }
    }
}