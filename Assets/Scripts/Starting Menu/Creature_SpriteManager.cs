using UnityEngine;
using UnityEngine.UI;

public class Creature_SpriteManager : MonoBehaviour
{
    public Sprite creature_01;
    public Sprite creature_02;
    public Sprite creature_03;

    public Sprite creature_NonSelected;

    public void UpdateCreature(int _creatureIndex)
    {
        switch (_creatureIndex)
        {
            case 0:
                Debug.LogWarning("ID Deck = 0, Non dovrebbe essere possibile");
                break;
            case 1:
                GetComponent<Image>().sprite = creature_01;
                break;
            case 2:
                GetComponent<Image>().sprite = creature_02;
                break;
            case 3:
                GetComponent<Image>().sprite = creature_03;
                break;
        }
    }

    public void ResetCreature()
    {
        GetComponent<Image>().sprite = creature_NonSelected;
    }
}
