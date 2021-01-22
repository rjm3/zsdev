
// RELOAD SOUND FILE

SoundProfileData Profile3dReload
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 205.0;
   flags = SFX_IS_HARDWARE_3D;
};

// Reload Sounds & Projectiles

// FIVE SEVEN ----------------------------------------------------------------------------------

SoundData SoundFivesevenClipOut
{
   wavFileName = "fiveseven_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundFivesevenClipIn
{
   wavFileName = "fiveseven_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndFivesevenClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundFivesevenClipOut;

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

GrenadeData SndFivesevenClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndFivesevenClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $FivesevenDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndFivesevenClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundFivesevenClipIn;

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

GrenadeData SndFivesevenClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndFivesevenClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $FivesevenDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// P228 ----------------------------------------------------------------------------------

SoundData SoundP228ClipOut
{
   wavFileName = "p228_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundP228ClipIn
{
   wavFileName = "P228_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndP228ClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundP228ClipOut;

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

GrenadeData SndP228ClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndP228ClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $P228DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndP228ClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundP228ClipIn;

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

GrenadeData SndP228ClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndP228ClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $P228DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// BERETTA ----------------------------------------------------------------------------------

SoundData SoundBerettaClipOut
{
   wavFileName = "beretta_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundBerettaClipIn
{
   wavFileName = "beretta_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndBerettaClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundBerettaClipOut;

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

GrenadeData SndBerettaClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndBerettaClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $BerettaDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndBerettaClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundBerettaClipIn;

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

GrenadeData SndBerettaClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndBerettaClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $BerettaDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// Glock 17 ----------------------------------------------------------------------------------

SoundData SoundGlockClipOut
{
   wavFileName = "glock_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundGlockClipIn
{
   wavFileName = "glock_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndGlockClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundGlockClipOut;

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

GrenadeData SndGlockClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndGlockClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $GlockDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndGlockClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundGlockClipIn;

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

GrenadeData SndGlockClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndGlockClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $GlockDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// DEAGLE ----------------------------------------------------------------------------------

SoundData SoundDeagleClipOut
{
   wavFileName = "deagle_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundDeagleClipIn
{
   wavFileName = "deagle_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndDeagleClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundDeagleClipOut;

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

GrenadeData SndDeagleClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndDeagleClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $DeagleDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndDeagleClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundDeagleClipIn;

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

GrenadeData SndDeagleClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndDeagleClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $DeagleDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// MP5 ----------------------------------------------------------------------------------

SoundData SoundMP5ClipOut
{
   wavFileName = "mp5_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundMP5ClipIn
{
   wavFileName = "mp5_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndMP5ClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundMP5ClipOut;

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

GrenadeData SndMP5ClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndMP5ClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $MP5DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndMP5ClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundMP5ClipIn;

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

GrenadeData SndMP5ClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndMP5ClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $MP5DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// MAC-10 ----------------------------------------------------------------------------------

SoundData SoundMAC10ClipOut
{
   wavFileName = "mac10_clipout.wav";
   profile = Profile3dReload;
};

SoundData SoundMAC10ClipIn
{
   wavFileName = "mac10_clipin.wav";
   profile = Profile3dReload;
};

ExplosionData SndMAC10ClipOutExp
{
   shapeName = "invisable.dts";
   soundId   = SoundMAC10ClipOut;

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

GrenadeData SndMAC10ClipOut
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndMAC10ClipOutExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $MAC10DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

ExplosionData SndMAC10ClipInExp
{
   shapeName = "invisable.dts";
   soundId   = SoundMAC10ClipIn;

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

GrenadeData SndMAC10ClipIn
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndMAC10ClipInExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $MAC10DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// M1014 ----------------------------------------------------------------------------------

SoundData SoundM1014InsertShell
{
   wavFileName = "m1014_insertshell.wav";
   profile = Profile3dReload;
};

ExplosionData SndM1014InsertShellExp
{
   shapeName = "invisable.dts";
   soundId   = SoundM1014InsertShell;

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

GrenadeData SndM1014InsertShell
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndM1014InsertShellExp;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $M1014DamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};
