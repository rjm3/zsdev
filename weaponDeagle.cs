// Desert Eagle

// projectile data
BulletData DeagleBulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 59.0;
   damageType         = $DeagleDamageType;

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

BulletData DeagleBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 59.0;
   damageType         = $DeagleDamageType;

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

BulletData DeagleBulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 59.0;
   damageType         = $DeagleDamageType;

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

SoundProfileData Profile3dDeagle
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireDeagle
{
   wavFileName = "deagle_fire.wav";
   profile = Profile3dDeagle;
};

// ammo data
ItemData DeagleAmmo
{
	description = "Deagle Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData DeagleImage
{
	shapeFile = "DEAGLE";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = DeagleAmmo;
	accuFire = true;
	reloadTime = 0.165;
	fireTime = 0.05;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireDeagle;
//	sfxActivate = "";
//	sfxReload = "";
};

ItemData Deagle
{
	description = "Desert Eagle";
	className = "Weapon";
	shapeFile = "DEAGLE";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = DeagleImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

ItemData Clip50AE
{
	description = ".50 AE Clip";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

$WeaponAmmo[Deagle] = DeagleAmmo;
$AutoUse[Deagle] = True;
$Use[Deagle] = True;

addWeapon("Deagle");

// dev damage types
$DeagleDamageType = 803;

// dev armors
$DamageScale[armorHuman, $DeagleDamageType] = 1.0;
$DamageScale[armorHumanF, $DeagleDamageType] = 1.0;
$DamageScale[armorZombie, $DeagleDamageType] = 1.0;
$DamageScale[armorHeadcrab, $DeagleDamageType] = 1.0;
$DamageScale[armorFheadcrab, $DeagleDamageType] = 1.0;
$DamageScale[armorFzombie, $DeagleDamageType] = 1.0;
$DamageScale[armorPheadcrab, $DeagleDamageType] = 1.0;
$DamageScale[armorCzombie, $DeagleDamageType] = 1.0;

$ItemMax[armorHuman, Deagle] = 1;
$ItemMax[armorHuman, DeagleAmmo] = 7;
$ItemMax[armorHuman, Clip50AE] = 999999;
$ItemMax[armorHumanF, Deagle] = 1;
$ItemMax[armorHumanF, DeagleAmmo] = 7;
$ItemMax[armorHumanF, Clip50AE] = 999999;
$ItemMax[armorZombie, Deagle] = 0;
$ItemMax[armorZombie, DeagleAmmo] = 0;
$ItemMax[armorZombie, Clip50AE] = 0;
$ItemMax[armorHeadcrab, Deagle] = 0;
$ItemMax[armorHeadcrab, DeagleAmmo] = 0;
$ItemMax[armorHeadcrab, Clip50AE] = 0;
$ItemMax[armorFheadcrab, Deagle] = 0;
$ItemMax[armorFheadcrab, DeagleAmmo] = 0;
$ItemMax[armorFheadcrab, Clip50AE] = 0;
$ItemMax[armorFzombie, Deagle] = 0;
$ItemMax[armorFzombie, DeagleAmmo] = 0;
$ItemMax[armorFzombie, Clip50AE] = 0;
$ItemMax[armorPheadcrab, Deagle] = 0;
$ItemMax[armorPheadcrab, DeagleAmmo] = 0;
$ItemMax[armorPheadcrab, Clip50AE] = 0;
$ItemMax[armorCzombie, Deagle] = 0;
$ItemMax[armorCzombie, DeagleAmmo] = 0;
$ItemMax[armorCzombie, Clip50AE] = 0;

$InvList[Deagle] = 1;
$InvList[DeagleAmmo] = 1;
$RemoteInvList[Deagle] = 1;
$RemoteInvList[DeagleAmmo] = 1;

// base onfire
function DeagleImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"DeagleAmmo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"DeagleAmmo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("DeagleBulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("DeagleBullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("DeagleBulletNR",%trans,%this,%vel);
			Player::trigger(%this, $WeaponSlot, false);
		}
	}
}

function Deagle::onDrop(%player,%item)
{
	// do nothing
}	

function DeagleAmmo::onDrop(%player,%item)
{
	// do nothing
}

function Clip50AE::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$DeagleDamageType, 0] = "%1 [Desert Eagle] %2";
$deathMsg[$DeagleDamageType, 1] = "%1 [Desert Eagle] %2";
$deathMsg[$DeagleDamageType, 2] = "%1 [Desert Eagle] %2";
$deathMsg[$DeagleDamageType, 3] = "%1 [Desert Eagle] %2";

