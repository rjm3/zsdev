// SIG SAUER P228

// projectile data
BulletData P228BulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 30.0;
   damageType         = $P228DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0037;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData P228Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 30.0;
   damageType         = $P228DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0078;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData P228BulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 30.0;
   damageType         = $P228DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.021;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

// sound data

SoundProfileData Profile3dP228
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireP228
{
   wavFileName = "p228_fire.wav";
   profile = Profile3dP228;
};

// ammo data
ItemData P228Ammo
{
	description = "P228 Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData P228Image
{
	shapeFile = "P228S";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = P228Ammo;
	accuFire = true;
	reloadTime = 0.12;
	fireTime = 0.05;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireP228;
};

ItemData P228
{
	description = "SIG P228";
	className = "Weapon";
	shapeFile = "P228S";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = P228Image;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

// CLIP 9MM

$WeaponAmmo[P228] = P228Ammo;
$AutoUse[P228] = True;
$Use[P228] = True;

addWeapon("P228");

// dev damage types
$P228DamageType = 801;

// dev armors
$DamageScale[armorHuman, $P228DamageType] = 1.0;
$DamageScale[armorHumanF, $P228DamageType] = 1.0;
$DamageScale[armorZombie, $P228DamageType] = 1.0;
$DamageScale[armorHeadcrab, $P228DamageType] = 1.0;
$DamageScale[armorFheadcrab, $P228DamageType] = 1.0;
$DamageScale[armorFzombie, $P228DamageType] = 1.0;
$DamageScale[armorPheadcrab, $P228DamageType] = 1.0;
$DamageScale[armorCzombie, $P228DamageType] = 1.0;

$ItemMax[armorHuman, P228] = 1;
$ItemMax[armorHuman, P228Ammo] = 15;
$ItemMax[armorHumanF, P228] = 1;
$ItemMax[armorHumanF, P228Ammo] = 15;
$ItemMax[armorZombie, P228] = 0;
$ItemMax[armorZombie, P228Ammo] = 0;
$ItemMax[armorHeadcrab, P228] = 0;
$ItemMax[armorHeadcrab, P228Ammo] = 0;
$ItemMax[armorFheadcrab, P228] = 0;
$ItemMax[armorFheadcrab, P228Ammo] = 0;
$ItemMax[armorFzombie, P228] = 0;
$ItemMax[armorFzombie, P228Ammo] = 0;
$ItemMax[armorPheadcrab, P228] = 0;
$ItemMax[armorPheadcrab, P228Ammo] = 0;
$ItemMax[armorCzombie, P228] = 0;
$ItemMax[armorCzombie, P228Ammo] = 0;

$InvList[P228] = 1;
$InvList[P228Ammo] = 1;
$RemoteInvList[P228] = 1;
$RemoteInvList[P228Ammo] = 1;

// base onfire
function P228Image::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"P228Ammo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"P228Ammo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("P228BulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("P228Bullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("P228BulletNR",%trans,%this,%vel);
			Player::trigger(%this, $WeaponSlot, false);
		}
	}
}

function P228::onDrop(%player,%item)
{
	// do nothing
}	

function P228Ammo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$P228DamageType, 0] = "%1 [P228] %2";
$deathMsg[$P228DamageType, 1] = "%1 [P228] %2";
$deathMsg[$P228DamageType, 2] = "%1 [P228] %2";
$deathMsg[$P228DamageType, 3] = "%1 [P228] %2";

