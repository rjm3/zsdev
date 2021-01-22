
SoundProfileData Profile3dZombieC
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 550.0;
   flags = SFX_IS_HARDWARE_3D;
};

// Zombie Voice Sounds & Projectiles

SoundData SoundZombieCall1
{
   wavFileName = "zombie_voice_1.wav";
   profile = Profile3dZombieC;
};
SoundData SoundZombieCall2
{
   wavFileName = "zombie_voice_2.wav";
   profile = Profile3dZombieC;
};
SoundData SoundZombieCall3
{
   wavFileName = "zombie_voice_3.wav";
   profile = Profile3dZombieC;
};
SoundData SoundZombieCall4
{
   wavFileName = "zombie_voice_4.wav";
   profile = Profile3dZombieC;
};
SoundData SoundZombieCall5
{
   wavFileName = "zombie_voice_5.wav";
   profile = Profile3dZombieC;
};

ExplosionData SndZombieCall1Exp
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieCall1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SndZombieCall2Exp
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieCall2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SndZombieCall3Exp
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieCall3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SndZombieCall4Exp
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieCall4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

ExplosionData SndZombieCall5Exp
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieCall5;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

GrenadeData SndZombieCall1
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombieCall1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

GrenadeData SndZombieCall2
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombieCall2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

GrenadeData SndZombieCall3
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombieCall3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

GrenadeData SndZombieCall4
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombieCall4Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

GrenadeData SndZombieCall5
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombieCall5Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

SoundData SoundFzombieScream
{
   wavFileName = "fz_scream_1.wav";
   profile = Profile3dZombieC;
};

ExplosionData SndFzScreamExp
{
   shapeName = "invisable.dts";
   soundId   = SoundFzombieScream;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0;

   timeScale = 0.001;

   timeZero = 0.001;
   timeOne  = 0.001;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

GrenadeData SndFzScream
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndFzScreamExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $ZombieDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};