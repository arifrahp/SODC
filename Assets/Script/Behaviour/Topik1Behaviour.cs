using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Topik1Behaviour : MonoBehaviour
{
    [SerializeField] GameObject finishedContent;
    [SerializeField] GameObject mainMenuButton;

    [SerializeField] GameObject objectZone;
    [SerializeField] GameObject objectOPM;
    [SerializeField] GameObject objectPowerMeter;
    [SerializeField] GameObject objectPatchCord;
    [SerializeField] GameObject objectOLS;
    [SerializeField] GameObject objectCanvas;

    public bool objectIsShow = false;

    private void Start()
    {
        mainMenuButton.SetActive(true);
        finishedContent.SetActive(false);

        LeanTween.scale(objectZone.gameObject, new Vector3(0f, 0f, 0f), 0f);

        objectCanvas.SetActive(false);

        tittleLayout.gameObject.SetActive(true);
        showTittleButton.gameObject.SetActive(true);
        pengertianSatuanDesibelGroup.gameObject.SetActive(true);
        pengukuranAbsolutGroup.gameObject.SetActive(true);
        pengukuranDalamSatuanDecibelGroup.gameObject.SetActive(true);

        pengertianSatuanDesibelContext.gameObject.SetActive(true);
        pengukuranAbsolutContext.gameObject.SetActive(true);
        pengukuranDalamSatuanDecibelContext.gameObject.SetActive(true);

        LeanTween.scale(pengertianPengukuranContent.gameObject, new Vector3(0f, 0f, 0f), 0f);

        LeanTween.move(pengertianPengukuranContent, new Vector2(849.5f, -386.5f), 0f);

        LeanTween.move(tittleLayout, new Vector2(2062.298f, -311.4261f), 0f);
        LeanTween.move(showTittleButton, new Vector2(2062.298f, -431.4261f), 0f);

        LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(pengukuranAbsolutGroup, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(0f, 0f, 0f), 0f);

        LeanTween.scale(pengertianSatuanDesibelContext, new Vector3(0f, 0f, 0f), 0f);
        LeanTween.scale(pengukuranAbsolutContext, new Vector3(0f, 0f, 0f), 0f);  
        LeanTween.scale(pengukuranDalamSatuanDecibelContext, new Vector3(0f, 0f, 0f), 0f);

        LeanTween.move(pengertianSatuanDesibelGroup, new Vector2(2064f, -371.4261f), 0f);
        LeanTween.move(pengukuranAbsolutGroup, new Vector2(2064f, -371.4261f), 0f);
        LeanTween.move(pengukuranDalamSatuanDecibelGroup, new Vector2(2064f, -371.4261f), 0f);

        LeanTween.move(pengertianSatuanDesibelContext, new Vector2(1601.6f, -371.4261f), 0f);
        LeanTween.move(pengukuranAbsolutContext, new Vector2(1601.6f, -371.4261f), 0f);
        LeanTween.move(pengukuranDalamSatuanDecibelContext, new Vector2(1601.6f, -371.4261f), 0f);
        
    }

    public void SpawnObjectZone()
    {
        objectCanvas.SetActive(true);
        LeanTween.scale(objectZone.gameObject, new Vector3(1f, 1f, 1f), 0.5f);

        LeanTween.moveLocal(objectOPM.gameObject, new Vector3(-0.945f, 0.2400001f, 2.129f), 0.5f);
        LeanTween.moveLocal(objectPowerMeter.gameObject, new Vector3(0.2470012f, 0.1893f, 0.6239991f), 0.5f);
        LeanTween.moveLocal(objectPatchCord.gameObject, new Vector3(0.42f, 0.2369999f, -1.514f), 0.5f);
        LeanTween.moveLocal(objectOLS.gameObject, new Vector3(-0.79f, 0.195f, -2.747f), 0.5f);
        
        LeanTween.rotateLocal(objectOPM.gameObject, new Vector3(0f, -117.665f, 0f), 0.5f);
        LeanTween.rotateLocal(objectPowerMeter.gameObject, new Vector3(0f, -90f, 0f), 0.5f);
        LeanTween.rotateLocal(objectPatchCord.gameObject, new Vector3(0f, -90f, 0f), 0.5f);
        LeanTween.rotateLocal(objectOLS.gameObject, new Vector3(0f, -59.381f, 0f), 0.5f);

        objectIsShow = true;
    }
    
    public void RemoveObjectZone()
    {
        objectCanvas.SetActive(false);
        LeanTween.scale(objectZone.gameObject, new Vector3(0f, 0f, 0f), 0.5f);

        objectIsShow = false;
    }

    [SerializeField] RectTransform tittleLayout;
    [SerializeField] RectTransform pengertianSatuanDesibelGroup;
    [SerializeField] RectTransform pengukuranAbsolutGroup;
    [SerializeField] RectTransform pengukuranDalamSatuanDecibelGroup;
    [SerializeField] RectTransform showTittleButton;

    [SerializeField] RectTransform pengertianSatuanDesibelButton;
    [SerializeField] RectTransform pengukuranAbsolutButton;
    [SerializeField] RectTransform pengukuranDalamSatuanDecibelButton;
    
    [SerializeField] RectTransform pengertianSatuanDesibelContext;
    [SerializeField] RectTransform pengukuranAbsolutContext;
    [SerializeField] RectTransform pengukuranDalamSatuanDecibelContext;

    public bool tittleIsShow = false;
    public bool pengertianSatuanDesibelContextIsShow = false;
    public bool pengukuranAbsolutContextIsShow = false;
    public bool pengukuranDalamSatuanDecibelContextIsShow = false;

    public void ShowTittleButtonPressed()
    {
        if(!tittleIsShow)
        {
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(1f, 1f, 1f), 0.5f);

            LeanTween.move(tittleLayout, new Vector2(2062.298f, -131.4261f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelGroup, new Vector2(2064f, -251.4261f), 0.5f);
            LeanTween.move(pengukuranAbsolutGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelGroup, new Vector2(2064f, -491.4261f), 0.5f);
            LeanTween.move(showTittleButton, new Vector2(2062.298f, -611.426f), 0.5f);

            LeanTween.rotateLocal(showTittleButton.gameObject, new Vector3(0f, 0f, 90f), 0.5f);

            tittleIsShow = true;
        }
        else if(tittleIsShow)
        {
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(0f, 0f, 0f), 0.5f);

            LeanTween.move(tittleLayout, new Vector2(2062.298f, -311.4261f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranAbsolutGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(showTittleButton, new Vector2(2062.298f, -431.4261f), 0.5f);

            LeanTween.rotateLocal(showTittleButton.gameObject, new Vector3(0f, 0f, -90f), 0.5f);

            tittleIsShow = false;
        }
    }

    public void PengertianSatuanDesibelButtonPressed()
    {
        if (!pengertianSatuanDesibelContextIsShow)
        {
            pengertianSatuanDesibelDone = true;

            LeanTween.scale(tittleLayout, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelContext, new Vector3(1f, 1f, 1f), 0.5f);

            LeanTween.move(pengertianSatuanDesibelGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelButton, new Vector2(-1920f, 0f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelContext, new Vector2(904.65f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengertianSatuanDesibelButton.gameObject, new Vector3(0f, 0f, -90f), 0.5f);

            pengertianSatuanDesibelContextIsShow = true;
        }
        
        else if (pengertianSatuanDesibelContextIsShow)
        {
            LeanTween.scale(tittleLayout, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelContext, new Vector3(0f, 0f, 0f), 0.5f);

            LeanTween.move(pengertianSatuanDesibelGroup, new Vector2(2064f, -251.4261f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelButton, new Vector2(-374f, 0f), 0.5f);
            LeanTween.move(pengertianSatuanDesibelContext, new Vector2(1601.6f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengertianSatuanDesibelButton.gameObject, new Vector3(0f, 0f, 90f), 0.5f);

            pengertianSatuanDesibelContextIsShow = false;
        }
    }
    
    public void PengukuranAbsolutButtonPressed()
    {
        if (!pengukuranAbsolutContextIsShow)
        {
            pengukuranYangAbsolutDone = true;

            LeanTween.scale(tittleLayout, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranAbsolutContext, new Vector3(1f, 1f, 1f), 0.5f);

            LeanTween.move(pengukuranAbsolutGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranAbsolutButton, new Vector2(-1920f, 0f), 0.5f);
            LeanTween.move(pengukuranAbsolutContext, new Vector2(904.65f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengukuranAbsolutButton.gameObject, new Vector3(0f, 0f, -90f), 0.5f);

            pengukuranAbsolutContextIsShow = true;
        }
        
        else if (pengukuranAbsolutContextIsShow)
        {
            LeanTween.scale(tittleLayout, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranAbsolutContext, new Vector3(0f, 0f, 0f), 0.5f);

            LeanTween.move(pengukuranAbsolutGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranAbsolutButton, new Vector2(-374f, 0f), 0.5f);
            LeanTween.move(pengukuranAbsolutContext, new Vector2(1601.6f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengukuranAbsolutButton.gameObject, new Vector3(0f, 0f, 90f), 0.5f);

            pengukuranAbsolutContextIsShow = false;
        }
    }
    
    public void PengukuranDalamSatuanDecibelButtonPressed()
    {
        if (!pengukuranDalamSatuanDecibelContextIsShow)
        {
            LeanTween.scale(tittleLayout, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelContext, new Vector3(1f, 1f, 1f), 0.5f);

            LeanTween.move(pengukuranDalamSatuanDecibelGroup, new Vector2(2064f, -371.4261f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelButton, new Vector2(-1920f, 0f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelContext, new Vector2(904.65f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengukuranDalamSatuanDecibelButton.gameObject, new Vector3(0f, 0f, -90f), 0.5f);

            pengukuranDalamSatuanDecibelContextIsShow = true;
        }
        
        else if (pengukuranDalamSatuanDecibelContextIsShow)
        {
            LeanTween.scale(tittleLayout, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(showTittleButton, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengertianSatuanDesibelGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranAbsolutGroup, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.scale(pengukuranDalamSatuanDecibelContext, new Vector3(0f, 0f, 0f), 0.5f);

            LeanTween.move(pengukuranDalamSatuanDecibelGroup, new Vector2(2064f, -491.4261f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelButton, new Vector2(-374f, 0f), 0.5f);
            LeanTween.move(pengukuranDalamSatuanDecibelContext, new Vector2(1601.6f, -371.4261f), 0.5f);

            LeanTween.rotateLocal(pengukuranDalamSatuanDecibelButton.gameObject, new Vector3(0f, 0f, 90f), 0.5f);

            pengukuranDalamSatuanDecibelContextIsShow = false;
        }
    }

    [SerializeField] RectTransform pengertianPengukuranContent;
    [SerializeField] RectTransform pengertianPengukuranButton;
    [SerializeField] RectTransform showAlatAlatButton;

    public bool pengertianPengukuranIsShow = false;

    public void PengertianPengukuranButtonPressed()
    {
        if (!pengertianPengukuranIsShow)
        {
            LeanTween.scale(pengertianPengukuranContent.gameObject, new Vector3(1f, 1f, 1f), 0.5f);
            LeanTween.move(pengertianPengukuranContent, new Vector2(1651.05f, -386.5f), 0.5f);
            LeanTween.rotateLocal(pengertianPengukuranButton.gameObject, new Vector3(0f, 0f, 180f), 0.5f);

            pengertianPengukuranIsShow = true;
        }
        else if(pengertianPengukuranIsShow)
        {
            LeanTween.scale(pengertianPengukuranContent.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
            LeanTween.move(pengertianPengukuranContent, new Vector2(849.5f, -386.5f), 0.5f);
            LeanTween.rotateLocal(pengertianPengukuranButton.gameObject, new Vector3(0f, 0f, 0f), 0.5f);

            pengertianPengukuranIsShow = false;

            if (objectIsShow)
            {
                RemoveObjectZone();

                LeanTween.rotateLocal(showAlatAlatButton.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
            }
        }
    }

    public void ShowAlatButtonPressed()
    {
        if (!objectIsShow)
        {
            SpawnObjectZone();

            LeanTween.rotateLocal(showAlatAlatButton.gameObject, new Vector3(0f, 0f, 180f), 0.5f);


        }
        
        else if (objectIsShow)
        {
            RemoveObjectZone();

            LeanTween.rotateLocal(showAlatAlatButton.gameObject, new Vector3(0f, 0f, 0f), 0.5f);
        }
    }

    public bool pengertianSatuanDesibelDone = false;
    public bool pengukuranYangAbsolutDone = false;
    public bool pengukuranDalamSatuanDecibelDone = false;
    
    public bool opmGrabDone = false;
    public bool powerMeterGrabDone = false;
    public bool patchCordGrabDone = false;
    public bool olsGrabDone = false;

    public bool olsButton1Done = false;
    public bool olsButton2Done = false;
    public bool olsButton3Done = false;

    public bool patchCord1Done = false;
    public bool patchCord2Done = false;

    public bool opmButton1Done = false;
    public bool opmButton2Done = false;
    public bool opmButton3Done = false;
    public bool opmButton4Done = false;
    public bool opmButton5Done = false;

    private void Update()
    {
        if(pengertianSatuanDesibelDone
            && pengukuranYangAbsolutDone
            && pengukuranDalamSatuanDecibelDone
            && opmGrabDone
            && opmButton1Done
            && opmButton2Done
            && opmButton3Done
            && opmButton4Done
            && opmButton5Done
            && powerMeterGrabDone
            && olsGrabDone
            && olsButton1Done
            && olsButton2Done
            && olsButton3Done
            && patchCordGrabDone
            && patchCord1Done
            &&patchCord2Done)
        {
            MenuHandler.menuInstance.topik1Done = true;
        }

        if (MenuHandler.menuInstance.topik1Done)
        {
            mainMenuButton.SetActive(false);

            finishedContent.SetActive(true);
        }
    }

    public void PengukuranDalamSatuanDecibelDone()
    {
        pengukuranDalamSatuanDecibelDone = true;
    }

    public void PatchCordDone()
    {
        patchCordGrabDone = true;
    }

    public void PowerMeterDone()
    {
        powerMeterGrabDone = true;
    }

    public void OPMDone()
    {
        opmGrabDone = true;
    }

    public void OPM1Done()
    {
        opmButton1Done = true;
    }

    public void OPM2Done()
    {
        opmButton2Done = true;
    }

    public void OPM3Done()
    {
        opmButton3Done = true;
    }

    public void OPM4Done()
    {
        opmButton4Done = true;
    }

    public void OPM5Done()
    {
        opmButton5Done = true;
    }

    public void PatchCord1Done()
    {
        patchCord1Done = true;
    }
    
    public void PatchCord2Done()
    {
        patchCord2Done = true;
    }
    
    public void OLSDone()
    {
        olsGrabDone = true;
    }

    public void OLS1Done()
    {
        olsButton1Done = true;
    }
    
    public void OLS2Done()
    {
        olsButton2Done = true;
    }
    
    public void OLS3Done()
    {
        olsButton3Done = true;
    }
}
