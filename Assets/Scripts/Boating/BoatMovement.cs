using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BoatMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private float _boatSpeed;
    private bool _inBoost;
    public static event Action OnBoatSpeedBoost;
    public static event Action OnBoatExit;

    IEnumerator SpeedBoost(){
        _inBoost = true;
        float originalSpeed = _boatSpeed;
        _boatSpeed = _boatSpeed + 10.0f;
        _animator.SetBool("BoatInMotion", true);
        OnBoatSpeedBoost?.Invoke();
        yield return new WaitForSeconds(3.0f);
        _boatSpeed = originalSpeed;
        _animator.SetBool("BoatInMotion", false);
        _inBoost = false;
    }

    void Start(){
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _boatSpeed = 15.0f;
    }
    void Update(){
        if(Input.GetKey(KeyCode.A)){
            _rb.velocity = Vector2.left * _boatSpeed * Time.fixedDeltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            _rb.velocity = Vector2.right * _boatSpeed * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.W)){
            _rb.velocity = Vector2.up * _boatSpeed * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            _rb.velocity = Vector2.down * _boatSpeed * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.Q)){
            _rb.velocity = Vector2.zero;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            if(!_inBoost){
            StartCoroutine("SpeedBoost");
            } else { return; }
        }

        if(Input.GetKeyDown(KeyCode.E)){
            _rb.velocity = Vector2.zero;
            OnBoatExit?.Invoke();
        }

        if(_rb.velocity.x > 0){
            _spriteRenderer.flipX = true;
        }
        if(_rb.velocity.x < 0){
            _spriteRenderer.flipX = false;
        }
    }
}
