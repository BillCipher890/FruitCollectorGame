using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public static int CurrentMaxFruitCount;
    public static int CurrentLevel;
    public static int CurrentMoney;

    public static bool IsUnlockLevel1Enabled;
    public static bool IsUnlockLevel2Enabled;
    public static bool IsUnlockLevel3Enabled;

    public static int UnlockLevel2Price;
    public static int UnlockLevel3Price;

    void Start()
    {
        GlobalEventManager.OnGetCurrentMaxFruitCount += SetCurrentMaxFruitCount;
        if (PlayerPrefs.HasKey("IsItNotFirstRun"))
        {
            CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        else
        {
            CurrentLevel = 0;
            PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
            PlayerPrefs.SetInt("IsItNotFirstRun", 1);

            PlayerPrefs.SetInt("IsUnlockLevel2Enabled",
                PlayerPrefs.HasKey("IsUnlockLevel2Enabled") ? PlayerPrefs.GetInt("IsUnlockLevel2Enabled") : 1);

            PlayerPrefs.SetInt("IsUnlockLevel3Enabled",
                PlayerPrefs.HasKey("IsUnlockLevel3Enabled") ? PlayerPrefs.GetInt("IsUnlockLevel3Enabled") : 1);
        }
        CurrentMoney = PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") : 0;

        IsUnlockLevel1Enabled = false;
        IsUnlockLevel2Enabled = PlayerPrefs.GetInt("IsUnlockLevel2Enabled") == 1;
        IsUnlockLevel3Enabled = PlayerPrefs.GetInt("IsUnlockLevel3Enabled") == 1;

        Debug.Log(string.Format("2={0},3={1}", IsUnlockLevel2Enabled, IsUnlockLevel3Enabled));

        UnlockLevel2Price = 50;
        UnlockLevel3Price = 150;

        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnGetCurrentMaxFruitCount -= SetCurrentMaxFruitCount;
    }

    private void SetCurrentMaxFruitCount(int currentCount)
    {
        CurrentMaxFruitCount = currentCount;
    }

    public void SetCurrentLevel(int level)
    {
        CurrentLevel = level;
    }
}
