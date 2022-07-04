using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System;
using System.Collections.Generic;

public class GameObject
{
	private Transform transform;
	private List<MonoBehaviour> _components = new List<MonoBehaviour>();
	private MonoBehaviour monoBehaviour = new MonoBehaviour();

	public GameObject() { }

	public GameObject(Transform trans, params MonoBehaviour[] comp)
    {
		transform = trans;
		components.AddRange(comp);
		monoBehaviour = new MonoBehaviour(this);
    }

	public List<MonoBehaviour> components
	{
		get { return _components; }
	}

	public Transform Transform
	{
		get { return transform; }
		set { transform = value; }
	}

	public virtual void Update(GameTime gameTime)
    {
		monoBehaviour.UpdateMono(gameTime, this);
    }

	public void Draw(SpriteBatch spriteB)
    {
		monoBehaviour.DrawMono(spriteB, this);
	}
	
	public void isActive(bool active)
	{
		transform.Active = active;
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
