using System.Collections;
using UnityEngine;

public class Soil : Interactable
{


    [SerializeField] GameObject plant_Prefab;
    [SerializeField] GameObject UI;
    [SerializeField] UI_Controller uI_Controller;

    private bool _IsnInContactWithPlayer = false;
    
    
    const float TIME_FOR_SEED_TO_GROW = 3.0f;


    public override void Interact(GameObject gameObject)
    {
        if(gameObject.CompareTag("Player"))
        {  
            StartPlanting();
        }
    }

    private void Start()
    {
        UI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _IsnInContactWithPlayer)
        {
            Interact(GameObject.FindGameObjectWithTag("Player"));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.tag == "Player")
        {
            ActivateUI();
            _IsnInContactWithPlayer = true;
        }
    }

   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Checks if the Ui_Controller attached to this game object is not in a growing or collecting state
            //And deactivates the UI accordingly
            
            if(uI_Controller != null)
            {
                if(uI_Controller.state == 0)
                {
                    DeActivateUI();
                }
            }

            _IsnInContactWithPlayer = false;
        }

    }

    private void ActivateUI()
    {
        UI.SetActive(true);
    }

    private void DeActivateUI()
    {
        UI.SetActive(false);
    }

    /// <summary>
    /// activates the ui and sets the UI Controller state to loading
    /// </summary>
    private void StartPlanting()
    {
        ActivateUI();
        uI_Controller.SetState(1);
        StartCoroutine(GrowSeed());
    }

    /// <summary>
    /// This Coroutine is used to wait an amount of time before spawning a new plant for the player to collect
    /// </summary>
    /// <returns></returns>
    IEnumerator GrowSeed()
    {
        
        yield return new WaitForSeconds(TIME_FOR_SEED_TO_GROW);
        GameObject newPlant = Instantiate(plant_Prefab) as GameObject;
        newPlant.transform.position = this.transform.position;
        Destroy(this.gameObject);
        
    }
}
