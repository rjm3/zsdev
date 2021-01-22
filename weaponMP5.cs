// MP5

// projectile data
BulletData MP5BulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 19.0;
   damageType         = $MP5DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0028;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData MP5Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 19.0;
   damageType         = $MP5DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0068;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData MP5BulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 19.0;
   damageType         = $MP5DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.011;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

// sound data

SoundProfileData Profile3dMP5
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireMP5
{
   wavFileName = "mp5_fire.wav";
   profile = Profile3dMP5;
};

// ammo data
ItemData MP5Ammo
{
	description = "MP5 Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData MP5Image
{
	shapeFile = "MP5";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = MP5Ammo;
	accuFire = true;
	reloadTime = 0.032;
	fireTime = 0.01;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMP5;
};

ItemData MP5
{
	description = "MP5";
	className = "Weapon";
	shapeFile = "MP5";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = MP5Image;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

//
// CLIP 9MM
//

$WeaponAmmo[MP5] = MP5Ammo;
$AutoUse[MP5] = True;
$Use[MP5] = True;

addWeapon("MP5");

// dev damage types
$MP5DamageType = 806;

// dev armors
$DamageScale[armorHuman, $MP5DamageType] = 1.0;
$DamageScale[armorHumanF, $MP5DamageType] = 1.0;
$DamageScale[armorZombie, $MP5DamageType] = 1.0;
$DamageScale[armorHeadcrab, $MP5DamageType] = 1.0;
$DamageScale[armorFheadcrab, $MP5DamageType] = 1.0;
$DamageScale[armorFzombie, $MP5DamageType] = 1.0;
$DamageScale[armorPheadcrab, $MP5DamageType] = 1.0;
$DamageScale[armorCzombie, $MP5DamageType] = 1.0;

$ItemMax[armorHuman, MP5] = 1;
$ItemMax[armorHuman, MP5Ammo] = 30;
$ItemMax[armorHumanF, MP5] = 1;
$ItemMax[armorHumanF, MP5Ammo] = 30;
$ItemMax[armorZombie, MP5] = 0;
$ItemMax[armorZombie, MP5Ammo] = 0;
$ItemMax[armorHeadcrab, MP5] = 0;
$ItemMax[armorHeadcrab, MP5Ammo] = 0;
$ItemMax[armorFheadcrab, MP5] = 0;
$ItemMax[armorFheadcrab, MP5Ammo] = 0;
$ItemMax[armorFzombie, MP5] = 0;
$ItemMax[armorFzombie, MP5Ammo] = 0;
$ItemMax[armorPheadcrab, MP5] = 0;
$ItemMax[armorPheadcrab, MP5Ammo] = 0;
$ItemMax[armorCzombie, MP5] = 0;
$ItemMax[armorCzombie, MP5Ammo] = 0;

$InvList[MP5] = 1;
$InvList[MP5Ammo] = 1;
$RemoteInvList[MP5] = 1;
$RemoteInvList[MP5Ammo] = 1;

// base onfire
function MP5Image::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"MP5Ammo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"MP5Ammo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("MP5BulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("MP5Bullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("MP5BulletNR",%trans,%this,%vel);
		}
	}
}

function MP5::onDrop(%player,%item)
{
	// do nothing
}	

function MP5Ammo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$MP5DamageType, 0] = "%1 [MP5] %2";
$deathMsg[$MP5DamageType, 1] = "%1 [MP5] %2";
$deathMsg[$MP5DamageType, 2] = "%1 [MP5] %2";
$deathMsg[$MP5DamageType, 3] = "%1 [MP5] %2";

