using System;
using UnityEngine;
public class Player : MonoBehaviour
{
    public Action onHexExit;

    private float movement;

    private readonly float MOVE_SPEED = 300;

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
        onHexExit?.Invoke();
    }
}

