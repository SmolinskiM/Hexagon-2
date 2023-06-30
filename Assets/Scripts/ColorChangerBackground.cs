using System.Collections.Generic;
using UnityEngine;

public class ColorChangerBackground : MonoBehaviour
{
    private float firstTimeCooldown = 4;

    private List<SideColor> colors = new List<SideColor>();

    private Dictionary<SideColor, Color> colorBySideColor = new Dictionary<SideColor, Color>();

    private SpriteRenderer backgroundSpriteRenderer;

    private void Awake()
    {
        backgroundSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        colorBySideColor.Add(SideColor.Blue, Color.blue);
        colorBySideColor.Add(SideColor.Cyan, Color.cyan);
        colorBySideColor.Add(SideColor.Green, Color.green);
        colorBySideColor.Add(SideColor.Magenta, Color.magenta);
        colorBySideColor.Add(SideColor.Red, Color.red);
        colorBySideColor.Add(SideColor.Yellow, Color.yellow);

        ChangeColorBackground();
    }

    private void Update()
    {
        if (firstTimeCooldown > 0)
        {
            firstTimeCooldown -= Time.deltaTime;
            return;
        }

        if (colors.Count > 0)
        {
            ChangeColorBackground();
        }
    }

    public void AddNextColor(SideColor sideColor)
    {
        colors.Add(sideColor);
    }

    public void ChangeColorBackground()
    {
        backgroundSpriteRenderer.color = Color.Lerp(backgroundSpriteRenderer.color, colorBySideColor[colors[0]], 4.5f * Time.deltaTime);
    }

    public void RemoveFirstColor()
    {
        colors.RemoveAt(0);
    }
}
