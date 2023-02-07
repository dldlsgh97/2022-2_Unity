using UnityEngine;
using Vuforia;

public class SimpleCloudRecoEventHandler : MonoBehaviour
{
    CloudRecoBehaviour mCloudRecoBehaviour;
    bool mIsScanning = false;
    string mTargetMetadata = "";
    public GameObject ar_1;
    public GameObject ar_2;
    public GameObject ar_3;

    public ImageTargetBehaviour ImageTargetTemplate;

    // Register cloud reco callbacks
   
    void Awake()
    {
        mCloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        mCloudRecoBehaviour.RegisterOnInitializedEventHandler(OnInitialized);
        mCloudRecoBehaviour.RegisterOnInitErrorEventHandler(OnInitError);
        mCloudRecoBehaviour.RegisterOnUpdateErrorEventHandler(OnUpdateError);
        mCloudRecoBehaviour.RegisterOnStateChangedEventHandler(OnStateChanged);
        mCloudRecoBehaviour.RegisterOnNewSearchResultEventHandler(OnNewSearchResult);
    }
    //Unregister cloud reco callbacks when the handler is destroyed
    void OnDestroy()
    {
        mCloudRecoBehaviour.UnregisterOnInitializedEventHandler(OnInitialized);
        mCloudRecoBehaviour.UnregisterOnInitErrorEventHandler(OnInitError);
        mCloudRecoBehaviour.UnregisterOnUpdateErrorEventHandler(OnUpdateError);
        mCloudRecoBehaviour.UnregisterOnStateChangedEventHandler(OnStateChanged);
        mCloudRecoBehaviour.UnregisterOnNewSearchResultEventHandler(OnNewSearchResult);
    }

    public void OnInitialized(CloudRecoBehaviour cloudRecoBehaviour)
    {
        Debug.Log("Cloud Reco initialized");
    }

    public void OnInitError(CloudRecoBehaviour.InitError initError)
    {
        Debug.Log("Cloud Reco init error " + initError.ToString());
    }

    public void OnUpdateError(CloudRecoBehaviour.QueryError updateError)
    {
        Debug.Log("Cloud Reco update error " + updateError.ToString());

    }

    public void OnStateChanged(bool scanning)
    {
        mIsScanning = scanning;

        if(scanning)
        {
            // Clear all known targets
        }
    }

    public void ar_1Active()
    {
        ar_1.gameObject.SetActive(true);
        ar_2.gameObject.SetActive(false);
        ar_3.gameObject.SetActive(false);
    }
    public void ar_2Active()
    {
        ar_2.gameObject.SetActive(true);
    }

    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(CloudRecoBehaviour.CloudRecoSearchResult cloudRecoSearchResult)
    {
        // Build augmentation based on target 
        if(ImageTargetTemplate)
        {
            /* Enable the new result with the same ImageTargetBehaviour: */
            mCloudRecoBehaviour.EnableObservers(cloudRecoSearchResult, ImageTargetTemplate.gameObject);
        }
        // Store the target metadata
        mTargetMetadata = cloudRecoSearchResult.MetaData;
        if (mTargetMetadata == "hi")
        {
            /*ar_1.gameObject.SetActive(true);
            ar_2.gameObject.SetActive(false);
            ar_3.gameObject.SetActive(false);
            */
            ar_1Active();
            Debug.Log("1");

        }
        else if(mTargetMetadata == "HeartKing")
        {
            ar_1.gameObject.SetActive(false);
            ar_2.gameObject.SetActive(true);
            ar_3.gameObject.SetActive(false);
            
            Debug.Log("2");
        }
        else if (mTargetMetadata == "itachi")
        {
            
            ar_1.gameObject.SetActive(false);
            ar_2.gameObject.SetActive(false);
            ar_3.gameObject.SetActive(true);
            
            Debug.Log("3");
        }

        // Stop the scanning by disabling the behaviour
        mCloudRecoBehaviour.enabled = false;
    }
    
    void OnGUI()
    {
        // Display current 'scanning' status
        GUI.Box(new Rect(100, 100, 200, 50), mIsScanning ? "Scanning" : "Not scanning");
        // Display metadata of latest detected cloud-target
        GUI.Box(new Rect(100, 200, 200, 50), "Metadata: " + mTargetMetadata);
        // If not scanning, show button
        // so that user can restart cloud scanning
        if(!mIsScanning)
        {
            if(GUI.Button(new Rect(100, 300, 200, 50), "Restart Scanning"))
            {
                // Reset Behaviour
                mCloudRecoBehaviour.enabled = true;
                mTargetMetadata = "";
            }
        }
    }
}