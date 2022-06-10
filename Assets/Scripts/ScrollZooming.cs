using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollZooming : MonoBehaviour
{
    //variables
    [SerializeField] private float maxZoom;
    [SerializeField] private float minZoom;
    [SerializeField] private float currentZoom;
    [SerializeField] private float zoomScale;

    void Start(){
        currentZoom = Camera.main.orthographicSize;
    }
    void Update(){
        HandleZooming();
    }

    void HandleZooming(){
        if(Input.mouseScrollDelta.y > 0){
            Camera.main.orthographicSize -= currentZoom * zoomScale;
            if(currentZoom < minZoom) {
            currentZoom = minZoom;
            return;
            }
        }
        if(Input.mouseScrollDelta.y < 0){
            Camera.main.orthographicSize += currentZoom * zoomScale;
            if(currentZoom > maxZoom) {
            currentZoom = maxZoom;
            return;
            }
        }
    }
}
