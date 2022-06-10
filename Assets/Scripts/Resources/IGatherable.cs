using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGatherable{
    public void TakeDamage(float damageReceived);
    public void DropResources();

    public void ToggleHighlightColor(bool toggle);
}
