using Io.AppMetrica;
using UnityEngine;

public static class AppMetricaActivator
{
    private static readonly string _playerPrefsKey = "AppMetricaActivator-IsFirstLaunch";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void ActivateAppMetrica()
    {
        AppMetricaConfig appMetricaConfig = new("566d4876-b865-4b7a-b925-5fd8a6c7f6a0")
        {
            CrashReporting = true,
            SessionTimeout = 10,
            LocationTracking = false,
            Logs = false,
            FirstActivationAsUpdate = !IsFirstLaunch(),
            DataSendingEnabled = true,
        };

        AppMetrica.Activate(appMetricaConfig);
    }

    private static bool IsFirstLaunch()
    {
        if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            return false;
        }
        
        PlayerPrefs.SetInt(_playerPrefsKey, 1);
        PlayerPrefs.Save(); 
        return true;
        
        
        
        
        
        /*if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            return true;
        }

        PlayerPrefs.SetString(_playerPrefsKey, string.Empty);
        return false;*/
    }
}