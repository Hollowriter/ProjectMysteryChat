using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public static CameraFollower mainCamera = null;

    private void Awake()
    {
        if (mainCamera == null)
        {
            DontDestroyOnLoad(gameObject);
            mainCamera = this;
        }
        else if (mainCamera != this)
        {
            Destroy(gameObject);
        }
    }

    public void Follow()
    {
        float interpolation = PlayerController.mainPlayer.GetPlayerSpeed() * Time.deltaTime;
        Vector3 position = this.transform.position;
        position.z = Mathf.Lerp(this.transform.position.z, PlayerController.mainPlayer.transform.position.z, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, PlayerController.mainPlayer.transform.position.x, interpolation);
        this.transform.position = position;
    }

    public void Behave()
    {
        if (InputHandler.input.inputDetected())
        {
            Follow();
        }
    }

    void Update()
    {
        Behave();
    }
}
 