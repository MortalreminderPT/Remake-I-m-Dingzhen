using System.Collections.Generic;
using UnityEngine;

namespace Script.Model.MapService {
    public class ItemLoadService : MonoBehaviour {
        // private int _myLocation = 0;
        private Stack<int> _next;
        private Service _service;
        
        // Start is called before the first frame update
        void Start() {
            _next = new Stack<int>();
            _service = GetComponent<Service>();
        }
        
        private Stack<int> toM(int x, int m) {
            Stack<int> res = new Stack<int>();
            while (x != 0) {
                res.Push(x % m);
                x /= m;
            }
            return res;
        }

        public void LoadItemsforMap(GameObject map) {
            if (_next.Count == 0) _next = toM(_service.seed, _service.items.Length + _service.paidItems.Length);
            int next_i = _next.Pop();
            if (next_i < _service.paidItems.Length && PlayerPrefs.GetInt("shops"+next_i, 0)==1)
                LoadPaidItem(map, next_i);
            else 
                LoadSpecialItem(map, next_i%_service.items.Length);
            LoadItems(map);
        }

        public void LoadPaidItem(GameObject map, int i) {
            GameObject item = GameObject.Instantiate(GetComponent<Service>().paidItems[i], map.transform.GetChild(0).GetChild(0), true);
            item.transform.localRotation = new Quaternion(0, 0, 0, 0);
            item.transform.localPosition = new Vector3(0, 0.7f, 0);
            item.transform.localScale = new Vector3(3, 3, 3);
        }

        public void LoadSpecialItem(GameObject map, int i) {
            try {
                GameObject item = GameObject.Instantiate(GetComponent<Service>().items[i], map.transform.GetChild(0).GetChild(0), true);
                item.transform.localRotation = new Quaternion(0, 0, 0, 0);
                item.transform.localPosition = new Vector3(0, 0.7f, 0);
                item.transform.localScale = new Vector3(3,3,3);
            }
            catch {
                Debug.Log("出错位置"+i);
            }
        }

        public void LoadItems(GameObject map) {
            for (int i = 1; i < map.transform.childCount; i++) {
                if (map.transform.GetChild(i).childCount == 0) continue;
                GameObject item = GameObject.Instantiate(GetComponent<Service>().items[0], map.transform.GetChild(i).GetChild(0), true);
                item.transform.localRotation = new Quaternion(0, 0, 0, 0);
                item.transform.localPosition = new Vector3(0, 0.7f, 0);
                item.transform.localScale = new Vector3(3,3,3);
            }
        }
        
        // Update is called once per frame
        void FixedUpdate() {
            // 加载新地图后加载其子物品
            
        }
    }
}
