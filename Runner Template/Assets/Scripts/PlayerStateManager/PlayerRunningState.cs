using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    private Animator playerAnim;
    private float movementSpeed = 20;
    private float horizontalSpeed = 6;
    private Vector3 startPos;

    [Header("TouchInputs")]
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    private float jumpTime;

    private Transform playerTransform;
    public override void EnterState(PlayerStateManager player)
    {
        playerAnim = player.GetComponentInChildren<Animator>();
        playerTransform = player.transform;
        //Running Animations
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.transform.position += new Vector3(0, 0, movementSpeed*Time.deltaTime);

        HorizontalMovement(player.transform);
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            PlayerLevelManager.instance.ChangeLevel(-5,false);
        }

        if (other.CompareTag("End"))
        {
            player.SwitchState(player.WinState);
        }

        if (other.CompareTag("LevelEnemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.Die();
            PlayerLevelManager.instance.VSPlayer(enemy.enemyLevel);
        }

        /*if (other.CompareTag("Jumper"))
        {
            while (jumpTime < .5f)
            {
                jumpTime += Time.deltaTime;
                float duration = .5f;
                float t01 = jumpTime / duration;

                Vector3 arc = Vector3.up * 5 * Mathf.Sin(t01 * 3.14f);

                playerTransform.position += arc;
            }

            jumpTime = 0;
        }*/
    }

    public void HorizontalMovement(Transform player)
    {
#if UNITY_EDITOR

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 dir = Input.mousePosition - startPos;
            player.position += new Vector3(dir.normalized.x * horizontalSpeed * Time.fixedDeltaTime, 0, 0);
            player.position = new Vector3(Mathf.Clamp(player.position.x, -6, 6), player.position.y, player.position.z);
            startPos = Input.mousePosition;
        }
#else

        CheckTouch(Transform player);

#endif


    }

    #region Touch
    void CheckTouch(Transform player)
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            //Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            //Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
    }


    void DetectSwipe()
    {

        /*if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
		{
			if (fingerDownPos.y - fingerUpPos.y > 0)
			{
				OnSwipeUp();
			}
			else if (fingerDownPos.y - fingerUpPos.y < 0)
			{
				OnSwipeDown();
			}
			fingerUpPos = fingerDownPos;

		}
		else */
        if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
    }

    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    void OnSwipeUp()
    {
        //Do something when swiped up
    }

    void OnSwipeDown()
    {
        //Do something when swiped down
    }

    void OnSwipeLeft()
    {
        playerTransform.position -= new Vector3(HorizontalMoveValue() * Time.deltaTime, 0, 0);
        playerTransform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, -6, 6), playerTransform.position.y, playerTransform.position.z);
    }

    void OnSwipeRight()
    {
        playerTransform.position += new Vector3(HorizontalMoveValue() * Time.deltaTime, 0, 0);
        playerTransform.position = new Vector3(Mathf.Clamp(playerTransform.position.x, -6, 6), playerTransform.position.y, playerTransform.position.z);
    }
    #endregion
}
