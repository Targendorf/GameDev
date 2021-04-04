using PlayFab;
using PlayFab.ClientModels;
using PlayFab.PfEditor.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabController : MonoBehaviour
{
    public Button HelloBtn;
    // Start is called before the first frame update
    void Start()
    {
        Login();
        Button btn = HelloBtn.GetComponent<Button>();
        btn.onClick.AddListener(StartCloudHelloWorld);

    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

        void OnSuccess(LoginResult result)
        {
            Debug.Log("Successful!!!");
        }

        void OnError(PlayFabError error)
        {
            Debug.Log("Error");
            Debug.Log(error.GenerateErrorReport());

        }

    }

    // Build the request object and access the API
    private static void StartCloudHelloWorld()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "helloWorld", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new { inputValue = "Targendorf" }, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudHelloWorld, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block
    private static void OnCloudHelloWorld(ExecuteCloudScriptResult result)
    {
        // CloudScript returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(JsonWrapper.SerializeObject(result.FunctionResult));

    }

    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }



}
