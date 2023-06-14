using UnityEngine;

public class CollectedGemsUI : MonoBehaviour
{
    [SerializeField] private GameObject popUpObject;
    [SerializeField] private GameObject popUpOpener;

    // used by unity button action system
    public void OpenPopUp()
    {
       popUpObject.SetActive(true);
       popUpOpener.SetActive(false);
    }

    // used by unity button action system
    public void ClosePopUp()
    {
        popUpObject.SetActive(false);
        popUpOpener.SetActive(true);
    }
}
