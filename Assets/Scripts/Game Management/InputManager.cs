using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerControls PC { get; private set; }

    private void Awake()
    {
        PC = new PlayerControls();

        // Enable "Home" and "Gameplay" as default action maps
        PC.Disable();
        PC.Gameplay.Enable();
    }
}