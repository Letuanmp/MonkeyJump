using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Obstacle : MonoBehaviour
{
    private float upEdge;
    public float speed=2f;
    private void Start() {
        upEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 12f;
            }
    private void Update() {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.y > upEdge) {
            Destroy(gameObject);
        }
    }
}
