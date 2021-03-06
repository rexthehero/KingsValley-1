﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KingsValley1
{
    public class Explorer
    {
        //Fields
        private KingsValley game;
        private Vector2 position;
        private Texture2D texture;
        private Rectangle rectangle;
        private float speed = 1;
        private AnimatedSprite state;
        private ExplorerWalkRight walkRight;
        private ExplorerIdleRight idleRight;
        private ExplorerWalkLeft walkLeft;
        private ExplorerIdleLeft idleLeft;
        private ExplorerJumpRight jumpRight;
        private ExplorerJumpLeft jumpLeft;
        private ExplorerIdleJumpRight idleJumpRight;
        private ExplorerIdleJumpLeft idleJumpLeft;

        //Properties
        public Vector2 Position
        {
            get { return this.position; }
            set { 
                    this.position = value;
                    this.rectangle.X = (int)this.position.X;
                    this.rectangle.Y = (int)this.position.Y;
                }
        }
        public float Speed
        {
            get { return this.speed; }
        }
        public KingsValley Game
        {
            get { return this.game; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }
        public AnimatedSprite State
        {
            set { this.state = value; }
        }
        public ExplorerWalkRight WalkRight
        {
            set { this.walkRight = value; }
            get { return this.walkRight; }
        }
        public ExplorerIdleRight IdleRight
        {
            get { return this.idleRight; }
        }
        public ExplorerWalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public ExplorerIdleLeft IdleLeft
        {
            get { return this.idleLeft; }
        }
        public ExplorerJumpRight JumpRight
        {
            get { return this.jumpRight; }
        }
        public ExplorerJumpLeft JumpLeft
        {
            get { return this.jumpLeft; }
        }
        public ExplorerIdleJumpRight IdleJumpRight
        {
            get { return this.idleJumpRight; }
        }
        public ExplorerIdleJumpLeft IdleJumpLeft
        {
            get { return this.idleJumpLeft; }
            set { this.idleJumpLeft = value; }
        }

        //Constructor
        public Explorer(KingsValley game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"Explorer\explorer");
            this.rectangle = new Rectangle((int)this.position.X,
                                           (int)this.position.Y,
                                           this.texture.Width / 8,
                                           this.texture.Height);
            this.walkRight = new ExplorerWalkRight(this);
            this.idleRight = new ExplorerIdleRight(this);
            this.walkLeft = new ExplorerWalkLeft(this);
            this.idleLeft = new ExplorerIdleLeft(this);
            this.jumpRight = new ExplorerJumpRight(this, 20, 32);
            this.jumpLeft = new ExplorerJumpLeft(this, -20, 32);
            this.idleJumpRight = new ExplorerIdleJumpRight(this, 20, 32);
            this.idleJumpLeft = new ExplorerIdleJumpLeft(this, 20, 32);
            this.state = new ExplorerIdleRight(this);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);           
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
