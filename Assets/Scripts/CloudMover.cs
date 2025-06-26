using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (Camera.main.WorldToViewportPoint(transform.position).y < -0.1f)
        {
            Destroy(gameObject);
        }
    }
}
