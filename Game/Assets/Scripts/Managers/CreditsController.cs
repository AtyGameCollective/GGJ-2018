using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {
    private int onTransitionCount;
    [SerializeField] CanvasGroup panelAlpha;
    [SerializeField] CanvasGroup menuAlpha;
    [SerializeField] CanvasGroup contentAlpha;
    [SerializeField] Animator scrollAnimator;
    // Use this for initialization
    void OnEnable () {
        Open();
    }

    void Open()
    {
        panelAlpha.alpha = 0;
        menuAlpha.alpha = 0;
        contentAlpha.alpha = 0;
        StartCoroutine(OpenAnimation());
    }

    IEnumerator OpenAnimation()
    {
        StartCoroutine(ChangeAlpha(panelAlpha, 1, .1f));
        yield return StartCoroutine(ChangeAlpha(menuAlpha, 1, .4f));
        scrollAnimator.SetTrigger("Open");
        yield return StartCoroutine(ChangeAlpha(contentAlpha, 1, 1f, .5f));
    }

    public void Close()
    {
        StartCoroutine(CloseAnimation());
    }

    IEnumerator CloseAnimation()
    {
        yield return StartCoroutine(ChangeAlpha(contentAlpha, 0, .5f));
        scrollAnimator.SetTrigger("Close");
        StartCoroutine(ChangeAlpha(panelAlpha, 0, .8f, .4f));
        yield return StartCoroutine(ChangeAlpha(menuAlpha, 0, .5f, .8f));
        gameObject.SetActive(false);
    }



    IEnumerator ChangeAlpha(CanvasGroup group, float finalAlpha, float totalTime, float waitTime = 0f)
    {
        float startAlpha = group.alpha;
        onTransitionCount++;
        if (waitTime > 0)
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
