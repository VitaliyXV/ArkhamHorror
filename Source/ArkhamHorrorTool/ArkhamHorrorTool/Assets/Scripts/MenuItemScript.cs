using UnityEngine;

public class MenuItemScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("MenuItemStart");
    }

    public void OnMenuItemClick()
    {
        Debug.Log("Menu Item Click!");
    }
}
