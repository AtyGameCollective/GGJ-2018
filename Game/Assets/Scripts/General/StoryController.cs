using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    int currPage = 0;
    [SerializeField] CanvasGroup panelAlpha;
    [SerializeField] CanvasGroup menuAlpha;
    [SerializeField] CanvasGroup[] pagesAlpha;
    int onTransitionCount;
    [SerializeField]
    float [] totalTransitionWaitTime = { 5f, 5f, 5f, 8f };
    float transitionWaitTime;

    [SerializeField]
    UnityEvent onComplete;

    // Use this for initialization
    void OnEnable()
    {
        panelAlpha.alpha = 0;
        menuAlpha.alpha = 0;
        for (int i = 0; i < pagesAlpha.Length; i++)
        {
            if (pagesAlpha[i].alpha > 0)
                pagesAlpha[i].alpha = 0;
        }
        StartCoroutine(ShowIntro());
    }

    IEnumerator ShowIntro()
    {
        yield return StartCoroutine(ChangeAlpha(panelAlpha, 1, .4f));
        yield return StartCoroutine(ChangeAlpha(menuAlpha, 1, 1f));
        SetPage(0);

        StartCoroutine(TransitionPages());
    }

    IEnumerator TransitionPages()
    {
        while(gameObject.activeSelf && currPage < pagesAlpha.Length)
        {
            if(transitionWaitTime > 0)
            {
                transitionWaitTime -= Time.deltaTime;
                yield return null;
            }
            else
            {
                NextPage();
            }
        }
    }

    void SetPage(int newPage)
    {
        if (onTransitionCount > 0 || newPage < 0)
        {
            return;
        }
        else if (newPage < pagesAlpha.Length)
        {
            for (int i = 0; i < pagesAlpha.Length; i++)
            {
                if (pagesAlpha[i].alpha > 0)
                    StartCoroutine(ChangeAlpha(pagesAlpha[i], 0, 0.7f));
            }
            StartCoroutine(ChangeAlpha(pagesAlpha[newPage], 1, 1f, 0.5f));
        }
        else
        {
            if (onComplete != null)
                onComplete.Invoke();

        }
        currPage = newPage;
        if(currPage < totalTransitionWaitTime.Length)
            transitionWaitTime = totalTransitionWaitTime[currPage];
    }

    public void NextPage()
    {
        SetPage(currPage + 1);
    }

    IEnumerator ChangeAlpha(CanvasGroup group, float finalAlpha, float totalTime, float waitTime = 0f)
    {
        float startAlpha = group.alpha;
        onTransitionCount++;
        if(waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
        }
        if (totalTime > 0)
        {
            float currTime = 0;
            while (currTime <= totalTime)
            {
                group.alpha = Mathf.Lerp(startAlpha, finalAlpha, currTime / totalTime);
                currTime += Time.deltaTime;
                yield return null;
            }
        }
        group.alpha = finalAlpha;
        onTransitionCount--;
    }

}
