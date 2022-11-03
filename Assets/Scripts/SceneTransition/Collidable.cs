using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
From: https://www.youtube.com/watch?v=b8YUfee_pzc
Minute: 1:40:31
*/

// So that when dragging the script it also includes BoxCollider2D
// [RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() {
        //Collision work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; ++i) {
            if (hits[i] == null) continue;

            OnCollide(hits[i]);

            // Clean up the array
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll) {
        Debug.Log(coll.name);
    }

}
