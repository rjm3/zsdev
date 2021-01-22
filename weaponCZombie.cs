// CHEM ZOMBIE ATTACK

SoundProfileData ProfileCzombieExp
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 1500.0;
   flags = SFX_IS_HARDWARE_3D;
};
SoundData SoundCzombieExp
{
   wavFileName = "chem_explode.wav";
   profile = ProfileCzombieExp;
};

// explosion data
ExplosionData CzombieEExp0
{
   shapeName = "mortarex.dts";
   soundId   = SoundCzombieExp;
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

GrenadeData CzombieExplode
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = CzombieEExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 50;
   collisionRadius    = 0.1;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;
   damageValue        = 68;
   damageType         = $CzombieSDamageType;

   explosionRadius    = 6.47;
   kickBackStrength   = 220;
   maxLevelFlightDist = 1;
   totalTime          = 0.01;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   
   smokeName              = "invisable.dts";
};

// projectile data
BulletData CzombieSwing
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = FzombieSExp0;
   expRandCycle       = 3;

   damageClass        = 0;
   damageValue        = 8.0;
   damageType         = $CzombieSDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.19;
   liveTime           = 0.19;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

};

// ammo data
ItemData CzombieSAmmo
{
	description = "Chem Zombie Claw";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData CzombieSImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 2.16;
	fireTime = 0.1;
      ammoType = CzombieSAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundZombieSwing;
};

ItemData CzombieS
{
	description = "Chem Zombie Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = CzombieSImage;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

$WeaponAmmo[CzombieS] = CzombieSAmmo;
$AutoUse[CzombieS]= True;
$Use[CzombieS] = True;

addWeapon("CzombieS");

// dev damage types
$CzombieSDamageType = 905;

// dev armors
$DamageScale[armorHuman, $CzombieSDamageType] = 1.0;
$DamageScale[armorHumanF, $CzombieSDamageType] = 1.0;
$DamageScale[armorZombie, $CzombieSDamageType] = 1.0;
$DamageScale[armorHeadcrab, $CzombieSDamageType] = 1.0;
$DamageScale[armorFheadcrab, $CzombieSDamageType] = 1.0;
$DamageScale[armorFzombie, $CzombieSDamageType] = 1.0;
$DamageScale[armorPheadcrab, $CzombieSDamageType] = 1.0;
$DamageScale[armorCzombie, $CzombieSDamageType] = 1.0;

$ItemMax[armorHuman, CzombieS] = 0;
$ItemMax[armorHuman, CzombieSAmmo] = 0;
$ItemMax[armorHumanF, CzombieS] = 0;
$ItemMax[armorHumanF, CzombieSAmmo] = 0;
$ItemMax[armorZombie, CzombieS] = 0;
$ItemMax[armorZombie, CzombieSAmmo] = 0;
$ItemMax[armorHeadcrab, CzombieS] = 0;
$ItemMax[armorHeadcrab, CzombieSAmmo] = 0;
$ItemMax[armorFheadcrab, CzombieS] = 0;
$ItemMax[armorFheadcrab, CzombieSAmmo] = 0;
$ItemMax[armorFzombie, CzombieS] = 1;
$ItemMax[armorFzombie, CzombieSAmmo] = 1;
$ItemMax[armorPheadcrab, CzombieS] = 0;
$ItemMax[armorPheadcrab, CzombieSAmmo] = 0;
$ItemMax[armorCzombie, CzombieS] = 0;
$ItemMax[armorCzombie, CzombieSAmmo] = 0;

$InvList[CzombieS] = 1;
$RemoteInvList[CzombieS] = 1;
$InvList[CzombieSAmmo] = 1;
$RemoteInvList[CzombieSAmmo] = 1;

//primary
function CzombieSImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "CzombieSAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("CzombieSwing",%trans,%this,%vel);
      	}	
}

function CzombieS::onDrop(%player,%item)
{
	// do nothing
}	

function CzombieSAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$CzombieSDamageType, 0] = "%1 [Chemical Zombie] %2";
$deathMsg[$CzombieSDamageType, 1] = "%1 [Chemical Zombie] %2";
$deathMsg[$CzombieSDamageType, 2] = "%1 [Chemical Zombie] %2";
$deathMsg[$CzombieSDamageType, 3] = "%1 [Chemical Zombie] %2";

