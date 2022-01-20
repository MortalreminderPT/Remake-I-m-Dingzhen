using UnityEngine;
using UnityEngine.UI;

namespace Resource.Prefab.UI {
    public class StateListScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public void SetIcon(Sprite icon) {
            transform.GetChild(3).GetComponent<Image>().sprite = icon;
        }

        public void SetTimes(int s, int t) {
            Debug.Log(s+" "+t);
            GetComponentInChildren<Slider>().value = ((float)s / t);
        }
        
    }
}
