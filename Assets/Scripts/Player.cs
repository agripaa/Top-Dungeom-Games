using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollectCoin()
    {

    }

    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //reset moveDelta
        moveDelta = new Vector3(x,y, 0);

        // menentukkan untuk jalan player kanan / kiri
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one ;
        else if(moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 0);

        // Jalan Vertical / Atas Dan Bawah
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // membuat timing maju
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // Jalan Horizontal / Kanan Dan Kiri
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.x), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            // membuat timing maju
            transform.Translate(moveDelta.x * Time.deltaTime,0,0);
        }
    }
}
