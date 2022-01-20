using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetDetails(String details) {
        this.transform.GetComponentInChildren<Text>().text = details;
    }
}
