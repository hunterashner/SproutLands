using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tooltip
{
    public TooltipData tooltipData;
    public Tooltip(TooltipData data){
        tooltipData = data;
    }
}
