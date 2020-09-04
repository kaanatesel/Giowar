using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    interface ImoveAble
    {
        void setDirection(Vector3 dirVec);
        Vector3 getMovingDirection();
        void move();
        void setSpeed(float newSpeed);
        float getSpeed();


    }
}
