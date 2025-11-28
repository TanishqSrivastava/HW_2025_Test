using UnityEngine;

public class DoofusController : MonoBehaviour
{
    private float speed;
    public Rigidbody rb;

    void Start()
    {
        // Read speed from JSON config
        speed = ConfigManager.Instance.Config.player_data.speed;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(move);

        // Simple Fall Check
        if (transform.position.y < -5f)
        {
            GameManager.Instance.GameOver();
        }
    }
}