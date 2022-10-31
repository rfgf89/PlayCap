using UnityEngine;

public class MoveFadeOut : MonoBehaviour, IMovable
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private float _alpha = 1f;
    public void Move(ref float distance, float maxDistance, Vector3 velocity)
    {
        transform.position += velocity * Time.deltaTime;
        distance -= velocity.magnitude * Time.deltaTime;
        _alpha = distance / maxDistance;
        
        var tempCol = _meshRenderer.material.color;
        tempCol.a = _alpha;
        _meshRenderer.material.color = tempCol;

        if (distance <= 0f)
            Destroy(gameObject);
    }

    public void Destroy() => Destroy(gameObject);
    
}