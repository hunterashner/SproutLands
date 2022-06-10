using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FenceHorizontal : MonoBehaviour
{
    bool _open;
    public SpriteRenderer _sr;
    public BoxCollider2D _closedGateCollider;
    public Sprite _openSprite;
    public Sprite _closeSprite;

    public static event Action OnFenceOpen;
    public static event Action OnFenceClose;

    void Start(){
        _open = false;
    }

    void OnTriggerEnter2D(Collider2D collider){
        _sr.sprite = _openSprite;
        _closedGateCollider.enabled = false;
    }

    void OnTriggerExit2D(Collider2D collider){
        _sr.sprite = _closeSprite;
        _closedGateCollider.enabled = true;
    }
}
