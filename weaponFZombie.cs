// ZOMBIE ATTACK

// explosion data
ExplosionData FzombieSExp0
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
ExplosionData FzombieSExp1
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
ExplosionData FzombieSExp2
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
BulletData FzombieSwing
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = FzombieSExp0;
   expRandCycle       = 3;

   damageClass        = 0;
   damageValue        = 8.0;
   damageType         = $FzombieSDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.18;
   liveTime           = 0.18;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

};

// ammo data
ItemData FzombieSAmmo
{
	description = "Fast Zombie Claw";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData FzombieSImage
{
	shapeFile = "invisable";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.37;
	fireTime = 0.1;
      ammoType = FzombieSAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundZombieSwing;
};

ItemData FzombieS
{
	description = "Fast Zombie Attack";
	className = "Weapon";
	shapeFile = "invisable";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = FzombieSImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

$WeaponAmmo[FzombieS] = FzombieSAmmo;
$AutoUse[FzombieS]= True;
$Use[FzombieS] = True;

addWeapon("FzombieS");

// dev damage types
$FzombieSDamageType = 902;

// dev armors
$DamageScale[armorHuman, $FzombieSDamageType] = 1.0;
$DamageScale[armorHumanF, $FzombieSDamageType] = 1.0;
$DamageScale[armorZombie, $FzombieSDamageType] = 1.0;
$DamageScale[armorHeadcrab, $FzombieSDamageType] = 1.0;
$DamageScale[armorFheadcrab, $FzombieSDamageType] = 1.0;
$DamageScale[armorFzombie, $FzombieSDamageType] = 1.0;
$DamageScale[armorPheadcrab, $FzombieSDamageType] = 1.0;
$DamageScale[armorCzombie, $FzombieSDamageType] = 1.0;

$ItemMax[armorHuman, FzombieS] = 0;
$ItemMax[armorHuman, FzombieSAmmo] = 0;
$ItemMax[armorHumanF, FzombieS] = 0;
$ItemMax[armorHumanF, FzombieSAmmo] = 0;
$ItemMax[armorZombie, FzombieS] = 0;
$ItemMax[armorZombie, FzombieSAmmo] = 0;
$ItemMax[armorHeadcrab, FzombieS] = 0;
$ItemMax[armorHeadcrab, FzombieSAmmo] = 0;
$ItemMax[armorFheadcrab, FzombieS] = 0;
$ItemMax[armorFheadcrab, FzombieSAmmo] = 0;
$ItemMax[armorFzombie, FzombieS] = 1;
$ItemMax[armorFzombie, FzombieSAmmo] = 1;
$ItemMax[armorPheadcrab, FzombieS] = 0;
$ItemMax[armorPheadcrab, FzombieSAmmo] = 0;
$ItemMax[armorCzombie, FzombieS] = 0;
$ItemMax[armorCzombie, FzombieSAmmo] = 0;

$InvList[FzombieS] = 1;
$RemoteInvList[FzombieS] = 1;
$InvList[FzombieSAmmo] = 1;
$RemoteInvList[FzombieSAmmo] = 1;

//primary
function FzombieSImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "FzombieSAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("FzombieSwing",%trans,%this,%vel);
		%atksound = floor(getRandom() * 3);
		//if (%atksound == 0) 
		//	Projectile::spawnProjectile("SndZombAtk1",%trans,%this,%vel);
		//else if (%atksound == 1)
		//	Projectile::spawnProjectile("SndZombAtk2",%trans,%this,%vel);
      	}	
}

function FzombieS::onDrop(%player,%item)
{
	// do nothing
}	

function FzombieSAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$FzombieSDamageType, 0] = "%1 [Fast Zombie] %2";
$deathMsg[$FzombieSDamageType, 1] = "%1 [Fast Zombie] %2";
$deathMsg[$FzombieSDamageType, 2] = "%1 [Fast Zombie] %2";
$deathMsg[$FzombieSDamageType, 3] = "%1 [Fast Zombie] %2";

