using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSlot : MonoBehaviour
{
    private OutfitShipUI _outfitShipUI;

    private void OnEnable()
    {
        S.I.IM.PC.Gameplay.Move.performed += HandleDirectionInput;
    }

    private void OnDisable()
    {
        S.I.IM.PC.Gameplay.Move.performed -= HandleDirectionInput;
    }

    public void SetupSlot(OutfitShipUI outfitShipUI)
    {
        _outfitShipUI = outfitShipUI;
    }

    private void HandleDirectionInput(InputAction.CallbackContext obj)
    {
        Debug.Log("HandleDirectionInput called");
        // UP
        if (obj.ReadValue<Vector2>().y > 0.5)
        {
            NextWeapon();
        }
        // DOWN
        else if (obj.ReadValue<Vector2>().y < -0.5)
        {
            PreviousWeapon();
        }
        // RIGHT
        else if (obj.ReadValue<Vector2>().x > 0.5)
        {
            NextSlot();
        }
        // LEFT
        else if (obj.ReadValue<Vector2>().x < -0.5)
        {
            PreviousSlot();
        }
        else
        {
            Debug.Log("Direction Input: " + obj.ReadValue<Vector2>());
        }
    }

    // These get called from the buttons on the weapon slot.
    // The outfitShipUI ones change the index which this class references. 
    public void NextSlot()
    {
        _outfitShipUI.NextSlot();
    }

    public void PreviousSlot()
    {
        _outfitShipUI.PreviousSlot();
    }

    public void NextWeapon()
    {
        // Displays weapon in the little selector on the left and the big display on the right. 
        _outfitShipUI.NextWeapon();

        Debug.Log($"Next weapon, slot: {_outfitShipUI.SlotIndex}, weapon: {_outfitShipUI.WeaponIndex}");
    }

    public void PreviousWeapon()
    {
        _outfitShipUI.PreviousWeapon();

        Debug.Log($"Previous weapon, slot: {_outfitShipUI.SlotIndex}, weapon: {_outfitShipUI.WeaponIndex}");
    }
}