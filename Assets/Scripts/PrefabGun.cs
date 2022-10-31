using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PrefabGun : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _reloadTime;
    [SerializeField] private bool _randomSpeed;
    [SerializeField] private bool _randomDirection;
    
    private IMovable _prefabMovable;
    private float _currentReloadTime;
    private readonly List<PrefabBullet> _instances = new List<PrefabBullet>();
    private float _currSpeed;
    private Vector3 _currDirection;
    private void Start()
    {
        _prefabMovable = _prefab.GetComponent<IMovable>();
        _currSpeed = _speed;
        _currDirection = _direction;
    }

    private void Update()
    {
        if (_prefabMovable != null && _speed != 0f)
        {
            if (_currentReloadTime > _reloadTime)
            {
                _currentReloadTime = 0f;
                
                _currSpeed = _randomSpeed ? Random.Range(0f, _speed) : _speed;
                _currDirection = _randomDirection ? new Vector3(
                    Random.Range(-1f, 1f), 
                    Random.Range(-1f, 1f), 
                    Random.Range(-1f, 1f)) : _direction;

                _instances.Add(new PrefabBullet(
                    Instantiate(_prefab, transform.position, Quaternion.identity, null)
                        .GetComponent<IMovable>(), _distance, _currDirection.normalized * _currSpeed));
            }
            else
                _currentReloadTime += Time.deltaTime;
            

            for (int i = 0; i < _instances.Count; i++)
            {
                if (_instances[i].Move())
                    _instances.RemoveAt(i);
            }
        }

    }

    private void ClearBullet()
    {
        for (int i = 0; i < _instances.Count; i++)
        {
            _instances[i].Destroy();
            _instances.RemoveAt(i);
        }
    }
    public void SetSlider(TypeValue type, Slider slider)
    {
        switch (type)
        {
            case TypeValue.Speed : _speed = slider.value; break;
            case TypeValue.DirectionX : _direction.x = slider.value; break;
            case TypeValue.DirectionY : _direction.y = slider.value; break;
            case TypeValue.DirectionZ : _direction.z = slider.value; break;
            case TypeValue.Distance : _distance = slider.value; break;
            case TypeValue.ReloadTime : _reloadTime = slider.value; break;
        }

        ClearBullet();
    }
    public void SetToggle(TypeValue type, Toggle toggle)
    {
        switch (type)
        {
            case TypeValue.RandomSpeed : _randomSpeed = toggle.isOn; break;
            case TypeValue.RandomDirection : _randomDirection = toggle.isOn; break;
        }
        ClearBullet();
    }
    public void SetInputField(TypeValue type, TMP_InputField inputField)
    {
        switch (type)
        {
            case TypeValue.Speed : _speed = float.Parse(inputField.text); break;
            case TypeValue.DirectionX : _direction.x = float.Parse(inputField.text); break;
            case TypeValue.DirectionY : _direction.y = float.Parse(inputField.text); break;
            case TypeValue.DirectionZ : _direction.z = float.Parse(inputField.text); break;
            case TypeValue.Distance : _distance = float.Parse(inputField.text); break;
            case TypeValue.ReloadTime : _reloadTime = float.Parse(inputField.text); break;
        }

        ClearBullet();
    }

   
}