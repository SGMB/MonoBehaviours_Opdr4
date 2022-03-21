using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class MonoBehaviour
{
	protected GameObject _gameObject; //returned null :(
    protected List<MonoBehaviour> _components = new List<MonoBehaviour>();
    public MonoBehaviour() 
    {
        
    }
	public MonoBehaviour(GameObject gameObject)
	{
        //comment: Hier binnen werkt alleen de _gameObject. buiten dit script en ook in scripts die inheriten returned null.
        _gameObject = gameObject;
        _components = gameObject.components;
	}
    

    public virtual void Awake()
    {

    }

    public virtual void Start()
    {

    }

	public virtual void UpdateMono(GameTime gameTime, GameObject gamer)
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].UpdateMono(gameTime, gamer);
        }
    }

	public virtual void DrawMono(SpriteBatch spriteBatch, GameObject gamer)
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].DrawMono(spriteBatch, gamer);
        }
    }

    public T GetComponent<T>() where T : MonoBehaviour
    {
        for (int i = 0; i < _components.Count; i++)
        {
            MonoBehaviour currentBehaviour = _components[i];
            if (currentBehaviour is T) return currentBehaviour as T;
        }
        return null;
    }

}
