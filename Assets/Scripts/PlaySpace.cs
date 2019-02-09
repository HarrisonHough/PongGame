using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Play Space Class 
*/


/// <summary>
/// This class dynamically positions and resizes the 
/// boundary colliders in world space by converting 
/// screen coordinates to world coordinates
/// </summary>
public class PlaySpace : MonoBehaviour
{

    //reference to all 4 wall colliders
    [SerializeField]
    private BoxCollider2D topWall;
    [SerializeField]
    private BoxCollider2D bottomWall;
    [SerializeField]
    private BoxCollider2D leftWall;
    [SerializeField]
    private BoxCollider2D rightWall;

    //used to determine width of walls, can be changed in editor
    [SerializeField]
    private float wallWidth = 1f;

    [SerializeField]
    private bool adjustSprite = false;
    public static float xMin;
    public static float xMax;
    public static float yMin;
    public static float yMax;

    /// <summary>
    /// Used for initialization on scene start
    /// </summary>
    private void Start()
    {

        SetupPlaySpace();

    }

    /// <summary>
    /// 
    /// </summary>
    public void SetupPlaySpace()
    {
        GetWorldPositionValues();
        SetupTopWall();
        SetupBottomWall();
        SetupLeftWall();
        SetupRightWall();
    }

    /// <summary>
    /// Sets up the top wall colliders size and position
    /// </summary>
    private void SetupTopWall()
    {

        Vector2 size = new Vector2(xMax - xMin, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, wallWidth / 2);

        topWall.size = size;
        topWall.offset = offset;
        topWall.transform.position = new Vector3(xMin - 1, yMax, 0f);
    }

    /// <summary>
    /// Sets up the bottom wall colliders size and position
    /// </summary>
    private void SetupBottomWall()
    {

        Vector2 size = new Vector2(xMax - xMin, wallWidth);
        size.x += 2;
        Vector2 offset = new Vector3(size.x / 2f, -wallWidth / 2);

        //Bottom wall position logic
        bottomWall.size = size;
        bottomWall.offset = offset;
        bottomWall.transform.position = new Vector3(xMin - 1, yMin, 0f);

    }

    /// <summary>
    /// Sets up the left wall colliders size and position
    /// </summary>
    private void SetupLeftWall()
    {
        Vector2 size = new Vector2(wallWidth, yMax - yMin);
        Vector2 offset = new Vector3(-wallWidth / 2, size.y / 2);

        leftWall.size = size;
        leftWall.offset = offset;
        leftWall.transform.position = new Vector3(xMin, yMin);
    }

    /// <summary>
    /// Sets up the right wall colliders size and position
    /// </summary>
    private void SetupRightWall()
    {
        Vector2 size = new Vector2(wallWidth, yMax - yMin);
        Vector2 offset = new Vector3(wallWidth / 2, size.y / 2);

        rightWall.size = size;
        rightWall.offset = offset;
        rightWall.transform.position = new Vector3(xMax, yMin);

    }

    /// <summary>
    /// Converts the viewport boundary coordinates to world 
    /// coordinates
    /// </summary>
    private void GetWorldPositionValues()
    {
        xMin = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
        xMax = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        yMin = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
        yMax = Camera.main.ViewportToWorldPoint(Vector3.up).y;
    }

}
