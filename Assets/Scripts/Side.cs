using UnityEngine;

public class Side : MonoBehaviour
{
    [SerializeField] private SideColor sideColor;

    private EdgeCollider2D edgeCollider;

    public SideColor SideColor { get { return sideColor; } }
    public EdgeCollider2D EdgeCollider { get { return edgeCollider; } }

    private void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }
}
