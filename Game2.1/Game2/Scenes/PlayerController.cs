using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    class PlayerController : Component, IUpdatable
    {
        public float moveSpeed = 150;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;

        TiledMapMover _mover;
        BoxCollider _boxCollider;
        Vector2 _velocity;
        TiledMapMover.CollisionState _collisionState = new TiledMapMover.CollisionState();

        public override void onAddedToEntity()
        {
            _mover = this.getComponent<TiledMapMover>();
            _boxCollider = entity.getCollider<BoxCollider>();
        }

        public void update()
        {
            if (Input.isKeyDown(Keys.Left))
                _velocity.X = -moveSpeed;
            else if (Input.isKeyDown(Keys.Right))
                _velocity.X = moveSpeed;
            else
                _velocity.X = 0;

            if (_collisionState.below && Input.isKeyPressed(Keys.Space))
                _velocity.Y = -Mathf.sqrt(2 * jumpHeight * gravity);

            //slopes
            

            //apply gravity
            _velocity.Y += gravity * Time.deltaTime;


            //move
            _mover.move(_velocity * Time.deltaTime, _boxCollider, _collisionState);


            //update velocity
            if (_collisionState.right || _collisionState.left)
                _velocity.X = 0;

            if (_collisionState.above || _collisionState.below)
                _velocity.Y = 0;
        }
    }
}
