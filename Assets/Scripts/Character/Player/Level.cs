using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] Slider expSlider;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Image levelUpBar;
    [SerializeField] ParticleSystem[] particles = new ParticleSystem[3];

    [SerializeField] GameObject levelUpWindow;
    [SerializeField] GameObject[] weaponSelect = new GameObject[4];
    [SerializeField] Image[] weaponIcon = new Image[4];
    [SerializeField] TextMeshProUGUI[] nameText = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI[] description = new TextMeshProUGUI[4];
    [SerializeField] TextMeshProUGUI[] levelText = new TextMeshProUGUI[4];
    [SerializeField] Button[] button = new Button[4];

    int maxExpValue;
    int curExpValue;
    static int level;
    static bool isLevelUpTime;

    enum type
    {
        Weapon,
        Accessory
    }

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        maxExpValue = 50;
        curExpValue = 0;
        level = 1;
        isLevelUpTime = false;
        expSlider.maxValue = maxExpValue;
        expSlider.value = curExpValue;
    }

    public static bool GetIsLevelUpTime()
    {
        return isLevelUpTime;
    }

    public static int GetPlayerLevel()
    {
        return level;
    }

    public void GetExp(int value)
    {
        if (curExpValue + value >= maxExpValue)
        {
            curExpValue += value - maxExpValue;
            LevelUp();
        }
        else
            curExpValue += value;

        //Debug.Log(value);

        expSlider.value = curExpValue;
    }

    void LevelUp()
    {
        isLevelUpTime = true;
        StartCoroutine(GetNewItem());
        StartCoroutine(LevelUpEffects());

        level++;
        text.text = "LV " + level.ToString();

        maxExpValue = 50 * level;
        expSlider.maxValue = maxExpValue;
    }

    IEnumerator GetNewItem()
    {
        Time.timeScale = 0f;
        ShowSelectWindow();

        while (true)
        {
            if (!isLevelUpTime) break;

            yield return null;
        }
        levelUpWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    void ShowSelectWindow()
    {
        levelUpWindow.SetActive(true);
        List<string> checkDuplicate = new List<string>(3);

        for (int i = 0; i < weaponSelect.Length; i++)
        {
            if (Random.Range(0, 10) < 4)
            {
                // ����
                WeaponData.WeaponType weapon;

                do weapon = GetRandomWeapon();
                while (checkDuplicate.Contains(weapon.ToString()));
                checkDuplicate.Add(weapon.ToString());

                weaponIcon[i].sprite = ItemAssets.GetInstance().GetWeaponData(weapon).GetSprite();
                nameText[i].text = weapon.ToString();
                int level;
                if (Inventory.GetWeaponInventory().TryGetValue(weapon, out level))
                {
                    description[i].text = ItemAssets.GetInstance().GetWeaponData(weapon).GetDescription();
                    levelText[i].text = "LV " + (level + 1).ToString();
                }
                else
                {
                    description[i].text = ItemAssets.GetInstance().GetWeaponData(weapon).GetDescription();
                    levelText[i].text = "New !";
                }

                button[i].onClick.RemoveAllListeners();
                button[i].onClick.AddListener(delegate { 
                    Inventory.GetInstance().AddWeapon(weapon); 
                    isLevelUpTime = false; 
                });
            }
            else
            {
                // �Ǽ�
                AccessoryData.AccessoryType accessory;
                
                do accessory = GetRandomAccessory();
                while(checkDuplicate.Contains(accessory.ToString()));
                checkDuplicate.Add(accessory.ToString());

                weaponIcon[i].sprite = ItemAssets.GetInstance().GetAccessoryData(accessory).GetSprite();
                nameText[i].text = accessory.ToString();
                description[i].text = ItemAssets.GetInstance().GetAccessoryData(accessory).GetDescription();
                int level;
                if (Inventory.GetAccInventory().TryGetValue(accessory, out level))
                    levelText[i].text = "LV " + (level+1).ToString();
                else
                    levelText[i].text = "New !";

                button[i].onClick.RemoveAllListeners();
                button[i].onClick.AddListener(delegate { 
                    Inventory.GetInstance().AddAccessory(accessory); 
                    isLevelUpTime = false; 
                });
            }
        }

        if(Random.Range(0,100) < Player.GetInstance().GetLuck())
            weaponSelect[3].SetActive(true);
        else
            weaponSelect[3].SetActive(false);
    }

    WeaponData.WeaponType GetRandomWeapon()
    {
        return (WeaponData.WeaponType)Random.Range(0, System.Enum.GetValues(typeof(WeaponData.WeaponType)).Length);
    }

    AccessoryData.AccessoryType GetRandomAccessory()
    {
        return (AccessoryData.AccessoryType)Random.Range(0, System.Enum.GetValues(typeof(AccessoryData.AccessoryType)).Length);
    }

    public void AddWeapon(WeaponData.WeaponType weapon)
    {
        Inventory.GetInstance().AddWeapon(weapon);
    }

    public void AddA(WeaponData.WeaponType weapon)
    {
        Inventory.GetInstance().AddWeapon(weapon);
    }

    IEnumerator LevelUpEffects()
    {
        levelUpBar.gameObject.SetActive(true);
        StartParticles();

        foreach (ParticleSystem particle in particles)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }

        while (true)
        {
            if (!isLevelUpTime) break;

            for (float i = 0f; i < 1f; i += 0.1f)
            {
                levelUpBar.color = Color.Lerp(new Color(1f, 0f, 1f), new Color(0f, 1f, 1f), i);
                yield return new WaitForSecondsRealtime(0.01f);
            }

            for (float i = 0f; i < 1f; i += 0.1f)
            {
                levelUpBar.color = Color.Lerp(new Color(0f, 1f, 1f), new Color(1f, 0f, 1f), i);
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }

        levelUpBar.gameObject.SetActive(false);
        StopParticles();
    }

    void StartParticles()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.gameObject.SetActive(true);
            particle.Play();
        }
    }

    void StopParticles()
    {
        foreach (ParticleSystem particle in particles)
        {
            particle.Stop();
            particle.gameObject.SetActive(false);
        }
    }
}
