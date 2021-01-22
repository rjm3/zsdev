// M1014

// projectile data
BulletData M1014BulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 28.0;
   damageType         = $M1014DamageType;

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

BulletData M1014Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 28.0;
   damageType         = $M1014DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.025;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData M1014BulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 28.0;
   damageType         = $M1014DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.029;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

// sound data

SoundProfileData Profile3dM1014
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireM1014
{
   wavFileName = "m1014_fire.wav";
   profile = Profile3dM1014;
};

// ammo data
ItemData M1014Ammo
{
	description = "M1014 Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData M1014Image
{
	shapeFile = "M1014";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = M1014Ammo;
	accuFire = true;
	reloadTime = 0.372;
	fireTime = 0.05;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireM1014;
};

ItemData M1014
{
	description = "M1014 Auto Shotgun";
	className = "Weapon";
	shapeFile = "M1014";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = M1014Image;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};


ItemData Clip00Buck
{
	description = "3in 00 Buck Shells";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

$WeaponAmmo[M1014] = M1014Ammo;
$AutoUse[M1014] = True;
$Use[M1014] = True;

addWeapon("M1014");

// dev damage types
$M1014DamageType = 808;

// dev armors
$DamageScale[armorHuman, $M1014DamageType] = 1.0;
$DamageScale[armorHumanF, $M1014DamageType] = 1.0;
$DamageScale[armorZombie, $M1014DamageType] = 1.0;
$DamageScale[armorHeadcrab, $M1014DamageType] = 1.0;
$DamageScale[armorFheadcrab, $M1014DamageType] = 1.0;
$DamageScale[armorFzombie, $M1014DamageType] = 1.0;
$DamageScale[armorPheadcrab, $M1014DamageType] = 1.0;
$DamageScale[armorCzombie, $M1014DamageType] = 1.0;

$ItemMax[armorHuman, M1014] = 1;
$ItemMax[armorHuman, M1014Ammo] = 7;
$ItemMax[armorHuman, Clip00Buck] = 999999;
$ItemMax[armorHumanF, M1014] = 1;
$ItemMax[armorHumanF, M1014Ammo] = 7;
$ItemMax[armorHumanF, Clip00Buck] = 999999;
$ItemMax[armorZombie, M1014] = 0;
$ItemMax[armorZombie, M1014Ammo] = 0;
$ItemMax[armorZombie, Clip00Buck] = 0;
$ItemMax[armorHeadcrab, M1014] = 0;
$ItemMax[armorHeadcrab, M1014Ammo] = 0;
$ItemMax[armorHeadcrab, Clip00Buck] = 0;
$ItemMax[armorFheadcrab, M1014] = 0;
$ItemMax[armorFheadcrab, M1014Ammo] = 0;
$ItemMax[armorFheadcrab, Clip00Buck] = 0;
$ItemMax[armorFzombie, M1014] = 0;
$ItemMax[armorFzombie, M1014Ammo] = 0;
$ItemMax[armorFzombie, Clip00Buck] = 0;
$ItemMax[armorPheadcrab, M1014] = 0;
$ItemMax[armorPheadcrab, M1014Ammo] = 0;
$ItemMax[armorPheadcrab, Clip00Buck] = 0;
$ItemMax[armorCzombie, M1014] = 0;
$ItemMax[armorCzombie, M1014Ammo] = 0;
$ItemMax[armorCzombie, Clip00Buck] = 0;

$InvList[M1014] = 1;
$InvList[M1014Ammo] = 1;
$RemoteInvList[M1014] = 1;
$RemoteInvList[M1014Ammo] = 1;

// base onfire
function M1014Image::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"M1014Ammo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"M1014Ammo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True") {
					for (%i = 0; %i <= 7; %i++) {
						Projectile::spawnProjectile("M1014BulletC",%trans,%this,%vel);
					}
				}
				else {
					for (%i = 0; %i <= 7; %i++) {
						Projectile::spawnProjectile("M1014Bullet",%trans,%this,%vel);
					}
				}
			else {
				for (%i = 0; %i <= 7; %i++) {
					Projectile::spawnProjectile("M1014BulletNR",%trans,%this,%vel);
				}
			}
			Player::trigger(%this, $WeaponSlot, false);
		}
	}
}

function M1014::onDrop(%player,%item)
{
	// do nothing
}	

function M1014Ammo::onDrop(%player,%item)
{
	// do nothing
}

function Clip50AE::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$M1014DamageType, 0] = "%1 [M1014] %2";
$deathMsg[$M1014DamageType, 1] = "%1 [M1014] %2";
$deathMsg[$M1014DamageType, 2] = "%1 [M1014] %2";
$deathMsg[$M1014DamageType, 3] = "%1 [M1014] %2";

