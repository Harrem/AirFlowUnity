using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 mouseDownPos;


    void Update()
    {
        // transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        // Debug.Log("Transfrom: " + (transform.up * moveSpeed * Time.deltaTime));
        Vector2 touchPos = Vector2.zero;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
            mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
                if (Input.touchCount > 0)
                    touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
#endif

        if (touchPos != Vector2.zero)
            transform.position = Vector2.MoveTowards(transform.position, touchPos, moveSpeed * Time.deltaTime);
    }
}
