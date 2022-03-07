using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using System;

public class GameObject
{
	public Transform transform;
	private SpriteRenderer renderer;

	public GameObject(Transform trans, SpriteRenderer rend)
    {
		transform = trans;
		renderer = rend;
    }

	public virtual void Draw(SpriteBatch spriteB)
    {
		if(transform.Active && renderer != null)
			renderer.DrawSprite(spriteB, transform);
	}

	public virtual void Update(GameTime gameTime)
    {

    }

	public void isActive(bool active)
    {
		transform.Active = active;
    }
}
