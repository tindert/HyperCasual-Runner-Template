using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PressMovement : MonoBehaviour
{
    [SerializeField] float moveValue;
    [SerializeField] float moveDuration;
    [SerializeField] float crashDuration;
    [SerializeField] float startDelay;
    void Start()
    {
        StartCoroutine(MovePress());
    }

    IEnumerator MovePress()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            transform.DOLocalMoveY(moveValue, moveDuration).SetEase(Ease.Linear);
            transform.DOLocalMoveY(6, crashDuration).SetEase(Ease.InSine).SetDelay(moveDuration);
            yield return new WaitForSeconds(crashDuration + moveDuration);
        }
    }
}
