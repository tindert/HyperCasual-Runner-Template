using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;
    [SerializeField] Color handleActiveColor;
    [SerializeField] private bool isAnimationsEnabled;

    Image backgroundImage, handleImage;

    Color backgroundDefaultColor, handleDefaultColor;

    Toggle toggle;

    Vector2 handlePosition;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();

        handlePosition = uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        handleImage = uiHandleRectTransform.GetComponent<Image>();

        backgroundDefaultColor = backgroundImage.color;
        handleDefaultColor = handleImage.color;

        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
    }

    void OnSwitch(bool on)
    {
        if (!isAnimationsEnabled)
        {
            uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition;
            backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
            handleImage.color = on ? handleActiveColor : handleDefaultColor;
        }
        else
        {
            uiHandleRectTransform.DOAnchorPos(on ? handlePosition * -1 : handlePosition, .3f).SetEase(Ease.InOutBack);

            backgroundImage.DOColor(on ? backgroundActiveColor : backgroundDefaultColor, .3f);

            handleImage.DOColor(on ? handleActiveColor : handleDefaultColor,.3f);
        }
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
