using System.Collections;
using UnityEngine;

public class Plant : Interactable
{
    [SerializeField] GameObject soil_Prefab;
    private const float TIME_FOR_SOIL_TO_REAPPEAR = 1.5f;

    private const int PLANT_VALUE = 10;
    Player player;
    private bool isInContactWithPlayer = false;

    private void Start()
    {
        player = GetPlayer();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isInContactWithPlayer)
        {
            Interact(player.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInContactWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isInContactWithPlayer = false;
        }
    }

    public override void Interact(GameObject gameObject)
    {
        if(gameObject.tag == "Player")
        {
            CollectCoins(PLANT_VALUE);
        }
    }

    /// <summary>
    /// Adds the amount sent to the player's coins sum 
    /// </summary>
    /// <param name="amount">amount</param>
    private void CollectCoins(int amount)
    {
        if(player == null)
        {
            player = GetPlayer();
        }

        player.AddCoins(amount);
   
        StartCoroutine(AddSoil(this.gameObject.transform.position));

        // Set the plant's scale to 0 to make it disappear from the user's view and to keep the
        // coroutine running (Disabling or destroying the object will cause the thread to stop running)
        this.gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

   
    

    /// <summary>
    /// Returns the player component of the game object with the tag Player
    /// </summary>
    /// <returns></returns>
    Player GetPlayer()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");
        player = obj.GetComponent<Player>();
        return player;
    }

    /// <summary>
    /// Waits an amout of time before adding a new soil to the sent position and destroying the 
    /// current Plant
    /// </summary>
    /// <param name="position">Spawn Position</param>
    /// <returns></returns>
    IEnumerator AddSoil(Vector3 position)
    {
        yield return new WaitForSeconds(TIME_FOR_SOIL_TO_REAPPEAR);
        GameObject newSoil = Instantiate(soil_Prefab) as GameObject;
        newSoil.transform.position = position;
        Destroy(this.gameObject);
    }
}
