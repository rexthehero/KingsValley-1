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
    public class ExplorerJumpLeft : AnimatedSprite
    {
        //Fields
        private Explorer explorer;
        private float startX, startY, a;
        private int startH, startK, h, k;


        //Constructor
        public ExplorerJumpLeft(Explorer explorer, int h, int k)
            : base(explorer)
        {
            this.explorer = explorer;
            this.startK = k;
            this.startH = h;
            this.i = 0;
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public void Initialize()
        {
            this.startX = this.explorer.Position.X;
            this.startY = this.explorer.Position.Y;
            this.h = (int)(this.startX + this.startH);
            this.k = (int)(this.startY - this.startK);
            this.a = this.CalculateA();
        }

        private float CalculateA()
        {
            return (this.startY - this.k) / (float)Math.Pow((double)(this.startX - this.h), 2d);
        }

        public override void Update(GameTime gameTime)
        {
            float x = this.explorer.Position.X - this.explorer.Speed;
            float y = (float)(this.a * Math.Pow((x - this.h), 2d) + this.k);
            this.explorer.Position = new Vector2(x, y);
            if (this.explorer.Position.Y > this.startY)
            {
                this.explorer.Position = new Vector2(x, startY);
                this.explorer.State = this.explorer.IdleLeft;

            }
            //base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

    }
}
