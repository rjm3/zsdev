// HEAD CRAB BITE
// AND HEAD CRAB PACK

SoundProfileData ProfilePheadcrabHitwall
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};
SoundData SoundPheadcrabHitwall1
{
   wavFileName = "phead_headbite.wav";
   profile = ProfilePheadcrabHitwall;
};
SoundData SoundPheadcrabHitwall2
{
   wavFileName = "phead_headbite2.wav";
   profile = ProfilePheadcrabHitwall;
};
SoundData SoundPheadcrabSpit
{
   wavFileName = "phead_spit.wav";
   profile = ProfilePheadcrabHitwall;
};
SoundData SoundPheadcrabSpitHit
{
   wavFileName = "phead_poshit.wav";
   profile = ProfilePheadcrabHitwall;
};

// explosion data
ExplosionData PheadcrabExp0
{
   shapeName = "chainspk.dts";
   soundId   = SoundPheadcrabHitwall1;
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
ExplosionData PheadcrabExp1
{
   shapeName = "chainspk.dts";
   soundId   = SoundPheadcrabHitwall2;
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
ExplosionData PheadcrabSExp0
{
   shapeName = "chainspk.dts";
   soundId   = SoundPheadcrabSpitHit;
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
BulletData PheadcrabBite
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = PheadcrabExp0;
 	expRandCycle  = 2;

   damageClass        = 0;
   damageValue        = 7.0;
   damageType         = $PheadcrabDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.19;
   liveTime           = 0.19;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
};

GrenadeData PheadcrabSpit
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = PheadcrabSExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.01;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 15.0;
   damageType         = $PheadcrabSDamageType;

   explosionRadius    = 3.2;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 35;
   totalTime          = 2.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.005;
	
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};



//----------------------------------------------------------------------------------
// sound data

SoundProfileData Profile3dPheadcrab
{
   baseVolume = 0;
   minDistance = 1.0;
   maxDistance = 350.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundPheadAtk1
{
   wavFileName = "phead_attack1.wav";
   profile = Profile3dHeadcrab;
};
SoundData SoundPheadAtk2
{
   wavFileName = "phead_attack2.wav";
   profile = Profile3dHeadcrab;
};
SoundData SoundPheadAtk3
{
   wavFileName = "phead_attack3.wav";
   profile = Profile3dHeadcrab;
};

ExplosionData SndPheadAtkExp0
{
   shapeName = "invisable.dts";
   soundId   = SoundPheadAtk1;

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
ExplosionData SndPheadAtkExp1
{
   shapeName = "invisable.dts";
   soundId   = SoundPheadAtk2;

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
ExplosionData SndPheadAtkExp2
{
   shapeName = "invisable.dts";
   soundId   = SoundPheadAtk3;

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

GrenadeData SndPheadAtk1
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndPheadAtkExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $PheadcrabDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};
GrenadeData SndPheadAtk2
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndPheadAtkExp1;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $PheadcrabDamageType;

   explosionRadius    = 1;
   kickBackStrength   = 0;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};
GrenadeData SndPheadAtk3
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = SndPheadAtkExp2;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 0;
   damageType         = $PheadcrabDamageType;

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
ItemData PheadcrabAmmo
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
ItemImageData PheadcrabImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      	mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.82;
	fireTime = 0.1;
      	ammoType = PheadcrabAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = "";
};

ItemData Pheadcrab
{
	description = "Poison Head Crab Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = PheadcrabImage;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

//--------------------------------------------

ItemData PheadcrabSAmmo
{
	description = "Poison Headcrab Spit";
      	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

ItemImageData PheadcrabSImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      	mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 3.1;
	fireTime = 0.1;
      	ammoType = PheadcrabSAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundPheadcrabSpit;
};

ItemData PheadcrabS
{
	description = "Poison Spit Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = PheadcrabSImage;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

$WeaponAmmo[Pheadcrab] = PheadcrabAmmo;
$AutoUse[Pheadcrab]= True;
$Use[Pheadcrab] = True;
$WeaponAmmo[PheadcrabS] = PheadcrabAmmo;
$AutoUse[PheadcrabS]= True;
$Use[PheadcrabS] = True;

addWeapon("Pheadcrab");
addWeapon("PheadcrabS");

// dev damage types
$PheadcrabDamageType = 903;
$PheadcrabSDamageType = 904;

// dev armors
$DamageScale[armorHuman, $PheadcrabDamageType] = 1.0;
$DamageScale[armorHumanF, $PheadcrabDamageType] = 1.0;
$DamageScale[armorZombie, $PheadcrabDamageType] = 1.0;
$DamageScale[armorHeadcrab, $PheadcrabDamageType] = 1.0;
$DamageScale[armorFheadcrab, $PheadcrabDamageType] = 1.0;
$DamageScale[armorFzombie, $PheadcrabDamageType] = 1.0;
$DamageScale[armorPheadcrab, $PheadcrabDamageType] = 1.0;
$DamageScale[armorCzombie, $PheadcrabDamageType] = 1.0;

$DamageScale[armorHuman, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorHumanF, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorZombie, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorHeadcrab, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorFheadcrab, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorFzombie, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorPheadcrab, $PheadcrabSDamageType] = 1.0;
$DamageScale[armorCzombie, $PheadcrabSDamageType] = 1.0;

$ItemMax[armorHuman, Pheadcrab] = 0;
$ItemMax[armorHuman, PheadcrabAmmo] = 0;
$ItemMax[armorHumanF, Pheadcrab] = 0;
$ItemMax[armorHumanF, PheadcrabAmmo] = 0;
$ItemMax[armorZombie, Pheadcrab] = 0;
$ItemMax[armorZombie, PheadcrabAmmo] = 0;
$ItemMax[armorHeadcrab, Pheadcrab] = 0;
$ItemMax[armorHeadcrab, PheadcrabAmmo] = 0;
$ItemMax[armorFheadcrab, Pheadcrab] = 0;
$ItemMax[armorFheadcrab, PheadcrabAmmo] = 0;
$ItemMax[armorFzombie, Pheadcrab] = 0;
$ItemMax[armorFzombie, PheadcrabAmmo] = 0;
$ItemMax[armorPheadcrab, Pheadcrab] = 1;
$ItemMax[armorPheadcrab, PheadcrabAmmo] = 1;
$ItemMax[armorCzombie, Pheadcrab] = 0;
$ItemMax[armorCzombie, PheadcrabAmmo] = 0;

$ItemMax[armorHuman, PheadcrabS] = 0;
$ItemMax[armorHuman, PheadcrabSAmmo] = 0;
$ItemMax[armorHumanF, PheadcrabS] = 0;
$ItemMax[armorHumanF, PheadcrabSAmmo] = 0;
$ItemMax[armorZombie, PheadcrabS] = 0;
$ItemMax[armorZombie, PheadcrabSAmmo] = 0;
$ItemMax[armorHeadcrab, PheadcrabS] = 0;
$ItemMax[armorHeadcrab, PheadcrabSAmmo] = 0;
$ItemMax[armorFheadcrab, PheadcrabS] = 0;
$ItemMax[armorFheadcrab, PheadcrabSAmmo] = 0;
$ItemMax[armorFzombie, PheadcrabS] = 0;
$ItemMax[armorFzombie, PheadcrabSAmmo] = 0;
$ItemMax[armorPheadcrab, PheadcrabS] = 1;
$ItemMax[armorPheadcrab, PheadcrabSAmmo] = 1;
$ItemMax[armorCzombie, PheadcrabS] = 0;
$ItemMax[armorCzombie, PheadcrabSAmmo] = 0;

$InvList[Pheadcrab] = 1;
$RemoteInvList[Pheadcrab] = 1;
$InvList[PheadcrabAmmo] = 1;
$RemoteInvList[PheadcrabAmmo] = 1;

$InvList[PheadcrabS] = 1;
$RemoteInvList[PheadcrabS] = 1;
$InvList[PheadcrabSAmmo] = 1;
$RemoteInvList[PheadcrabSAmmo] = 1;

//primary
function PheadcrabImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "PheadcrabAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("PheadcrabBite",%trans,%this,%vel);
		%atksound = floor(getRandom() * 4);
		if (%atksound == 0) 
			Projectile::spawnProjectile("SndPheadAtk1",%trans,%this,%vel);
		else if (%atksound == 1)
			Projectile::spawnProjectile("SndPheadAtk2",%trans,%this,%vel);
		else if (%atksound == 2)
			Projectile::spawnProjectile("SndPheadAtk3",%trans,%this,%vel);
      	}	
}

function PheadcrabSImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "PheadcrabSAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("PheadcrabSpit",%trans,%this,%vel);
		//p headcrab spit
      	}	
}

function Pheadcrab::onDrop(%player,%item)
{
	// do nothing
}	

function PheadcrabAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$PheadcrabDamageType, 0] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabDamageType, 1] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabDamageType, 2] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabDamageType, 3] = "%1 [Poison Head Crab] %2";

$deathMsg[$PheadcrabSDamageType, 0] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabSDamageType, 1] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabSDamageType, 2] = "%1 [Poison Head Crab] %2";
$deathMsg[$PheadcrabSDamageType, 3] = "%1 [Poison Head Crab] %2";

//----------------------------------------------------------------------------

ItemImageData PheadcrabPackImage
{
	shapeFile = "BCRAB";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0.3, -1.5 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData PheadcrabPack
{
	description = "Poison Head Crab Pack";
	shapeFile = "HCRAB";
	className = "HandAmmo";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = PheadcrabPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape = true;
  	validateMaterials = true;
};

function PheadcrabPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function PheadcrabPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function PheadcrabPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

function PheadcrabPack::onDrop(%player,%item)
{
	// do nothing
}	

$ItemMax[armorHuman, PheadcrabPack] = 0;
$ItemMax[armorHumanF, PheadcrabPack] = 0;
$ItemMax[armorZombie, PheadcrabPack] = 0;
$ItemMax[armorHeadcarb, PheadcrabPack] = 0;
$ItemMax[armorFheadcrab, PheadcrabPack] = 0;
$ItemMax[armorFzombie, PheadcrabPack] = 0;
$ItemMax[armorPheadcrab, PheadcrabPack] = 1;
$ItemMax[armorCzombie, PheadcrabPack] = 0;

//----------------------------------------------------------------------------

