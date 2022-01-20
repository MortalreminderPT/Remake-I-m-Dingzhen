using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIcon(Sprite icon) {
        this.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = icon;
    }
    
    public void SetDetails(String details) {
        this.transform.GetChild(1).GetComponent<Text>().text = details;
    }

    public void SetName(String name) {
        this.transform.GetChild(0).GetComponentInChildren<Text>().text = name;
    }

    public void SetClickId(String id) {
        GetComponent<ButtonClickHandler>().SetClickId(id);
    }

    public void SetPrice(int price) {
        this.transform.GetChild(2).GetComponent<Text>().text = "价格: "+price.ToString();
    }
}
