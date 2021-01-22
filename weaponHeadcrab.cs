// HEAD CRAB BITE
// AND HEAD CRAB PACK

SoundProfileData ProfileHeadcrabHitwall
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};
SoundData SoundHeadcrabHitwall1
{
   wavFileName = "head_headbite.wav";
   profile = ProfileHeadcrabHitwall;
};

// explosion data
ExplosionData HeadcrabExp0
{
   shapeName = "chainspk.dts";
   soundId   = SoundHeadcrabHitwall1;
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
BulletData HeadcrabBite
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = HeadcrabExp0;

   damageClass        = 0;
   damageValue        = 8.0;
   damageType         = $HeadcrabDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.19;
   liveTime           = 0.19;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
};

//----------------------------------------------------------------------------------
// sound data

SoundProfileData Profile3dHeadcrab
{
   baseVolume = 0;
   minDistance = 1.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundHeadAtk1
{
   wavFileName = "head_attack1.wav";
   profile = Profile3dHeadcrab;
};
SoundData SoundHeadAtk2
{
   wavFileName = "head_attack2.wav";
   profile = Profile3dHeadcrab;
};
SoundData SoundHeadAtk3
{
   wavFileName = "head_attack3.wav";
   profile = Profile3dHeadcrab;
};

ExplosionData SndHeadAtkExp0
{
   shapeName = "invisable.dts";
   soundId   = SoundHeadAtk1;

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
ExplosionData SndHeadAtkExp1
{
   shapeName = "invisable.dts";
   soundId   = SoundHeadAtk2;

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
ExplosionData SndHeadAtkExp2
{
   shapeName = "invisable.dts";
   soundId   = SoundHeadAtk3;

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

GrenadeData SndHeadAtk1
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndHeadAtkExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $HeadcrabDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};
GrenadeData SndHeadAtk2
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndHeadAtkExp1;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $HeadcrabDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};
GrenadeData SndHeadAtk3
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndHeadAtkExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $HeadcrabDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

//----------------------------------------------------------------------------------

// ammo data
ItemData HeadcrabAmmo
{
	description = "Head Crab Teeth";
      	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData HeadcrabImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      	mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.52;
	fireTime = 0.1;
      	ammoType = HeadcrabAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = "";
};

ItemData Headcrab
{
	description = "Head Crab Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = HeadcrabImage;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

$WeaponAmmo[Headcrab] = HeadcrabAmmo;
$AutoUse[Headcrab]= True;
$Use[Headcrab] = True;

addWeapon("Headcrab");

// dev damage types
$HeadcrabDamageType = 901;

// dev armors
$DamageScale[armorHuman, $HeadcrabDamageType] = 1.0;
$DamageScale[armorHumanF, $HeadcrabDamageType] = 1.0;
$DamageScale[armorZombie, $HeadcrabDamageType] = 1.0;
$DamageScale[armorHeadcrab, $HeadcrabDamageType] = 1.0;
$DamageScale[armorFheadcrab, $HeadcrabDamageType] = 1.0;
$DamageScale[armorFzombie, $HeadcrabDamageType] = 1.0;
$DamageScale[armorPheadcrab, $HeadcrabDamageType] = 1.0;
$DamageScale[armorCzombie, $HeadcrabDamageType] = 1.0;

$ItemMax[armorHuman, Headcrab] = 0;
$ItemMax[armorHuman, HeadcrabAmmo] = 0;
$ItemMax[armorHumanF, Headcrab] = 0;
$ItemMax[armorHumanF, HeadcrabAmmo] = 0;
$ItemMax[armorZombie, Headcrab] = 0;
$ItemMax[armorZombie, HeadcrabAmmo] = 0;
$ItemMax[armorHeadcrab, Headcrab] = 1;
$ItemMax[armorHeadcrab, HeadcrabAmmo] = 1;
$ItemMax[armorFheadcrab, Headcrab] = 1;
$ItemMax[armorFheadcrab, HeadcrabAmmo] = 1;
$ItemMax[armorFzombie, Headcrab] = 0;
$ItemMax[armorFzombie, HeadcrabAmmo] = 0;
$ItemMax[armorPheadcrab, Headcrab] = 1;
$ItemMax[armorPheadcrab, HeadcrabAmmo] = 1;
$ItemMax[armorCzombie, Headcrab] = 0;
$ItemMax[armorCzombie, HeadcrabAmmo] = 0;

$InvList[Headcrab] = 1;
$RemoteInvList[Headcrab] = 1;
$InvList[HeadcrabAmmo] = 1;
$RemoteInvList[HeadcrabAmmo] = 1;

//primary
function HeadcrabImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "HeadcrabAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("HeadcrabBite",%trans,%this,%vel);
		%atksound = floor(getRandom() * 4);
		if (%atksound == 0) 
			Projectile::spawnProjectile("SndHeadAtk1",%trans,%this,%vel);
		else if (%atksound == 1)
			Projectile::spawnProjectile("SndHeadAtk2",%trans,%this,%vel);
		else if (%atksound == 2)
			Projectile::spawnProjectile("SndHeadAtk3",%trans,%this,%vel);
      	}	
}

function Headcrab::onDrop(%player,%item)
{
	// do nothing
}	

function HeadcrabAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$HeadcrabDamageType, 0] = "%1 [Head Crab] %2";
$deathMsg[$HeadcrabDamageType, 1] = "%1 [Head Crab] %2";
$deathMsg[$HeadcrabDamageType, 2] = "%1 [Head Crab] %2";
$deathMsg[$HeadcrabDamageType, 3] = "%1 [Head Crab] %2";

//----------------------------------------------------------------------------

ItemImageData HeadcrabPackImage
{
	shapeFile = "HCRAB";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0.3, -1.5 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData HeadcrabPack
{
	description = "Head Crab Pack";
	shapeFile = "HCRAB";
	className = "HandAmmo";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = HeadcrabPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape = true;
  	validateMaterials = true;
};

function HeadcrabPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function HeadcrabPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function HeadcrabPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

function HeadcrabPack::onDrop(%player,%item)
{
	// do nothing
}	

$ItemMax[armorHuman, HeadcrabPack] = 0;
$ItemMax[armorHumanF, HeadcrabPack] = 0;
$ItemMax[armorZombie, HeadcrabPack] = 0;
$ItemMax[armorHeadcrab, HeadcrabPack] = 1;
$ItemMax[armorFheadcrab, HeadcrabPack] = 1;
$ItemMax[armorFzombie, HeadcrabPack] = 0;
$ItemMax[armorPheadcrab, HeadcrabPack] = 0;
$ItemMax[armorCzombie, HeadcrabPack] = 0;

//----------------------------------------------------------------------------

