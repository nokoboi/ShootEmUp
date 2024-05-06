using NUnit.Framework;
using Shmup;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace TestSpace
{
    public class PlayTest : MonoBehaviour
    {
        

        [SetUp]
        public void SetUp()
        {
            EditorSceneManager.LoadScene("Level1");
        }
        // A Test behaves as an ordinary method
        //[Test]
        //public void PlayTestSimplePasses()
        //{

        //    // Use the Assert class to test conditions

        //}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerExists()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.5f);
            Assert.That(GameObject.Find("Player").activeSelf);
        }

        [UnityTest]
        
        public IEnumerator BulletTest()
        {
            yield return new WaitForSeconds(2f);
            Assert.That(GameObject.Find("Player").GetComponent<PlayerController>().ShootingTest());
        }

        [TearDown]
        public void TearDown()
        {
            EditorSceneManager.UnloadSceneAsync(EditorSceneManager.GetActiveScene());
        }
    }
}
