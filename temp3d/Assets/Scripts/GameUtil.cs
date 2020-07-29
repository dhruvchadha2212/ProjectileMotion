using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtil : MonoBehaviour
{
    public static Vector3 GetMousePositionInWorld(Vector3 mousePosScreen, Vector3 ballPosWorld)
    {
        //mousePosScreen is position of mouse keeping bottom left of game window as (0, 0)
        mousePosScreen.z = Camera.main.WorldToScreenPoint(ballPosWorld).z; //Doesn't work if z not set properly
        return Camera.main.ScreenToWorldPoint(mousePosScreen);
    }
}
