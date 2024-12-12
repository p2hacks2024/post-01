using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // キャラクターの移動速度
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力を取得
        movement.x = Input.GetAxisRaw("Horizontal"); // 左右の入力 (-1, 0, 1)
        movement.y = Input.GetAxisRaw("Vertical");   // 上下の入力 (-1, 0, 1)
    }

    void FixedUpdate()
    {
        // Rigidbody2Dを使用してキャラクターを移動
        rb.linearVelocity = movement * moveSpeed;
    }
}

