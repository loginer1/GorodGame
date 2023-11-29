using UnityEngine;

public class HeroCamera : MonoBehaviour
{
    private Transform _heroPosition;
    private float _speedCamera = 5;

    public void Init(Transform heroPosition)
    {
        _heroPosition = heroPosition;
    }

    private void Update()
    {
        Vector3 nextPosition = new Vector3(_heroPosition.position.x, _heroPosition.position.y + 1.8f, -5);

        transform.position = Vector3.Lerp(transform.position, nextPosition, _speedCamera * Time.deltaTime);
    }
}
