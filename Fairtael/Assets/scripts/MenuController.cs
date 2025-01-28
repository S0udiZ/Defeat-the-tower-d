using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public playercontroller playercontroller;
    

    public GameObject PauseMenu;
    public bool pauseMenuUp = false;

    public GameObject InventoryMenu;
    public bool inventoryMenuUp = false;
    

    public GameObject MainMenu;
    public GameObject SettingsMenu;


    float LevelMenuOpen;
    void Start()
    {
        playercontroller = GameObject.FindWithTag("Player").GetComponent<playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {

        //pauseMenu
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenuUp && SceneManager.GetActiveScene().buildIndex != 0)

        {
            PauseMenu.SetActive(true);
            InventoryMenu.SetActive(false);
            pauseMenuUp = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuUp && SceneManager.GetActiveScene().buildIndex != 0)
        {
            PauseMenu.SetActive(false);
            pauseMenuUp = false;
            Time.timeScale = 1f;
            Cursor.visible = false;   
        }


        //inventory
        if (Input.GetKeyDown(KeyCode.E) && !inventoryMenuUp && !pauseMenuUp && SceneManager.GetActiveScene().buildIndex != 0)

        {
            InventoryMenu.SetActive(true);
            inventoryMenuUp = true;
            //Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventoryMenuUp && SceneManager.GetActiveScene().buildIndex != 0)
        {
            InventoryMenu.SetActive(false);
            inventoryMenuUp = false;
            //Time.timeScale = 1f;
        }

    }

    //also pause menu
    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Cursor.visible = true;
    }
    public void ReloadSceneButton()
    {
        Time.timeScale = 1f;
        playercontroller.inventory.items.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    //this shi is both dumbass
    public void QuitButton()
    {
        Application.Quit();
    }


    //main menu
    public void StartButton()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = false;
    }

    public void SettingsButton()
    {
        SettingsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void BackButton()
    {
        SettingsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

}
