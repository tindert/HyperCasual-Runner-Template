using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int enemyLevel;
    [SerializeField] TextMeshPro levelText;

    private void Start()
    {
        levelText.text = enemyLevel.ToString();
    }

    public void Die()
    {
        //death animations
        Destroy(gameObject);
    }
}
