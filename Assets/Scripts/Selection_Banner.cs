using UnityEngine;
using UnityEngine.UI;

public class Selection_Banner : MonoBehaviour
{
    [SerializeField] Color myColor;

    public void SetMyColor()
    {
        GetComponent<Image>().color = myColor;
        Debug.Log("Strano");
    }

    public void SetSelectionColor()
    {
        GetComponent<Image>().color = Color.green;
        Debug.Log("Strano");
    }
}
