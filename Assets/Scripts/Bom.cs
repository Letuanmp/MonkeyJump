using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public float des;
    private float downEdge;
    public float speed = 2f;
    private void Start()
    {
        downEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + des;
    }
    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < downEdge)
        {
            Destroy(gameObject);
        }
    }
}
