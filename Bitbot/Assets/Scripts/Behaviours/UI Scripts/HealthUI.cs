using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public FloatReference HP;
    private RectTransform rect;
    //private Image fillImage;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        rect.sizeDelta = new Vector2(HP, 100);
    }
}
