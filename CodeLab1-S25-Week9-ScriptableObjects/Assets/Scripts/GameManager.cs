using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LocationScriptableObject currentLocation;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;

    public Button northButt;
    public Button southButt;
    public Button eastButt;
    public Button westButt;

    public Image image;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UpdateLocation();
        currentLocation.UpdateUI(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveDirection(int dir)
    {
        switch (dir)
        {
            case 0:
                //move our current location to be the location north of here
                currentLocation = currentLocation.north;
                break;
            case 2:
                currentLocation = currentLocation.south;
                break;
            case 1:
                currentLocation = currentLocation.east;
                break;
            case 3:
                currentLocation = currentLocation.west;
                break;
            default:
                Debug.Log("The location: " + dir + "is not implemented");
                break;
        }
        
        currentLocation.UpdateUI(this);
        
        // if (dir == 0) //0 is North
        // {
        //     currentLocation = currentLocation.north;
        //     currentLocation.UpdateUI(this);
        // }
    }

    // void UpdateLocation()
    // {
    //     title.text = currentLocation.locationName;
    //     description.text = currentLocation.locationDesc;
    // }
}
