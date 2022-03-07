using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;


public class Transform 
{
	private Vector2 _position;
	private float _rotation = 0;
	private Vector2 _scale = Vector2.One;
	private Vector2 _imageCenter;
	private float _layerDepth = 0;
	private bool _active = true;
	public Vector2 Position
	{
		get { return _position; }
		set { _position = value; }
	}
	public float Rotation
	{
		get { return _rotation; }
		set { _rotation = value; }
	}
	public Vector2 Scale
	{
		get { return _scale; }
		set { _scale = value; }
	}
	public Vector2 Origin
	{
		get { return _imageCenter; }
		set
		{
			_imageCenter = value;
		}
	}

	public float LayerDepth
    {
		get { return _layerDepth; }
		set { _layerDepth = value; }
    }

	public bool Active
    {
		get { return _active; }
		set { _active = value; }
    }
	public Transform() { }
	public Transform(Vector2 position)
    {
		Position = position;
    }

	public Transform(Vector2 position, float rotation)
    {
		Position = position;
		Rotation = rotation;
    }

	public Transform(Vector2 position, float rotation, Vector2 scale)
    {
		Position = position;
		Rotation = rotation;
		Scale = scale;
	}
}
