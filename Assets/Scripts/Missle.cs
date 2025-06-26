using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 4f;
    private Transform target;

    void Start()
    {
        // Spawn the missile at a random X position at the top of the screen
        float randomX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
        transform.position = new Vector2(randomX, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);
    }

    void Update()
    {
        // Move the missile downwards
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    async private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            AudioManager.Instance.PlayExplosion();
            await System.Threading.Tasks.Task.Delay(1000);
            Debug.Log("HIT object");
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }
}
