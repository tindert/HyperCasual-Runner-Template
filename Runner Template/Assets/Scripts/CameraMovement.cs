using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    private float zOffset;

    [SerializeField] private float camXClampValue;

    [SerializeField]
    private float lerpSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zOffset = transform.position.z - player.position.z;
    }
    void Update()
    {
        Vector3 targetPos = new Vector3(Mathf.Clamp(player.position.x, -camXClampValue, camXClampValue), transform.position.y, player.position.z + zOffset);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * lerpSpeed);
    }
}
