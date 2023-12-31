﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float upEdge;

    Tutorial tt;
    private void Start()
    {
        upEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 12f;
        tt = GetComponent<Tutorial>();
    }

    private void Update()
    {
        
        
            transform.position += Vector3.up * FindAnyObjectByType<SpawnerManager>().speed * Time.deltaTime;

            if (transform.position.y > upEdge)
            {
                Destroy(gameObject);
            }
    }

    


}
