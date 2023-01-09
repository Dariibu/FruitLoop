using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour
{
    public Camera FruitCamera;
    public Camera GeneralCamera;
    public Camera ShootingCamera;

    public void StartMenu()
    {
        FruitCamera.enabled = false;
        GeneralCamera.enabled = true;
        ShootingCamera.enabled = false;
    }

    public void FruitCam()
    {
        FruitCamera.enabled = true;
        GeneralCamera.enabled = false;
        ShootingCamera.enabled = false;
    }

    public void ShootingDirection()
    {
        ShootingCamera.enabled = true;
        GeneralCamera.enabled = false;
        FruitCamera.enabled = false;
    }
}
