using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform hatContainer;
    private List<GameObject> hatModels = new List<GameObject>();
    private Hat[] hats;
    private void Start()
    {
        hats = Resources.LoadAll<Hat>("Hat/");
        SpawnHats();
        SelectHat(SaveManager.Instance.save.CurrentHatIndex);
    }
    private void SpawnHats()
    {
        for (int i = 0; i < hats.Length; i++)
        {
            GameObject go = Instantiate(hats[i].Model, hatContainer);
            hatModels.Add(go);
        }
    }
    public void DisableAllHats()
    {
        for(int i = 0;i < hatModels.Count;i++)
        {
            hatModels[i].SetActive(false);
        }
    }
    public void SelectHat(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true);
    }
}
