using UnityEngine;

public class PrefabBullet
{
    private readonly IMovable _instance;
    private float _distance;
    private readonly float _maxDistance;
    private readonly Vector3 _velocity;
    
    public PrefabBullet(IMovable instance, float distance, Vector3 velocity)
    {
        _instance = instance;
        _distance = distance;
        _maxDistance = distance;
        _velocity = velocity;
    }

    public bool Move()
    {
        _instance.Move(ref _distance, _maxDistance, _velocity);
        
        if (_distance <= 0f)
            return true;
        
        return false;
    }

    public void Destroy() => _instance.Destroy();
    
}