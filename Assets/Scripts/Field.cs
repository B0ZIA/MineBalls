using UnityEngine;

public class Field
{
    public readonly Vector2 position;

    private GameObject gameObject;
    public GameObject GameObject
    {
        get { return gameObject; }
        set
        {
            gameObject = value;
            if (HaveGameObject())
            {
                gameObject.transform.position = position;
            }
        }
    }

    public bool HaveGameObject()
    {
        if (gameObject == null)
            return false;
        else
            return true;
    }

    public Field(int x, int y)
    {
        position = new Vector2(x, y);
    }

    public Field(int x, int y, GameObject gameObject)
    {
        position = new Vector2(x, y);
        GameObject = gameObject;
    }
}