using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleColorChanger : MonoBehaviour
{
    [SerializeField] private List<Color> colors;

    private int colorIndex = 0;

    private float lerpTimeLeft;

    private readonly float LERP_TIME = 1;

    private TextMeshProUGUI title;

    private void Start()
    {
        title = GetComponent<TextMeshProUGUI>();
        lerpTimeLeft = LERP_TIME;
    }

    private void Update()
    {
        title.color = Color.Lerp(title.color, colors[colorIndex], LERP_TIME * Time.deltaTime);

        if (lerpTimeLeft <= 0)
        {
            colorIndex++;
            if (colorIndex == colors.Count)
            {
                colorIndex = 0;
            }

            lerpTimeLeft = LERP_TIME;
        }
        else
        {
            lerpTimeLeft -= Time.deltaTime;
        }
    }
}
