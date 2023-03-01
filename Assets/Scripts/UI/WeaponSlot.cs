using UnityEngine;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour
{
    private OutfitShipUI _outfitShipUI;
    private Image _weaponImage;

    public void SetupSlot(OutfitShipUI outfitShipUI)
    {
        _outfitShipUI = outfitShipUI;
        _weaponImage = GetComponent<Image>();
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
        DisplayWeapon();

        // TODO: Need to set the WeaponIndex on this slot as well. 

    }

    public void PreviousWeapon()
    {
        _outfitShipUI.PreviousWeapon();
        DisplayWeapon();
        
        // TODO: Need to set the WeaponIndex on this slot as well. 
    }

    private void DisplayWeapon()
    {
        GameObject weapon = _outfitShipUI.OwnedWeapons[_outfitShipUI.WeaponIndex];
        _weaponImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
    }
}