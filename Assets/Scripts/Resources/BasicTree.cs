using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTree : MonoBehaviour, IGatherable
{
    public SpriteRenderer _spriteRenderer;
    public Color _onHoverColor = new Color(1, 1, 1, 0.1f);
    public Color _originalColor = new Color(1, 1, 1, 1);
    public Animator _anim;
    public ParticleSystem _ps;
    public float _health;
    public GameObject _sticks;
    public GameObject _logs;
    public Transform _resourceSpawn;

    void start(){
        Physics.queriesHitTriggers = false;
    }
    public void TakeDamage(float damageReceived){
        _health =  _health - damageReceived;
        Debug.Log($"Tree Health: {_health}");
        _ps.Play();
        if(_health <= 0){
            DropResources();
        }
    }   

    public void DropResources(){
        Debug.Log("dropping resources...");
        int randomStickAmount = Random.Range(1,3);
        int randomLogAmount = Random.Range(2,4);
        GameObject stick = Instantiate(_sticks, _resourceSpawn.position, Quaternion.identity);
        GameObject log = Instantiate(_logs, _resourceSpawn.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ToggleHighlightColor(bool toggle){
        if(toggle){
            _spriteRenderer.color = _onHoverColor;
        } else {
            _spriteRenderer.color = _originalColor;
        }
    }

    public void OnMouseEnter(){
        _spriteRenderer.color = _onHoverColor;
    }

    public void OnMouseExit(){
        _spriteRenderer.color = _originalColor;
    }
}
