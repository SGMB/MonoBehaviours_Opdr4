using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace MonoBehaviours_Opdr4_Boyd
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Switch "scenes" values
        private int sceneNum = 0;
        private bool MixedToggle; // Toggled tussen de normale showcase van components en de mixed showcase
        private bool clickShift;
        private bool ClickedBool;

        //Textures voor de objects
        Texture2D _texture;
        Texture2D _texture2;

        //Objects voor de component scenes
        GameObject[] _rotatorObj;
        GameObject[] _bouncerObj;
        GameObject[] _scaleObj;
        GameObject _colorShiftObj;

        //gameobjects voor de Mixed scenes
        GameObject _variant1;
        GameObject _variant2;
        GameObject _variant3;
        GameObject _variant4;
        GameObject _variant5;
        GameObject _variant6;
        GameObject _variant7;
        GameObject _variant8;

        SpriteFont _font;
        Viewport viewPort;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Content.RootDirectory = "Content";
            base.Initialize();
        }

        protected override void LoadContent()
        {
            viewPort = GraphicsDevice.Viewport;
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("Shield");
            _texture2 = Content.Load<Texture2D>("LittleStar");
            _font = Content.Load<SpriteFont>("ButtonFont");

            //origin posities voor bijde textures
            Vector2 _centerOrigin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            Vector2 _centerOrigin2 = new Vector2(_texture2.Width / 2, _texture2.Height / 2);
        
            #region Rotation Scene
            
            //Rotate Object array
            _rotatorObj = new GameObject[]
            {
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject()
            };

            //transforms maken die net zo lang als de Object array
            Transform[] transRot = new Transform[_rotatorObj.Length];

            for (int i = 0; i < _rotatorObj.Length; i++)
            {
                transRot[i] = new Transform();
            }

            //Rotate spriterenderer
            SpriteRenderer spriteRenRot = new SpriteRenderer();

            //Rotater component array met values
            Rotater[] _rotatorComp = new Rotater[]
            {
                new Rotater(3),
                new Rotater(5),
                new Rotater(12),
                new Rotater(9),
                new Rotater(-6)
            };

            //Voor elk Object de components assignen
            for (int i = 0; i < _rotatorObj.Length; i++)
            {
                _rotatorObj[i] = new GameObject(transRot[i], spriteRenRot, _rotatorComp[i]);
            }

            //Texture assignment
            for (int i = 0; i < _rotatorObj.Length; i++)
            {
                _rotatorObj[i].GetComponent<SpriteRenderer>().Texture = _texture;
            }

            //Positie voor elk object
            #region rotation position
            _rotatorObj[0].Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);//center
            _rotatorObj[1].Transform.Position = new Vector2(viewPort.Width / 3, viewPort.Height / 4);//top left
            _rotatorObj[2].Transform.Position = new Vector2(viewPort.Width / 1.5f, viewPort.Height / 4);//top right
            _rotatorObj[3].Transform.Position = new Vector2(viewPort.Width / 1.5f, viewPort.Height / 1.3f);//bottem right
            _rotatorObj[4].Transform.Position = new Vector2(viewPort.Width / 3, viewPort.Height / 1.3f);//bottem left
            #endregion

            //Origin voor elk object
            #region rotation origin
            _rotatorObj[0].Transform.Origin = new Vector2(_texture.Width/2, _texture.Height/2);
            _rotatorObj[1].Transform.Origin = Vector2.Zero;
            _rotatorObj[2].Transform.Origin = new Vector2(_texture.Width, 0);
            _rotatorObj[3].Transform.Origin = new Vector2(_texture.Width, _texture.Height);
            _rotatorObj[4].Transform.Origin = new Vector2(0, _texture.Height);
            #endregion

            #endregion

            #region Bounce Scene

            //Bounce Object array
            _bouncerObj = new GameObject[]
            {
                new GameObject(),
                new GameObject(),
                new GameObject()
            };

            //Transforms maken die net zo lang als de Object array
            Transform[] transBounce = new Transform[_bouncerObj.Length];

            for (int i = 0; i < _bouncerObj.Length; i++)
            {
                transBounce[i] = new Transform();
            }

            //Bounce spriterenderer
            SpriteRenderer spriteRenBounce = new SpriteRenderer();

            //Bouncer component array met values
            Bouncer[] _bouncerComp = new Bouncer[]
            {
                new Bouncer(2, 3),
                new Bouncer(8, 5),
                new Bouncer(16, 15)
            };

            //Voor elk object components assignen
            for (int i = 0; i < _bouncerObj.Length; i++)
            {
                _bouncerObj[i] = new GameObject(transBounce[i], spriteRenBounce, _bouncerComp[i]);
            }

            //Texture assignment
            for (int i = 0; i < _bouncerObj.Length; i++)
            {
                _bouncerObj[i].GetComponent<SpriteRenderer>().Texture = _texture;
            }

            //Positie voor elk object
            #region bounce position
            _bouncerObj[0].Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2.5f);
            _bouncerObj[1].Transform.Position = new Vector2(viewPort.Width / 4, viewPort.Height / 2.5f);
            _bouncerObj[2].Transform.Position = new Vector2(viewPort.Width / 1.3f, viewPort.Height / 2.5f);
            #endregion

            //Origin voor elk object
            #region bounce origin
            for (int i = 0; i < _bouncerObj.Length; i++)
            {
                _bouncerObj[i].Transform.Origin = _centerOrigin;
            }
            #endregion

            #endregion

            #region Scale Scene

            //Scale Object array
            _scaleObj = new GameObject[]
            {
                new GameObject(),
                new GameObject(),
                new GameObject(),
                new GameObject()
            };

            //Transforms maken die net zo lang als de Object array
            Transform[] transScale = new Transform[_scaleObj.Length];

            for (int i = 0; i < _scaleObj.Length; i++)
            {
                transScale[i] = new Transform();
            }

            //Scale Spriterenderer
            SpriteRenderer spriteRenScale = new SpriteRenderer();

            //Scaler component array met values
            Scaler[] _scaleComp = new Scaler[]
            {
                new Scaler(4),
                new Scaler(-5),
                new Scaler(9),
                new Scaler(15)
            };

            //Voor elk object components assignen
            for (int i = 0; i < _scaleObj.Length; i++)
            {
                _scaleObj[i] = new GameObject(transScale[i], spriteRenScale, _scaleComp[i]);
            }

            //Texture assignment
            for (int i = 0; i < _scaleObj.Length; i++)
            {
                _scaleObj[i].GetComponent<SpriteRenderer>().Texture = _texture;
            }

            //Positie voor elk object
            #region scale position
            _scaleObj[0].Transform.Position = new Vector2(viewPort.Width/3, viewPort.Height/3);
            _scaleObj[1].Transform.Position = new Vector2(viewPort.Width/ 1.5f, viewPort.Height/3);
            _scaleObj[2].Transform.Position = new Vector2(viewPort.Width/3, viewPort.Height / 1.5f);
            _scaleObj[3].Transform.Position = new Vector2(viewPort.Width/1.5f, viewPort.Height/1.5f);
            #endregion

            //Origin voor elk object
            #region scale origin
            for (int i = 0; i < _scaleObj.Length; i++)
            {
                _scaleObj[i].Transform.Origin = _centerOrigin;
            }
            #endregion

            #endregion

            #region ColorShifter Scene
            
            //Colorshifter transform
            Transform transColor = new Transform();

            //Colorshifter spriterenderer
            SpriteRenderer spriteRenColor = new SpriteRenderer();

            //Colorshifter component met value
            ColorShifter _colorShifterComp = new ColorShifter(1);

            //Component assignment
            _colorShiftObj = new GameObject(transColor, spriteRenColor, _colorShifterComp);

            //Texture assignment
            _colorShiftObj.GetComponent<SpriteRenderer>().Texture = _texture2;

            //positie voor het object
            _colorShiftObj.Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);

            //origin voor het object
            _colorShiftObj.Transform.Origin = new Vector2(_texture2.Width / 2, _texture2.Height / 2);
            #endregion

            #region mixed scene 1
            //gameobjects empty
            _variant1 = new GameObject();
            _variant2 = new GameObject();
            _variant3 = new GameObject();

            //transform
            Transform _vari1Trans = new Transform();
            Transform _vari2Trans = new Transform();
            Transform _vari3Trans = new Transform();

            //renderer
            SpriteRenderer _vari1Render = new SpriteRenderer();
            SpriteRenderer _vari2Render = new SpriteRenderer();
            SpriteRenderer _vari3Render = new SpriteRenderer();

            //components
            Rotater _vari1Rotater = new Rotater(4);
            ColorShifter _vari2ColorShifter = new ColorShifter(1);
            Scaler _vari3Scaler = new Scaler(3);
            Bouncer _vari1Bouncer = new Bouncer(6, 10);
            Bouncer _vari2Bouncer = new Bouncer(3, 8);
            Bouncer _vari3Bouncer = new Bouncer(1f, 2);

            //gameobject with components
            _variant1 = new GameObject(_vari1Trans, _vari1Render, _vari1Bouncer, _vari1Rotater);
            _variant2 = new GameObject(_vari2Trans, _vari2Render, _vari2Bouncer, _vari2ColorShifter);
            _variant3 = new GameObject(_vari3Trans, _vari3Render, _vari3Bouncer, _vari3Scaler);

            //texture assignment
            _variant1.GetComponent<SpriteRenderer>().Texture = _texture2;
            _variant2.GetComponent<SpriteRenderer>().Texture = _texture2;
            _variant3.GetComponent<SpriteRenderer>().Texture = _texture2;

            //position & origin assignment
            _variant1.Transform.Position = new Vector2(viewPort.Width/2/2, viewPort.Height/4);
            _variant2.Transform.Position = new Vector2(viewPort.Width/2/2 + viewPort.Width/2, viewPort.Height/6);
            _variant3.Transform.Position = new Vector2(viewPort.Width/2, viewPort.Height/4);
            _variant1.Transform.Origin = _centerOrigin2;
            _variant2.Transform.Origin = _centerOrigin2;
            _variant3.Transform.Origin = _centerOrigin2;
            #endregion

            #region Mixed scene 2
            //gameobjects empty
            _variant4 = new GameObject();
            _variant5 = new GameObject();
            _variant6 = new GameObject();

            //transform
            Transform _vari4Trans = new Transform();
            Transform _vari5Trans = new Transform();
            Transform _vari6Trans = new Transform();

            //renderer
            SpriteRenderer _vari4Render = new SpriteRenderer();
            SpriteRenderer _vari5Render = new SpriteRenderer();
            SpriteRenderer _vari6Render = new SpriteRenderer();

            //components
            Rotater _vari4Rotater = new Rotater(7);
            ColorShifter _vari5ColorShifter = new ColorShifter(3);
            Rotater _vari6Rotater = new Rotater(1);
            Scaler _vari4Scaler = new Scaler(1);
            Scaler _vari5Scaler = new Scaler(6);
            ColorShifter _vari6ColorShifter = new ColorShifter(1);

            //gameobject with components
            _variant4 = new GameObject(_vari4Trans, _vari4Render, _vari4Rotater, _vari4Scaler);
            _variant5 = new GameObject(_vari5Trans, _vari5Render, _vari5Scaler, _vari5ColorShifter);
            _variant6 = new GameObject(_vari6Trans, _vari6Render, _vari6Rotater, _vari6ColorShifter);

            //texture assignment
            _variant4.GetComponent<SpriteRenderer>().Texture = _texture2;
            _variant5.GetComponent<SpriteRenderer>().Texture = _texture2;
            _variant6.GetComponent<SpriteRenderer>().Texture = _texture2;

            //position & origin assignment
            _variant4.Transform.Position = new Vector2(viewPort.Width / 2 / 2, viewPort.Height / 2);
            _variant5.Transform.Position = new Vector2(viewPort.Width / 2 / 2 + viewPort.Width / 2, viewPort.Height / 2);
            _variant6.Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 2);
            _variant4.Transform.Origin = _centerOrigin2;
            _variant5.Transform.Origin = _centerOrigin2;
            _variant6.Transform.Origin = _centerOrigin2;
            #endregion

            #region Mixed scene 3
            //gameobjects empty
            _variant7 = new GameObject();

            //transform
            Transform _vari7Trans = new Transform();

            //renderer
            SpriteRenderer _vari7Render = new SpriteRenderer();

            //components
            Rotater _vari7Rotater = new Rotater(6);
            ColorShifter _vari7ColorShifter = new ColorShifter(2);
            Bouncer _vari7Bouncer = new Bouncer(3, 5);

            //gameobject with components
            _variant7 = new GameObject(_vari7Trans, _vari7Render, _vari7Bouncer, _vari7Rotater, _vari7ColorShifter);

            //texture assignment
            _variant7.GetComponent<SpriteRenderer>().Texture = _texture2;

            //position & origin assignment
            _variant7.Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 4);
            _variant7.Transform.Origin = _centerOrigin2;
            #endregion

            #region Mixed scene 4
            //gameobjects empty
            _variant8 = new GameObject();

            //transform
            Transform _vari8Trans = new Transform();

            //renderer
            SpriteRenderer _vari8Render = new SpriteRenderer();

            //components
            Rotater _vari8Rotater = new Rotater(3);
            ColorShifter _vari8ColorShifter = new ColorShifter(4);
            Bouncer _vari8Bouncer = new Bouncer(1, 2);
            Scaler _vari8Scaler = new Scaler(5);

            //gameobject with components
            _variant8 = new GameObject(_vari8Trans, _vari8Render, _vari8Bouncer, _vari8Rotater, _vari8ColorShifter, _vari8Scaler);

            //texture assignment
            _variant8.GetComponent<SpriteRenderer>().Texture = _texture2;

            //position & origin assignment
            _variant8.Transform.Position = new Vector2(viewPort.Width / 2, viewPort.Height / 4);
            _variant8.Transform.Origin = _centerOrigin2;
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            #region Start Keyboard
            KeyboardState keyboardState = Keyboard.GetState();

            //Checked of de spatie knop ingedrukt is of niet. Als het los laat doet het de functie
            if (keyboardState.IsKeyDown(Keys.Space)) ClickedBool = true;
            else if (ClickedBool == true)
            {
                if (keyboardState.IsKeyUp(Keys.Space))
                {
                    //scene number omhoog
                    sceneNum += 1;
                    ClickedBool = false;
                }
            }
            else ClickedBool = false;

            //Checked of de rechter shift knop ingedrukt is of niet. Als het los laat doet het de functie
            if (keyboardState.IsKeyDown(Keys.RightShift)) clickShift = true;
            else if (clickShift == true)
            {
                if (keyboardState.IsKeyUp(Keys.RightShift))
                {
                    //checked of de MixedToggle well of niet true of false is.
                    if (MixedToggle)
                    {
                        MixedToggle = false;
                        clickShift = false;
                    }
                    else
                    {
                        MixedToggle = true;
                        clickShift = false;
                    }
                }
            }
            else clickShift = false;

            if (sceneNum == 4) sceneNum = 0;
            #endregion

            //for loops voor de array gameobjects updates
            for (int i = 0; i < _bouncerObj.Length; i++) _bouncerObj[i].Update(gameTime);

            for (int i = 0; i < _rotatorObj.Length; i++) _rotatorObj[i].Update(gameTime);

            for (int i = 0; i < _scaleObj.Length; i++) _scaleObj[i].Update(gameTime);
            
            _colorShiftObj.Update(gameTime);

            //alle mixed gameObjects updates
            _variant1.Update(gameTime);
            _variant2.Update(gameTime);
            _variant3.Update(gameTime);
            _variant4.Update(gameTime);
            _variant5.Update(gameTime);
            _variant6.Update(gameTime);
            _variant7.Update(gameTime);
            _variant8.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //Instructie text
            _spriteBatch.DrawString(_font, "KLIK OP 'Spatie' VOOR VOLGENDE VOORBEELD", new Vector2(viewPort.Width / 3.26f, 0), Color.Black);
            _spriteBatch.DrawString(_font, "KLIK OP 'rechterShift' VOOR GEMIXDE COMPONENTS", new Vector2(viewPort.Width / 3.6f, 20), Color.Black);
            
            //checked of het de mixed components well of niet moet laten zien.
            if (!MixedToggle)
            {
                switch (sceneNum)
                {
                    case 0:
                        for (int i = 0; i < _bouncerObj.Length; i++)
                        {
                            _bouncerObj[i].Draw(_spriteBatch);
                            _spriteBatch.DrawString(_font, $"Bounce Speed: {_bouncerObj[i].GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_bouncerObj[i].GetComponent<Bouncer>().WaveHeight}", new Vector2(_bouncerObj[i].Transform.Position.X - 75, _bouncerObj[i].Transform.Position.Y + _texture.Height), Color.Black);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < _rotatorObj.Length; i++)
                        {
                            _rotatorObj[i].Draw(_spriteBatch);
                            _spriteBatch.DrawString(_font, $"Rotation Speed: {_rotatorObj[i].GetComponent<Rotater>().Speed}", new Vector2(_rotatorObj[i].Transform.Position.X - 65, _rotatorObj[i].Transform.Position.Y + _texture.Height), Color.Black);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < _scaleObj.Length; i++)
                        {
                            _scaleObj[i].Draw(_spriteBatch);
                            _spriteBatch.DrawString(_font, $"Scale Speed: {_scaleObj[i].GetComponent<Scaler>().Speed}", new Vector2(_scaleObj[i].Transform.Position.X - 45, _scaleObj[i].Transform.Position.Y + _texture.Height), Color.Black);
                        }
                        break;
                    case 3:
                        _colorShiftObj.Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"Shift Speed: {_colorShiftObj.GetComponent<ColorShifter>().ShiftSpeed}", new Vector2(_colorShiftObj.Transform.Position.X - 45, _colorShiftObj.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        break;

                }
            }
            else
            {
                switch (sceneNum)
                {
                    case 0:
                        _variant1.Draw(_spriteBatch);
                        _variant2.Draw(_spriteBatch);
                        _variant3.Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"rotation speed: {_variant1.GetComponent<Rotater>().Speed}\nBounce speed: {_variant1.GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_variant1.GetComponent<Bouncer>().WaveHeight}", new Vector2(_variant1.Transform.Position.X - 45, _variant1.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        _spriteBatch.DrawString(_font, $"Shifting speed: {_variant2.GetComponent<ColorShifter>().ShiftSpeed}\nBounce speed: {_variant2.GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_variant2.GetComponent<Bouncer>().WaveHeight}", new Vector2(_variant2.Transform.Position.X - 45, _variant2.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        _spriteBatch.DrawString(_font, $"Scale speed: {_variant3.GetComponent<Scaler>().Speed}\nBounce speed: {_variant3.GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_variant3.GetComponent<Bouncer>().WaveHeight}", new Vector2(_variant3.Transform.Position.X - 45, _variant3.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        break;
                    case 1:
                        _variant4.Draw(_spriteBatch);
                        _variant5.Draw(_spriteBatch);
                        _variant6.Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"Rotate speed: {_variant4.GetComponent<Rotater>().Speed}\nScale speed: {_variant4.GetComponent<Scaler>().Speed}", new Vector2(_variant4.Transform.Position.X - 45, _variant4.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        _spriteBatch.DrawString(_font, $"Scale speed: {_variant5.GetComponent<Scaler>().Speed}\nShift speed: {_variant5.GetComponent<ColorShifter>().ShiftSpeed}", new Vector2(_variant5.Transform.Position.X - 45, _variant5.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        _spriteBatch.DrawString(_font, $"Rotate speed: {_variant6.GetComponent<Rotater>().Speed}\nShift speed: {_variant6.GetComponent<ColorShifter>().ShiftSpeed}", new Vector2(_variant6.Transform.Position.X - 45, _variant6.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        break;
                    case 2:
                        _variant7.Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"Rotate speed: {_variant7.GetComponent<Rotater>().Speed}\nBounce speed: {_variant7.GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_variant7.GetComponent<Bouncer>().WaveHeight}\nShifting speed: {_variant7.GetComponent<ColorShifter>().ShiftSpeed}", new Vector2(_variant7.Transform.Position.X - 45, _variant7.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        break;
                    case 3:
                        _variant8.Draw(_spriteBatch);
                        _spriteBatch.DrawString(_font, $"Rotate speed: {_variant8.GetComponent<Rotater>().Speed}\nBounce speed: {_variant8.GetComponent<Bouncer>().Speed}\nBounce WaveLength: {_variant8.GetComponent<Bouncer>().WaveHeight}\nShifting speed: {_variant8.GetComponent<ColorShifter>().ShiftSpeed}\nScale Speed: {_variant8.GetComponent<Scaler>().Speed}", new Vector2(_variant8.Transform.Position.X - 45, _variant8.Transform.Position.Y + _texture.Height + 40), Color.Black);
                        break;
                }
            }
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
