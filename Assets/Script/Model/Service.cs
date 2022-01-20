using System;
using Script.Model.MapService;
using Script.Model.PlayerService;
using Script.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.Model {
    public class Service : MonoBehaviour {
        public GameObject player;
        public GameObject MenuUI;
        public bool autoForward = false;
        public GameObject mainCamera;
        public GameObject skyBoxCamera;
        public GameObject gameMap;
        public int reverseMultiple = 1;
        public int seed = 978432668;
        public int jumpTimes = 1;
        public GameObject[] loadMaps;
        public GameObject[] items;
        
        public GameObject[] paidItems;

        public GameObject canvas;
        
        // Start is called before the first frame update
        
        // 控制玩家前行的速度的服务
        public ForwardService forwardService;
        // 判断玩家是否在地图内的服务
        public PlayerStateService playerStateService;
        // 判断玩家是否踩到陷阱的服务
        public PlayerCollisionService playerCollisionService;
        // 翻转地图的服务
        public ReverseMapService reverseMapService;
        // 控制玩家和地面交互的服务
        public PlayerSlideService playerSlideService;
        // 动态加载地图的服务
        public MapLoadService mapLoadService;

        public ItemLoadService itemLoadService;
        // 动态卸载地图的服务
        public MapReleaseService mapReleaseService;

        //public int refreshRate = Screen.currentResolution.refreshRate;
        
        //public GameObject 
        
        void Start() {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            // jumpTimes = (PlayerPrefs.GetInt("shops2", 0) == 1) ? 2 : 1;
            // seed = RandomX.getNextSeed((int)DateTime.Now.Ticks/10); ;
            forwardService = gameObject.AddComponent<ForwardService>();
            playerCollisionService = gameObject.AddComponent<PlayerCollisionService>();
            reverseMapService = gameObject.AddComponent<ReverseMapService>();
            playerStateService = gameObject.AddComponent<PlayerStateService>();
            playerSlideService = gameObject.AddComponent<PlayerSlideService>();
            
            //gameManageService = gameObject.AddComponent<GameManageService>();
            mapLoadService = gameObject.AddComponent<MapLoadService>();
            itemLoadService = gameObject.AddComponent<ItemLoadService>();
            mapReleaseService = gameObject.AddComponent<MapReleaseService>();
        }
    }
}
