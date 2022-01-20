using System;
using Script.Model;
using UnityEngine;
using UnityEngine.Serialization;

public enum StateType {
    SpeedUp,
    Magnet,
    Smash, 
    Quantum,
    DoubleJump
}

namespace Script.State {
    public abstract class State : MonoBehaviour{
        public int frequency;
        public int duration;
        
        public StateType mType;
        
        public StateType[] excludes;
        
        protected Service service;
        public Sprite icon ;
        private int id;
        protected GameUIController _gameUIController;
        [FormerlySerializedAs("_time")]
        public int time;
        
        // Start is called before the first frame update
        public virtual void Start() {
            time = duration;
            _gameUIController = GameObject.Find("EventSystem").GetComponent<GameUIController>();
            service = GameObject.Find("Service").GetComponent<Service>();
            ExcludeStates();
            //id = _gameUIController.AddStateUI(icon);
            //print(icon.name);
        }

        void ExcludeStates() {
            if(excludes==null) return; 
            foreach (var exclude in excludes) {
                try {
                    var com = service.player.GetComponent<State>() as State;
                    if (com.mType == exclude && com != this) {
                        //com.StateExitHook();
                        com.ForceExit();
                        //Destroy(com);
                    }
                }
                catch(Exception e){
                    Debug.Log("..........."+e.Message);
                }
            }
        }

        void ForceExit() {
            time = 0;
        }

        // Update is called once per frame
        void FixedUpdate() {
            //_gameUIController.UpdateSprite(id, _time, duration);
            if (duration > 0) {
                // 生成UI
                if (time == duration) {
                    StateEnterHook();
                    try {
                        _gameUIController.UpdateSprite(id, 0, duration);
                    }
                    catch { }
                    //print(icon.name);
                }
                // 刷新UI
                try {
                    _gameUIController.UpdateSprite(id, time, duration);
                }
                catch { }
                
                if (time == 0) {
                    StateExitHook();
                    try {
                        _gameUIController.UpdateSprite(id, 0, duration);
                    }
                    catch {
                        Debug.Log(" ");
                    }
                    Destroy(this);
                    return;
                }
                if (time > 0) time--;
                if (frequency == 0) return;
                if (time%frequency==0) UpdateHook();
            }
        }
        public virtual void StateEnterHook() { }
        
        public virtual void StateExitHook() { }

        public virtual void UpdateHook() { }
    }
}
