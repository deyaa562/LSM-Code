using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    public Rigidbody2D rb;
    public Text coinsText;
    Vector2 movement;

    public int coins = 0;

    private static Player _Instance;


    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
        else if(_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coinsText.text = coins.ToString();

    }

    public void SubstractCoins(int amount)
    {
        coins -= amount;
        coinsText.text = coins.ToString();
    }
}
