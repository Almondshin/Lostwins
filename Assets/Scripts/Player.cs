using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 movement;

    // �ؾ� �� ��
    /* 1. boxcollider ĳ���Ͱ� �ε����Ը���� -> OK!!
     * 2. ĳ���� ���ǵ� Ư������ ������ �������� �� �� �ֵ��� ����� -> �̰� Ư������ ���� �� ����
     * 3. ĳ���Ͱ� �����̴� �������� ĳ���� ȸ����Ű�� -> �¿�(?)ȸ���� �̹� ���� �Ǿ�����
     */
   
    private BoxCollider2D boxCollider;
    public float xSpeed = 1.0f;
    public float ySpeed = 0.75f;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement = new Vector3(x, y, 0);
        // leftRight = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);


        if (movement.x > 0)
            transform.localScale = Vector3.one;
        else if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movement.y), Mathf.Abs(movement.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(0, movement.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
        if (hit.collider == null)
        {
            transform.Translate(movement.x * Time.deltaTime, 0, 0);
        }
    }
}
