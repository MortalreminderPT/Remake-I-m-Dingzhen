using System;
using System.Collections;
using System.Collections.Generic;
using Script.Controller;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour {
    public GameObject eventSystem;
    private Button _button;
    public String id;
    
    // Start is called before the first frame update
    void Start() {
        eventSystem = GameObject.Find("EventSystem");
        _button = this.GetComponent<Button>();
        _button.onClick.AddListener (OnClick);
    }

    public void SetClickId(String id) {
        this.id = id;
    }
    private void OnClick() {
        eventSystem.GetComponent<GameStartController>().OnClick(id);
        //Debug.Log ("Button Clicked. ClickHandler.");
    }
}