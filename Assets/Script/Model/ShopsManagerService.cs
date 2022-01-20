using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopsManagerService : MonoBehaviour {
    private ShopsInformation _shopsInformation;
    public Sprite[] ShopSprites;
    public AudioClip ShopBgm;
    public GameObject ShopBoardList;
    private int coins = 0; //= PlayerPrefs.GetInt("Coins", 0);
    
    
    // Start is called before the first frame update
    void Start()
    {
        _shopsInformation = ShopsInformation.getInstance();
    }

    public void newShopListScript(GameObject content, String name, String details) {
        for (int i = 0; i < 3; i++) {
            var scoreList = Instantiate(ShopBoardList, content.transform);
            scoreList.transform.localPosition = new Vector3(0, -400 * i, 0);
            scoreList.GetComponent<ShopListScript>().SetName(_shopsInformation.names[i]);
            scoreList.GetComponent<ShopListScript>().SetIcon(ShopSprites[i]);
            scoreList.GetComponent<ShopListScript>().SetDetails(_shopsInformation.details[i]);
            scoreList.GetComponent<ShopListScript>().SetPrice(_shopsInformation.prices[i]);
            scoreList.GetComponent<ShopListScript>().SetClickId("shops"+i);
            scoreList.GetComponent<Button>().interactable = (PlayerPrefs.GetInt("shops"+i, 0)==0);
        }
    }

    public bool Buy(int id) {
        // 购买道具成功
        if (PlayerPrefs.GetInt("Coins", 0) < _shopsInformation.prices[id]) {
            Debug.Log("硬币不足，购买失败");
            return false;
        }
        //coins -= _shopsVo.prices[id];
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) - _shopsInformation.prices[id]);
        PlayerPrefs.SetInt("shops"+id, 1);
        return true;
    }
}
