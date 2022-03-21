using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SpriteRenderer : MonoBehaviour
{
	protected float shit;
	private Texture2D _texture;
	private Color _color = Color.White;
	public SpriteRenderer() { }
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

	public override void DrawMono(SpriteBatch spriteBatch, GameObject gamer)
    {
		spriteBatch.Draw(Texture, gamer.Transform.Position, null, Color, gamer.Transform.Rotation, gamer.Transform.Origin, gamer.Transform.Scale, SpriteEffects.None, 1);
		base.DrawMono(spriteBatch, gamer);
    }
}
