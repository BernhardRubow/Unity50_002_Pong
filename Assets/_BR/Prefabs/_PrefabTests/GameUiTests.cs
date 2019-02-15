using System.Collections;
using System.Collections.Generic;
using nvp.events;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class GameUiTests : MonoBehaviour
{
    [UnityTest]
    public IEnumerator GameUI_WhenReceivesOnLeftPlayerScores_IncreaseScoreForLeftPlayer()
    {
        var uiAsset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_BR/Prefabs/UI/UI_Game.prefab");
        var ui = GameObject.Instantiate(uiAsset);

        yield return null;

        var eventController = new NvpEventController();

        var script = ui.GetComponent<UI_CTL_Game>();
        script.Construct(eventController);

        eventController.InvokeEvent(NvpGameEvents.OnLeftPlayerScores, this, null);
        
        Assert.AreEqual(1, script.leftPlayerScore);

        yield return new WaitForSeconds(1f);

        GameObject.Destroy(ui);
    }

    [UnityTest]
    public IEnumerator GameUI_WhenReceivesOnRightPlayerScores_IncreaseScoreForRightPlayer()
    {
        var uiAsset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_BR/Prefabs/UI/UI_Game.prefab");
        var ui = GameObject.Instantiate(uiAsset);

        yield return null;

        var eventController = new NvpEventController();

        var script = ui.GetComponent<UI_CTL_Game>();
        script.Construct(eventController);

        eventController.InvokeEvent(NvpGameEvents.OnRightPlayerScores, this, null);

        Assert.AreEqual(1, script.rightPlayerScore);

        yield return new WaitForSeconds(1f);

        GameObject.Destroy(ui);
    }
}
