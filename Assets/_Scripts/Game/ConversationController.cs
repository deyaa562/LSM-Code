using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    [Header("Assign in Inspector")]
    public Conversation conversationSO;

    public Text conversation_Text;
    public GameObject icon_Assistant;
    public GameObject icon_Customer;
    public GameObject StoreBG;
    public GameObject CollectionsSection;

    private static ConversationController _Instance;

    private int _ConversationIndex = 0;


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


    // Start is called before the first frame update
    void Start()
    {
        icon_Assistant.SetActive(true);
        icon_Customer.SetActive(false);

        conversation_Text.text = conversationSO.text[_ConversationIndex];
    }


    /// <summary>
    /// This is used to enable the icon of which character is saying the current text
    /// </summary>
    /// <param name="conversationIndex">The index of the next text in the array</param>
    public void UpdateConversation()
    {
        if (_ConversationIndex < conversationSO.text.Length - 1)
        {
            _ConversationIndex++;

            if (_ConversationIndex % 2 == 0 || _ConversationIndex == 0)
            {
                icon_Assistant.SetActive(true);
                icon_Customer.SetActive(false);
            }
            else if (_ConversationIndex % 1 == 0)
            {
                icon_Assistant.SetActive(false);
                icon_Customer.SetActive(true);
            }


            conversation_Text.text = conversationSO.text[_ConversationIndex];
        }
        else
        {
            CollectionsSection.SetActive(true);

            _ConversationIndex = 0;
            conversation_Text.text = conversationSO.text[_ConversationIndex];

            StoreBG.SetActive(true);
            gameObject.SetActive(false);
        }

    }


}
