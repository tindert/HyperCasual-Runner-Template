using UnityEngine;
using DG.Tweening;

public class PanelTweener : MonoBehaviour
{
    [SerializeField] private RectTransform[] panelElements;
    [SerializeField] private float tweenDuration;
    [SerializeField] private float tweenDelay;
    [SerializeField] private Ease easeType = Ease.InSine;

    private void Start()
    {
        foreach (var element in panelElements)
        {
            element.localScale = Vector3.zero;
        }
    }

    public void TweenPanel()
    {
        for (int i = 0; i < panelElements.Length; i++)
        {
            panelElements[i].DOScale(1, tweenDuration).SetEase(easeType).SetDelay(tweenDelay*i);
        }
    }
}
