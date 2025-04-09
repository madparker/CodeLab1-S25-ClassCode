using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Make a NYUGradStudent and NYUUnGradStudent
        //each with a unique value that makes sense
        //for that class
        //Also, override GetRecord in those classes
        //to display that new data
        
        
        NYUPerson mattParker = new NYUStaff();
        mattParker.name = "Matt Parker";
        mattParker.nNumber = 38743783478;
        mattParker.netId = "mp612";
        mattParker.age = 42;

        Debug.Log(mattParker.GetRecord());

        NYUStudent rio = new NYUStudent();
        rio.name = "Rio";
        rio.nNumber = 323443342;
        rio.netId = "rr1322";
        rio.age = 45;
        rio.gradYear = 2026;

        Debug.Log(rio.GetRecord());

        NYUPerson Frank = new NYUPerson(
            "f42",
            "Frank Lantz",
            23423432,
            62
            );

        Debug.Log(Frank.GetRecord());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
