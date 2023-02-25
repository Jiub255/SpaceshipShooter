using UnityEngine;

[CreateAssetMenu(fileName = "New Note SO",
    menuName = "Scriptable Objects/Note SO")]
public class NoteSO : ScriptableObject
{
	// Doesn't do anything in game. Only used for keeping little notes inside the assets folder. 
    // Can use this field to add a more detailed explanation. 
    [SerializeField, TextArea(3,20)]
    private string DetailedExplanation;
}