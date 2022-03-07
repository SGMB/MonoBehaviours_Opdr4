using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteRenderer
{
	private Texture2D _texture;
	private Color _color = Color.White;

	public Texture2D Texture
	{
		get { return _texture; }
		set { _texture = value; }
	}

	public Color Color
	{
		get { return _color; }
		set { _color = value; }
	}


	public void DrawSprite(SpriteBatch spriteB, Transform transform)
	{
		spriteB.Draw(Texture, transform.Position, null, Color, transform.Rotation, transform.Origin, transform.Scale, SpriteEffects.None, 1);
	}
}
