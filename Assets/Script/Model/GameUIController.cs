using System;
using System.Collections;
using System.Collections.Generic;
using Resource.Prefab.UI;
using Script.Model;
using Script.State;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManageService _gameManageService;
    private Service _service;
    public GameObject MenuUI;
    public GameObject StateList;
    
    public int _stateLocationY = 0;

    //[FormerlySerializedAs("_stateList")]
    public List<GameObject> states;
    
    void Start() {
        _service = GameObject.Find("Service").GetComponent<Service>();
        _gameManageService = GameManageService.getInstance();
        _stateLocationY = 0;
        //_stateList = new List<GameObject>(); //Dictionary<int, GameObject>();
    }

    //private void OnEnable() {
        
    //}

    // Update is called once per frame
    void Update() {
        
    }

    public void Pause() {
        PlayerPrefs.DeleteAll();
        _gameManageService.PauseGame();
    }
    
    public void Remake() {
        _gameManageService.RemakeGame();
    }

    public void Exit() {
        _gameManageService.ExitGame();
    }

    public int AddStateUI(Sprite sprite) {
        return 0;
    }
    public int _AddStateUI(Sprite sprite) {
        GameObject tmp = Instantiate(StateList, GameObject.Find("State").transform);
        tmp.GetComponent<StateListScript>().SetIcon(sprite);
        states.Add(tmp);
        tmp.transform.localPosition = new Vector3(0,200*states.IndexOf(tmp),0);
        return states.IndexOf(tmp);
    }
    
    
    
    State[] _states;
    
    public void listAllStates() {
        _states = _service.player.GetComponents<State>();
        for(int i = 0; i < _states.Length; i++) {
            
            GameObject tmp = Instantiate(StateList, GameObject.Find("State").transform);
            tmp.GetComponent<StateListScript>().SetIcon(_states[i].icon);
            tmp.GetComponent<StateListScript>().SetTimes(_states[i].time, _states[i].duration);
            tmp.transform.localPosition = new Vector3(0,200*i,0);
            states.Add(tmp);
        }
    }

    public void UpdateTimes() {
        for(int i = 0; i < states.Count; i++) {
            //_states = _service.player.GetComponents<State>();
            states[i].GetComponent<StateListScript>().SetTimes(_states[i].time, _states[i].duration);
        }
    }

    public void UpdateSprite(int id, int s, int t) {
        var stateUI = GameObject.Find("State");
        // 删除list的所有子状态
        for (int i = 0; i < stateUI.transform.childCount; i++) { 
            Destroy(stateUI.transform.GetChild(i).gameObject);
        } 
        // 重新展示
        listAllStates();
    }
    public void _UpdateSprite(int id, int s, int t) {
        if (s == 0) {
            GameObject tmp = states[id];
            states.RemoveAt(id);
            Destroy(tmp);
            return;
        }
        states[id].GetComponent<StateListScript>().SetTimes(s, t);
    }
}
