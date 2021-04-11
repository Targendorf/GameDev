using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;

public class Cube : MonoBehaviour
{

    public struct UserAttrbutes { }
    public struct AppAttributes { }
    public bool isBlue = false;

    public Material blueMat;
    public Material redMat;

    public Renderer rend;
    void Aweke()
    {
        ConfigManager.FetchCompleted += SetColor;
        ConfigManager.FetchConfigs<UserAttrbutes, AppAttributes>(new UserAttrbutes(), new AppAttributes());
    }

    void SetColor(ConfigResponse response)
    {
        isBlue = ConfigManager.appConfig.GetBool("cubeIsBlue");
        
        if (isBlue)
        {
            rend.material = blueMat;
        } else
        {
            rend.material = redMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConfigManager.FetchConfigs<UserAttrbutes, AppAttributes>(new UserAttrbutes(), new AppAttributes());
        }
        
    }

    void OnDestroy()
    {
        ConfigManager.FetchCompleted -= SetColor;
    }
}
