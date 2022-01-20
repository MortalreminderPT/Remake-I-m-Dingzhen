using UnityEngine;

namespace Script.Model.MapService {
    public class MapReleaseService : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void FixedUpdate() {
            if (GetComponent<Service>().gameMap.transform.GetChild(0).childCount == 0) {
                Destroy(GetComponent<Service>().gameMap.transform.GetChild(0).gameObject);
                return;
            }
            var tmp = GetComponent<Service>().gameMap.transform.GetChild(0).GetChild(0); 
            if (tmp.transform.position.z + 10 < GetComponent<Service>().player.transform.position.z) { 
                Destroy(GetComponent<Service>().gameMap.transform.GetChild(0).GetChild(0).gameObject);
            }
        }
    }
}
