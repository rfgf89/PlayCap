using UnityEngine;

public interface IMovable
{
    public void Move(ref float distance, float maxDistance, Vector3 velocity);
    public void Destroy();
}
