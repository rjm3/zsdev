// ZOMBIE ATTACK

exec(soundZombie);

SoundProfileData ProfileZombieSHitwall
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};
SoundData SoundZombieSHitwall1
{
   wavFileName = "claw_strike1.wav";
   profile = ProfileZombieSHitwall;
};
SoundData SoundZombieSHitwall2
{
   wavFileName = "claw_strike2.wav";
   profile = ProfileZombieSHitwall;
};
SoundData SoundZombieSHitwall3
{
   wavFileName = "claw_strike13.wav";
   profile = ProfileZombieSHitwall;
};

// explosion data
ExplosionData ZombieSExp0
{
   shapeName = "chainspk.dts";
   soundId   = SoundZombieSHitwall1;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
ExplosionData ZombieSExp1
{
   shapeName = "chainspk.dts";
   soundId   = SoundZombieSHitwall2;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
ExplosionData ZombieSExp2
{
   shapeName = "chainspk.dts";
   soundId   = SoundZombieSHitwall3;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

// projectile data
BulletData ZombieSwing
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = ZombieSExp0;
   expRandCycle       = 3;

   damageClass        = 0;
   damageValue        = 25.0;
   damageType         = $ZombieSDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.19;
   liveTime           = 0.19;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

};

// sound data
SoundProfileData Profile3dZombieS
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dZombieSDeploy
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundZombieSwing
{
   wavFileName = "claw_miss1.wav";
   profile = Profile3dZombieS;
};


//-------------------------------------------------------------------------------------------

//-------------------------------------------------------------------------------------------
// Attack Sounds & Projectiles

SoundData SoundZombieAttack1
{
   wavFileName = "zo_attack1.wav";
   profile = Profile3dZombieS;
};
SoundData SoundZombieAttack2
{
   wavFileName = "zo_attack2.wav";
   profile = Profile3dZombieS;
};

ExplosionData SndZombAtkExp0
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieAttack1;

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
ExplosionData SndZombAtkExp1
{
   shapeName = "invisable.dts";
   soundId   = SoundZombieAttack2;

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

GrenadeData SndZombAtk1
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombAtkExp0;
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
GrenadeData SndZombAtk2
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndZombAtkExp1;
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

//-------------------------------------------------------------------------------------------

SoundData SoundZombieSDeploy
{
   wavFileName = "knife_deploy.wav";
   profile = Profile3dKnifeDeploy;
};

// ammo data
ItemData ZombieSAmmo
{
	description = "Zombie Claw";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData ZombieSImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.15;
	fireTime = 0.1;
      ammoType = ZombieSAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundZombieSwing;
};

ItemData ZombieS
{
	description = "Zombie Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = ZombieSImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

$WeaponAmmo[ZombieS] = ZombieSAmmo;
$AutoUse[ZombieS]= True;
$Use[ZombieS] = True;

addWeapon("ZombieS");

// dev damage types
$ZombieSDamageType = 900;

// dev armors
$DamageScale[armorHuman, $ZombieSDamageType] = 1.0;
$DamageScale[armorHumanF, $ZombieSDamageType] = 1.0;
$DamageScale[armorZombie, $ZombieSDamageType] = 1.0;
$DamageScale[armorHeadcrab, $ZombieSDamageType] = 1.0;
$DamageScale[armorFheadcrab, $ZombieSDamageType] = 1.0;
$DamageScale[armorFzombie, $ZombieSDamageType] = 1.0;
$DamageScale[armorPheadcrab, $ZombieSDamageType] = 1.0;
$DamageScale[armorCzombie, $ZombieSDamageType] = 1.0;

$ItemMax[armorHuman, ZombieS] = 0;
$ItemMax[armorHuman, ZombieSAmmo] = 0;
$ItemMax[armorHumanF, ZombieS] = 0;
$ItemMax[armorHumanF, ZombieSAmmo] = 0;
$ItemMax[armorZombie, ZombieS] = 1;
$ItemMax[armorZombie, ZombieSAmmo] = 1;
$ItemMax[armorHeadcrab, ZombieS] = 0;
$ItemMax[armorHeadcrab, ZombieSAmmo] = 0;
$ItemMax[armorFheadcrab, ZombieS] = 0;
$ItemMax[armorFheadcrab, ZombieSAmmo] = 0;
$ItemMax[armorFzombie, ZombieS] = 0;
$ItemMax[armorFzombie, ZombieSAmmo] = 0;
$ItemMax[armorPheadcrab, ZombieS] = 0;
$ItemMax[armorPheadcrab, ZombieSAmmo] = 0;
$ItemMax[armorCzombie, ZombieS] = 0;
$ItemMax[armorCzombie, ZombieSAmmo] = 0;

$InvList[ZombieS] = 1;
$RemoteInvList[ZombieS] = 1;
$InvList[ZombieSAmmo] = 1;
$RemoteInvList[ZombieSAmmo] = 1;

//primary
function ZombieSImage::onFire(%this)
{
	//echo("THIS " @ %this);
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "ZombieSAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("ZombieSwing",%trans,%this,%vel);
		%atksound = floor(getRandom() * 3);
		if (%atksound == 0) 
			Projectile::spawnProjectile("SndZombAtk1",%trans,%this,%vel);
		else if (%atksound == 1)
			Projectile::spawnProjectile("SndZombAtk2",%trans,%this,%vel);
      	}	
}

function ZombieS::onDrop(%player,%item)
{
	// do nothing
}	


function ZombieSAmmo::onDrop(%player,%item)
{
	// do nothing
}	

// weapon deathmessages

$deathMsg[$ZombieSDamageType, 0] = "%1 [Zombie] %2";
$deathMsg[$ZombieSDamageType, 1] = "%1 [Zombie] %2";
$deathMsg[$ZombieSDamageType, 2] = "%1 [Zombie] %2";
$deathMsg[$ZombieSDamageType, 3] = "%1 [Zombie] %2";

