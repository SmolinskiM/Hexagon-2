using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private SideColor[] sideColors;

    [SerializeField] private ColorChangerBackground colorChangerBackground;

    private readonly int COLOR_COUNT = 6;

    public SideColor RandomingColor()
    {
        int randomColor = Random.Range(0, COLOR_COUNT);
        SideColor sideColor = sideColors[randomColor];
        colorChangerBackground.AddNextColor(sideColor);
        return sideColor;
    }
}
