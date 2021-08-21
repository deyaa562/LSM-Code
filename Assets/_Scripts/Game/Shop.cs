using UnityEngine;

public class Shop : Interactable
{
    private static Shop _Instance;
    private bool _IsInteractingWithPlayer;

    [Header("Assign in Inspector")]
    public GameObject UI_Store;
    public GameObject UI_BG;
    public GameObject UI_Conversation;
    public GameObject UI_Game;
    public GameObject UI_Icon;
    public override void Interact(GameObject gameObject)
    {
        if (gameObject.tag == "Player")
        {
            UI_Store.SetActive(true);
            UI_Conversation.SetActive(true);
            UI_Game.SetActive(false);
            UI_BG.SetActive(false);
        }
    }

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
        }
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
        }

        _IsInteractingWithPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _IsInteractingWithPlayer)
        {
            Interact(GameObject.FindGameObjectWithTag("Player"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _IsInteractingWithPlayer = true;
            UI_Icon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _IsInteractingWithPlayer = false;
            UI_Icon.SetActive(false);

        }
    }

}

