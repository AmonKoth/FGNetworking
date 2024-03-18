using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{

    [SerializeField]
    private Health _playerHealth;

    [SerializeField]
    private SpriteRenderer _shield;

    void Start()
    {
        _shield.enabled = false;
        _playerHealth.currentShield.OnValueChanged += UpdateShield;
    }


    private void UpdateShield(int previousValue, int currentValue)
    {
        if (currentValue > 0)
        {
            _shield.enabled = true;
        }
        else
        {
            _shield.enabled = false;
        }
    }

    private void OnDestroy()
    {
        _playerHealth.currentShield.OnValueChanged -= UpdateShield;
    }
}
