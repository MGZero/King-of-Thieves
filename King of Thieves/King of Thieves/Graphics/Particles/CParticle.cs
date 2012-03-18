using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_Thieves.Graphics
{
    /* What the intent here is to make CParticle a "scaffolding" for creating
     * objects that are essentially particle effects. This will be done by
     * spawning a effects instance and then take care of setting up the basics
     * in XNA or whatever backend. CParticle will depend on either a generic
     * content manager that watchdogs specific pieces of content relating to this
     * engine, or I will create a class called CParticleTracker, which tracks particles
     * kills and spawns new ones, fires their timeers, etc.
     * Thoughts?
     */

    abstract class CParticle
    {
        private CRenderable _particle;
        private EffectParameter[] _particleParameters;

    }
}