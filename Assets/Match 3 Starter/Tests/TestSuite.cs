using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    

   
    
    [UnityTest]
    public IEnumerator UIActive() 
    {
        EditorSceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1);
        var gameObject = GameObject.Find("GUIManagerCanvas");
       
        Assert.IsTrue(gameObject.activeSelf);
    }
    [UnityTest]
    public IEnumerator Score() 
    {
       
        EditorSceneManager.LoadScene("Menu");
        EditorSceneManager.LoadScene("Game");
        yield return new WaitForSeconds(2);
        GameObject manager = GameObject.Find("GUIManagerCanvas");
        GUIManager script = manager.GetComponent<GUIManager>();     
        
        Assert.AreEqual(0,script.Score);
    }
    [UnityTest]
    public IEnumerator JugadorNoPerdioAlInicio()
    {
        EditorSceneManager.LoadScene("Game");
        yield return new WaitForSeconds(1);
        GameObject manager = GameObject.Find("GameManager");

        GameManager script = manager.GetComponent<GameManager>();
        
        Assert.IsFalse(script.gameOver);
    }
}
