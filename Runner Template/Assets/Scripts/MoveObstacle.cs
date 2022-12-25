using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float moveValue;
    [SerializeField] private float moveDuration;
    [SerializeField] private Vector3 dir;
    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        if (dir.x == 1)
        {
            while (true)
            {
                transform.DOLocalMoveX(moveValue, moveDuration).SetEase(Ease.Linear);
                transform.DOLocalMoveX(-moveValue, moveDuration).SetDelay(moveDuration).SetEase(Ease.Linear);
                yield return new WaitForSeconds(moveDuration * 2);
            }
        }
        else if (dir.y == 1)
        {
            while (true)
            {
                transform.DOLocalMoveY(moveValue, moveDuration).SetEase(Ease.Linear);
                transform.DOLocalMoveY(-moveValue, moveDuration).SetDelay(moveDuration).SetEase(Ease.Linear);
                yield return new WaitForSeconds(moveDuration * 2);
            }
        }
        else if (dir.z == 1)
        {
            while (true)
            {
                transform.DOLocalMoveZ(moveValue, moveDuration).SetEase(Ease.Linear);
                transform.DOLocalMoveZ(-moveValue, moveDuration).SetDelay(moveDuration).SetEase(Ease.Linear);
                yield return new WaitForSeconds(moveDuration * 2);
            }
        }
    }


}
