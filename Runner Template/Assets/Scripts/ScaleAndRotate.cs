using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleAndRotate : MonoBehaviour
{
    [Header("ScaleAttribues")]
    [SerializeField] float aimScale;
    [SerializeField] float scaleDuration;
    private Vector3 startScale;

    [Space]
    [Header("RotationAttribues")]
    [SerializeField] float rotationSpeed;
    [SerializeField] private Vector3 axis = new Vector3(0, 1, 0);
    void Start()
    {
        startScale = transform.localScale;
        if (aimScale == 0)
        {
            return;
        }
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        while (true)
        {
            transform.DOScale(aimScale, scaleDuration).SetEase(Ease.InSine);
            transform.DOScale(startScale, scaleDuration).SetEase(Ease.InSine).SetDelay(scaleDuration);
            yield return new WaitForSeconds(scaleDuration * 2);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}
