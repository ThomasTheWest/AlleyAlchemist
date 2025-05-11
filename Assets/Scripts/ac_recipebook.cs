using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ac_recipebook : MonoBehaviour
{
    [Header("Animation")]
    public float animDuration = 2;
    [SerializeField] private int leafIndex = 1; //sorry I start counting the leaves on 1 and not 0....
    private int leafIndexMax;
    private bool isTurning = false;

    [Header("Mats and Textures")]
    [SerializeField] private Material pageLeft;
    private int pageLeftIndex = 0;
    [SerializeField] private Material pageRight;
    private int pageRightIndex = 1;

    [SerializeField] private Material pageNextFront;
    private int pageNextFrontIndex = 1;
    [SerializeField] private Material pageNextBack;
    private int pageNextBackIndex = 2;

    [SerializeField] private Material pagePrevFront;
    private int pagePrevFrontIndex = 2;
    [SerializeField] private Material pagePrevBack;
    private int pagePrevBackIndex = 1;

    //never add an odd number of pages in the editor...or else...
    [SerializeField] private Texture[] pageTextures;

    [Header("Game Object")]
    [SerializeField] private GameObject pageNext;
    [SerializeField] private GameObject pagePrev;

    void Start()
    {
        leafIndexMax = pageTextures.Length / 2;
        //Debug.Log("Number of leaves in this book is " + leafIndexMax);
    }

    private IEnumerator PageSequence()
    {
        yield return StartCoroutine(TurnPageForward());
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(TurnPageBackward());
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(TurnPageForward());
        yield return StartCoroutine(TurnPageForward());
        yield return StartCoroutine(TurnPageForward());
    }

    void Update()
    {
        pageLeft.mainTexture = pageTextures[pageLeftIndex];
        pageRight.mainTexture = pageTextures[pageRightIndex];

        pageNextFront.mainTexture = pageTextures[pageNextFrontIndex];
        pageNextBack.mainTexture = pageTextures[pageNextBackIndex];

        pagePrevFront.mainTexture = pageTextures[pagePrevFrontIndex];
        pagePrevBack.mainTexture = pageTextures[pagePrevBackIndex];

        //Debug.Log("Current leaf: " + leafIndex);
    }
    private IEnumerator TurnPageForward()
    {
        if (leafIndex == leafIndexMax) yield break;

        leafIndex++;
        isTurning = true;
        pageNext.SetActive(true);
        pageRightIndex += 2;

        Vector3 rotationAngleForward = new Vector3(0f, 0f, -180.0f);
        Quaternion startRotationForward = pageNext.transform.rotation;
        Quaternion endRotation = startRotationForward * Quaternion.Euler(rotationAngleForward);
        float elapsed = 0f;

        while (elapsed < animDuration)
        {
            pageNext.transform.rotation = Quaternion.Slerp(startRotationForward, endRotation, elapsed / animDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (elapsed > animDuration)
        {
            pageNext.SetActive(false);
        }

        pageNext.transform.rotation = endRotation;


        if (leafIndex == leafIndexMax)
        {
            pageLeftIndex += 2;

            if (leafIndex > 2)
            {
                pagePrevFrontIndex += 2;
                pagePrevBackIndex += 2;
            }

            pageNext.transform.rotation = startRotationForward;
        }
        else
        {
            pageLeftIndex += 2;

            pageNextFrontIndex += 2;
            pageNextBackIndex += 2;

            if (leafIndex > 2)
            {
                pagePrevFrontIndex += 2;
                pagePrevBackIndex += 2;
            }

            pageNext.transform.rotation = startRotationForward;
        }

        isTurning = false;
    }

    private IEnumerator TurnPageBackward()
    {
        if (leafIndex == 1) yield break;

        leafIndex -= 1;
        isTurning = true;
        pagePrev.SetActive(true);
        pageLeftIndex -= 2;

        Vector3 rotationAngleBack = new Vector3(0f, 0f, 180.0f);
        Quaternion startRotationBack = pagePrev.transform.rotation;
        Quaternion endRotation = startRotationBack * Quaternion.Euler(rotationAngleBack);
        float elapsed = 0f;

        while (elapsed < animDuration)
        {
            pagePrev.transform.rotation = Quaternion.Slerp(startRotationBack, endRotation, elapsed / animDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (elapsed > animDuration)
        {
            pagePrev.SetActive(false);
        }

        pagePrev.transform.rotation = endRotation;

        if (leafIndex > 2)
        {
            pageRightIndex -= 2;

            pagePrevBackIndex -= 2;
            pagePrevFrontIndex += 2;

            pageNextFrontIndex -= 2;
            pageNextBackIndex -= 1;

            pagePrev.transform.rotation = startRotationBack;
        }
        else
        {
            pageRightIndex -= 2;

            pageNextFrontIndex -= 2;
            pageNextBackIndex -= 1;

            pagePrev.transform.rotation = startRotationBack;
        }

        isTurning = false;
    }

    public void StartPageForward()
    {
        if (leafIndex < leafIndexMax && !isTurning)
        {
            StartCoroutine(TurnPageForward());
            //Debug.Log("Turning forward...");
        }
        else
        {
            return;
        }
    }

    public void StartPageBackward()
    {
        if (leafIndex > 1 && !isTurning)
        {
            StartCoroutine(TurnPageBackward());
            //Debug.Log("Turning backward...");
        }
        else
        {
            return;
        }
    }
}