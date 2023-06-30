using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Hexagon : MonoBehaviour
{
    private Rigidbody2D rb;

    private Side[] sides;

    private readonly float shrinkSpeed = 2f;

    public float RotationSpeed { get; set; }
    public ColorChangerBackground ColorChangerBackground { get; set; }

    public HexSpawner HexSpawner { get; set; }

    private void Awake()
    {
        sides = GetComponentsInChildren<Side>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        rb.rotation += Time.deltaTime * 50 * RotationSpeed;

        if (transform.localScale.x <= 0.5f)
        {
            HexSpawner.Pool.Release(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ColorChangerBackground.RemoveFirstColor();
    }

    public void ChangeTriggerSide(SideColor sideColor)
    {
        foreach (Side side in sides)
        {
            if (side.SideColor == sideColor)
            {
                side.EdgeCollider.isTrigger = true;
            }
            else
            {
                side.EdgeCollider.isTrigger = false;
            }
        }
    }
}
