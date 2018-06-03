using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameController GC;
    public MusicManager MM;

    private Slider musicSlider;

    public Toggle easy;
    public Toggle hard;

    public PlayerShip player;

    // Use this for initialization
    void Start()
    {
        //--------------------------------------------------------------------------
        // Game Settings Related Code


        //--------------------------------------------------------------------------
        // Music Settings Related Code
        musicSlider = GameObject.Find("MusicSlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        ScanForKeyStroke();
    }

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape")) GC.TogglePauseMenu();
    }

    public void MusicSliderUpdate(float val)
    {
        MM.SetVolume(val);
    }

    public void MusicToggle(bool val)
    {
        musicSlider.interactable = val;
        MM.SetVolume(val ? musicSlider.value : 0f);
    }

    public void EasyToggle()
    {

        if (easy.isOn)
        {
            player.GetComponent<PlayerHealth>().StartingHealth = 100;
            player.GetComponent<PlayerHealth>().currentHealth = 100;
            easy.isOn = true;
            hard.isOn = false;
        }
        else { HardToggle(); easy.isOn = false; }

    }

    public void HardToggle()
    {
        if (hard.isOn)
        {
            player.GetComponent<PlayerHealth>().StartingHealth = 50;
            player.GetComponent<PlayerHealth>().currentHealth = 50;
            hard.isOn = true;
            easy.isOn = false;
        }
        else { EasyToggle(); hard.isOn = false; }
    }
}
