using UnityEngine;

public class Player : MonoBehaviour
{

    private float movement;

    private readonly float MOVE_SPEED = 300;

    private GameManagerUI gameManagerUI;

    private void Awake()
    {
        gameManagerUI = GameManager.Instance.GetComponent<GameManagerUI>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -MOVE_SPEED);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.EndGame();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.Score++;
        gameManagerUI.UpdateScore();
    }
}

