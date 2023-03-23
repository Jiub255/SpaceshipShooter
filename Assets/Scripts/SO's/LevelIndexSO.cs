using UnityEngine;

[CreateAssetMenu(fileName = "New Level Index SO",
    menuName = "Scriptable Objects/Level Index SO")]
public class LevelIndexSO : ScriptableObject
{
    public int Value = 1;

    private void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}