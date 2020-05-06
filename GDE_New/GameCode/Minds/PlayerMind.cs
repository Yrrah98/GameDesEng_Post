using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCode.Entites;
using GameCode.Entites.EnvironmentEntity;
using GameCode.Interfaces;
using GameEngine;
using GameEngine.Args;
using GameEngine.BaseEntity;
using GameEngine.BaseItem;
using GameEngine.BaseMind;
using GameEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace GameCode.Minds
{
    class PlayerMind : Mind, IStorer, IPlayer
    {
        private Vector2 _velocity;

        private bool colliding = false;

        private SoundEffectInstance sfxInst;

        private StoreItemDelegate _storeItem;

        private StrategyDelegate InitiatePlayerDeath;

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public PlayerMind()
        {
            _velocity = new Vector2(0, 0);
        }

        public void Inject(StoreItemDelegate pStore)
        {
            _storeItem = pStore;
        }

        #region IPlayer
        public void InjectPlayerDeathSequence(StrategyDelegate pDeath)
        {
            InitiatePlayerDeath = pDeath;
        }
        #endregion

        public override void OnCollisionEvent(object source, EventArgs pArgs)
        {


            if (((OnCollisionEventArgs)pArgs).uids[0] == possessedEntity.UID || ((OnCollisionEventArgs)pArgs).uids[1] == possessedEntity.UID)
            {
                if (((OnCollisionEventArgs)pArgs).e1 is TopWall || ((OnCollisionEventArgs)pArgs).e2 is TopWall 
                    || ((OnCollisionEventArgs)pArgs).e1 is DoorEntityTop || ((OnCollisionEventArgs)pArgs).e2 is DoorEntityTop)
                {

                    for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                    {
                        //((AnimateableEntity)possessedEntity).Shape.Points[i] += ((OnCollisionEventArgs)pArgs)._mtv * 2;
                        if(this._velocity.X > 0)
                            ((AnimateableEntity)possessedEntity).Shape.Points[i] += new Vector2(-16, 0);
                        if (this._velocity.X < 0)
                            ((AnimateableEntity)possessedEntity).Shape.Points[i] += new Vector2(16, 0);
                        if (this._velocity.Y > 0)
                            ((AnimateableEntity)possessedEntity).Shape.Points[i] += new Vector2(0, -16);
                        if(this._velocity.Y < 0)
                            ((AnimateableEntity)possessedEntity).Shape.Points[i] += new Vector2(0, 16);
                        //((AnimateableEntity)possessedEntity).Shape.Points[i] += (possessedEntity as AnimateableEntity)._velocity * -2;

                    }
                }

                if (((OnCollisionEventArgs)pArgs).e1 is Enemy1 || ((OnCollisionEventArgs)pArgs).e1 is Enemy2 ||
                    ((OnCollisionEventArgs)pArgs).e2 is Enemy1 || ((OnCollisionEventArgs)pArgs).e2 is Enemy2)
                {
                    (possessedEntity as KillableEntity).TakeDamage(1);
                    if ((possessedEntity as KillableEntity)._hpWidthCurr <= 0)
                        InitiatePlayerDeath();
                }

                if (((OnCollisionEventArgs)pArgs).e1 is BoxEntity)
                {
                    for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                    {
                        //((AnimateableEntity)possessedEntity).Shape.Points[i] += ((OnCollisionEventArgs)pArgs)._mtv;
                        (((OnCollisionEventArgs)pArgs).e1 as BoxEntity).PushBox(this._velocity);
                    }
                }
                if (((OnCollisionEventArgs)pArgs).e2 is BoxEntity)
                {
                    for (int i = 0; i < possessedEntity.Shape.Points.Count; i++)
                    {
                        //((AnimateableEntity)possessedEntity).Shape.Points[i] += ((OnCollisionEventArgs)pArgs)._mtv;
                        (((OnCollisionEventArgs)pArgs).e2 as BoxEntity).PushBox(this._velocity);
                    }
                }

                if (((OnCollisionEventArgs)pArgs).e1 is BaseItem)
                {
                    if (!(((OnCollisionEventArgs)pArgs).e1 as BaseItem).Stored)
                    {
                        (possessedEntity as PlayerEntity)._inventory.AddItem((((OnCollisionEventArgs)pArgs).e1 as BaseItem));
                        (((OnCollisionEventArgs)pArgs).e1 as BaseItem).Stored = true;
                        _storeItem(((OnCollisionEventArgs)pArgs).e1);
                    }
                    
                }
                if (((OnCollisionEventArgs)pArgs).e2 is BaseItem)
                {
                    if (!(((OnCollisionEventArgs)pArgs).e2 as BaseItem).Stored)
                    {
                        (possessedEntity as PlayerEntity)._inventory.AddItem((((OnCollisionEventArgs)pArgs).e2 as BaseItem));
                        (((OnCollisionEventArgs)pArgs).e2 as BaseItem).Stored = true;
                        _storeItem(((OnCollisionEventArgs)pArgs).e2);
                    }
                }


            }

        }

        public override void OnInputEvent(object source, EventArgs pArgs)
        {
            #region Inventory

            #endregion

            #region Movement
            // IF the W key is down
            if (((OnInputEventArgs)pArgs)._keys.IsKeyDown(Keys.W) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.D) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.A))
            {

                // SET the y velocity to the time value in the eventargs
                _velocity.Y = -4;
                // SET the possessed Entitys currentFrameY to 3
                ((AnimateableEntity)possessedEntity).CurrentFrameY = 3;
                // SET active true
                (possessedEntity as AnimateableEntity).active = true;
                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
                if (sfxInst == null)
                {
                    sfxInst = (possessedEntity as AnimateableEntity).eSfx.CreateInstance();
                    sfxInst.Play();
                }
                else
                    sfxInst.Play();

            }
            else if (((OnInputEventArgs)pArgs)._keys.IsKeyDown(Keys.S) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.D) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.A))
            {
                _velocity.Y = 4;

                ((AnimateableEntity)possessedEntity).CurrentFrameY = 0;
                (possessedEntity as AnimateableEntity).active = true;
                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
                if (sfxInst == null)
                {
                    sfxInst = (possessedEntity as AnimateableEntity).eSfx.CreateInstance();
                    sfxInst.Play();
                }
                else
                    sfxInst.Play();
            }
            else
            {
                if (sfxInst != null)
                    sfxInst.Stop();

                _velocity.Y = 0;
                (possessedEntity as AnimateableEntity).active = false;
                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
            }

            if (((OnInputEventArgs)pArgs)._keys.IsKeyDown(Keys.D) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.W) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.S))
            {
                _velocity.X = 4;

                if (sfxInst == null)
                {
                    sfxInst = (possessedEntity as AnimateableEntity).eSfx.CreateInstance();
                    sfxInst.Play();
                }
                else
                    sfxInst.Play();

                ((AnimateableEntity)possessedEntity).CurrentFrameY = 2;
                (possessedEntity as AnimateableEntity).active = true;
                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
            }
            else if (((OnInputEventArgs)pArgs)._keys.IsKeyDown(Keys.A) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.W) && ((OnInputEventArgs)pArgs)._keys.IsKeyUp(Keys.S))
            {
                _velocity.X = -4;

                if (sfxInst == null)
                {
                    sfxInst = (possessedEntity as AnimateableEntity).eSfx.CreateInstance();
                    sfxInst.Play();
                }
                else
                    sfxInst.Play();

                ((AnimateableEntity)possessedEntity).CurrentFrameY = 1;
                (possessedEntity as AnimateableEntity).active = true;
                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
            }
            else
            {
                _velocity.X = 0;

                ((AnimateableEntity)possessedEntity)._velocity = this._velocity;
            }
            #endregion
        }

        /// <summary>
        /// METHOD: Update, a method which will include behavioural code which is called once per frame
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            // FORLOOP through the 
            for (int i = 0; i < (possessedEntity as AnimateableEntity).Shape.Points.Count; i++)
            {
                // INCREMENT the value of each point by the velocity
                ((AnimateableEntity)possessedEntity).Shape.Points[i] += _velocity;

            }

            if ((possessedEntity as AnimateableEntity).active)
            {
                (possessedEntity as AnimateableEntity).frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else
                (possessedEntity as AnimateableEntity).frameCounter = 0;

            base.Update(gameTime);
        }
    }
}
