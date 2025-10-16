using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 5.0f;
    private bool isPlaying = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false; //deactivate at first
    }

    public void StartPlay()
    {
        isPlaying = true;
        rb.simulated = true;
    }

    void Update()
    {
        if (!isPlaying) return;

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isPlaying) return;
        GameManager.instance.GameOver();
    }
}
