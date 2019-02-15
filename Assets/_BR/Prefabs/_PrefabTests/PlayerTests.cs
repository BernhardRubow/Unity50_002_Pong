using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        [UnityTest]
        public IEnumerator Player_WhenAlwaysMovedUp_ShouldNeverGetOutOfBounds()
        {
            var worldAsset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_BR/Prefabs/Game/World.prefab");
            var playerAsset = AssetDatabase.LoadAssetAtPath <GameObject>("Assets/_BR/Prefabs/Game/Player.prefab");
            float timer = 0f;

            var world = GameObject.Instantiate(worldAsset);
            var player = GameObject.Instantiate(playerAsset, new Vector3(-40f, 0f, 0f), Quaternion.identity);
            player.GetComponent<NvpPlayerCTL>().playerModel = new NvpHumanPlayerModel();
            
            var rb = player.GetComponent<Rigidbody>();
            var leftPlayerController = player.GetComponent<NvpPlayerCTL>();
            var t = player.transform;

            while (timer < 5)
            {
                timer += Time.deltaTime;
                rb.AddForce(Vector3.up * leftPlayerController.force * 1, ForceMode.Force);
                yield return null;
            }

            Assert.Less(Mathf.Abs(t.position.y), 24f, "Player should not get out of bounds");
            GameObject.Destroy(world);
            GameObject.Destroy(player);
        }


        [UnityTest]
        public IEnumerator Player_WhenAlwaysMovedDown_ShouldNeverGetOutOfBounds()
        {
            var worldAsset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_BR/Prefabs/Game/World.prefab");
            var playerAsset = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_BR/Prefabs/Game/Player.prefab");
            float timer = 0f;

            var world = GameObject.Instantiate(worldAsset);
            var player = GameObject.Instantiate(playerAsset, new Vector3(-40f, 0f, 0f), Quaternion.identity);
            player.GetComponent<NvpPlayerCTL>().playerModel = new NvpHumanPlayerModel();

            var rb = player.GetComponent<Rigidbody>();
            var leftPlayerController = player.GetComponent<NvpPlayerCTL>();
            var t = player.transform;

            while (timer < 5)
            {
                timer += Time.deltaTime;
                rb.AddForce(Vector3.up * leftPlayerController.force * -1, ForceMode.Force);
                yield return null;
            }

            Assert.Less(Mathf.Abs(t.position.y), 24f, "Player should not get out of bounds");
            GameObject.Destroy(world);
            GameObject.Destroy(player);

        }
    }
}



