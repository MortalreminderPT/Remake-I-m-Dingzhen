using System;
using System.Collections.Generic;
using Script.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Model {
    public class MapLoadService : MonoBehaviour
    {
        // Start is called before the first frame update
        //private int seed = 978432668;
        private Stack<int> _next;
        private Service _service;
        private int idForZhanshi = 1;
        
        void Start() {
            _next = new Stack<int>();
            _service = GetComponent<Service>();
        }

        // 把seed转换成m进制格式
        private Stack<int> toM(int x, int m) {
            Stack<int> res = new Stack<int>();
            while (x != 0) {
                res.Push(x % m);
                x /= m;
            }
            return res;
        }
        
        // Update is called once per frame
        void FixedUpdate() {
            NewObserver(_service.player.transform.position.z);
        }

        // 观察并加载
        private void NewObserver(float z) {
            int zNew = ((int)z / 80 + 1) * 80 + 5;
            bool mapped = Physics.BoxCast(new Vector3(0, 0, zNew), new Vector3(20, 20, 1), Vector3.forward);
            if (!mapped) {
                if (_next.Count == 0) {
                    int m = z > 2000 ? _service.loadMaps.Length : (z>1000) ? 7 : 3;
                    _next = toM(_service.seed, m/*_service.loadMaps.Length*/);
                    _service.seed = RandomX.getNextSeed(_service.seed);
                    print(_service.seed);
                }
                // 专门为展示的
                LoadMap(zNew, (idForZhanshi++)%_service.loadMaps.Length);
                // 实际情况
                /*LoadMap(zNew, _next.Pop());*/
            }
        }

        private void LoadMap(int z, int i) {
            GameObject mapNew = GameObject.Instantiate(_service.loadMaps[i], new Vector3(0, 0, z), new Quaternion(0, 0, 0, 0));
            mapNew.transform.parent = _service.gameMap.transform;
            mapNew.transform.localRotation = new Quaternion(0, 0, 0, 0);
            _service.itemLoadService.LoadItemsforMap(mapNew);
        }
    }
}