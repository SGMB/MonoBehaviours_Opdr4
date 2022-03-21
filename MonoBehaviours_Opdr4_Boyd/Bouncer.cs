using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;

public class Bouncer : MonoBehaviour
{
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
    public Bouncer(float speed)
	{
        this.speed = speed;
	}
    public Bouncer(float speed, float waveHeight)
    {
        this.waveHeight = waveHeight;
        this.speed = speed;
    }
    public override void UpdateMono(GameTime gameTime, GameObject gamer)
    {
        time = (float)gameTime.TotalGameTime.TotalSeconds * speed;
        gamer.Transform.Position += new Vector2(0, MathF.Sin(time) * waveHeight);
        base.UpdateMono(gameTime, gamer);
    }
}
