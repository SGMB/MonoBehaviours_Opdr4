using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

public class BounceObject : GameObject
{
    private Transform transform;
    private float time;
    private float speed;
    private float waveHeight;

    public float Speed
    {
        get { return speed; }
    }
    public float WaveHeight
    {
        get { return waveHeight; }
    }
    public BounceObject(Transform trans, SpriteRenderer render, Texture2D texture, float speed) : base(trans, render)
	{
        render.Texture = texture;
        transform = trans;
        this.speed = speed;
	}
    public BounceObject(Transform trans, SpriteRenderer render, Texture2D texture, Vector2 origin, float speed, float waveHeight) : base(trans, render)
    {
        render.Texture = texture;
        transform = trans;
        transform.Origin = origin;
        this.waveHeight = waveHeight;
        this.speed = speed;
    }

    public override void Update(GameTime gameTime)
    {
        time = (float)gameTime.TotalGameTime.TotalSeconds * speed;
        transform.Position += new Vector2(0, MathF.Sin(time) * waveHeight);
        base.Update(gameTime);
    }
}
