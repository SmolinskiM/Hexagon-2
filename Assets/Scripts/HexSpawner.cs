using UnityEngine;
using UnityEngine.Pool;

public class HexSpawner : MonoBehaviour
{
    [SerializeField] private Hexagon hexagonPref;

    [SerializeField] private ColorChanger colorChanger;

    [SerializeField] private ColorChangerBackground colorChangerBackground;

    private float timeToSpawnLeft;

    private IObjectPool<Hexagon> pool;

    private readonly float TIME_TO_SPAWN = 2.5f;

    public IObjectPool<Hexagon> Pool { get { return pool; } }

    private void Awake()
    {
        pool = new ObjectPool<Hexagon>(CreatePooledItem, ActionOnGet, ActionOnRelease);
        SpawnHex();
    }

    private void Update()
    {
        if (timeToSpawnLeft <= 0)
        {
            SpawnHex();
        }
        else
        {
            timeToSpawnLeft -= Time.deltaTime;
        }
    }

    private void SpawnHex()
    {
        Hexagon hexagon = pool.Get();
        hexagon.ChangeTriggerSide(colorChanger.RandomingColor());

        if (GameManager.Instance.Score >= 10)
        {
            hexagon.RotationSpeed = Random.Range(-2, 3);
        }

        timeToSpawnLeft = TIME_TO_SPAWN;
    }

    private Hexagon CreatePooledItem()
    {
        Hexagon hexagon = Instantiate(hexagonPref, Vector3.zero, Quaternion.identity);
        hexagon.HexSpawner = this;
        hexagon.ColorChangerBackground = colorChangerBackground;
        return hexagon;
    }

    private void ActionOnGet(Hexagon hexagon)
    {
        hexagon.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Hexagon hexagon)
    {
        hexagon.gameObject.SetActive(false);
        hexagon.transform.localScale = new Vector3(15, 15, 1);
    }
}
