using UnityEngine;
using UnityEngine.UI;

public class Selection_Banner : MonoBehaviour
{
    [SerializeField] Color myColor;

    public void SetMyColor()
    {
        GetComponent<Image>().color = myColor;
    }

    public void SetSelectionColor()
    {
        GetComponent<Image>().color = Color.green;
    }
}
