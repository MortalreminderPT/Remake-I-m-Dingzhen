using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopsInformation {
    
    private static ShopsInformation _shops;

    public static ShopsInformation getInstance() {
        if (_shops == null) {
            _shops = new ShopsInformation();
        }
        return _shops;
    }
    
    // Start is called before the first frame update
    public String[] names = {"电子烟", "丁真的义眼", "小马珍珠"};
    public String[] details = {"电子烟假，尼古丁真:\n丁真大口吸烟并将面前小心心暴风吸入，持续10秒", "义眼丁假:\n丁真使用义眼将前方障碍物鉴定为假，持续10秒", "找回失踪的小马珍珠:\n短暂提供爆发性加速并永久获得二段跳"};
    public int[] prices = {499, 4999, 49999};
}
