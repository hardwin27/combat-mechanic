using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    
public class CharacterUIController : MonoBehaviour
{
    private Canvas _canvas;

    [SerializeField] private CharacterEntity _characterEntity;
    [SerializeField] private Slider _healthBar;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeToEvents();
    }

    private void InitUICam()
    {
        
    }

    private void InitHealthBarData()
    {

    }

    private void UpdateHealthbar()
    {

    }

    private void SubscribeToEvents()
    {
        _characterEntity.HealthUpdated += UpdateHealthbar;
    }

    private void UnsubscribeToEvents()
    {
        _characterEntity.HealthUpdated -= UpdateHealthbar;
    }

    
}
