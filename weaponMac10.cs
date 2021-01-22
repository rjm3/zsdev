// Mac-10

// projectile data
BulletData MAC10BulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $MAC10DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0031;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData MAC10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $MAC10DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0072;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData MAC10BulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $MAC10DamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.018;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

// sound data

SoundProfileData Profile3dMAC10
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireMAC10
{
   wavFileName = "mac10_fire.wav";
   profile = Profile3dMAC10;
};

// ammo data
ItemData MAC10Ammo
{
	description = "Mac-10 Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData MAC10Image
{
	shapeFile = "MAC10";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = MAC10Ammo;
	accuFire = true;
	reloadTime = 0.019;
	fireTime = 0.01;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMAC10;
};

ItemData MAC10
{
	description = "Ingram Mac-10";
	className = "Weapon";
	shapeFile = "MAC10";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = MAC10Image;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

ItemData Clip45CAL
{
	description = ".45 CAL Clip";
      	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};


$WeaponAmmo[MAC10] = MAC10Ammo;
$AutoUse[MAC10] = True;
$Use[MAC10] = True;

addWeapon("MAC10");

// dev damage types
$MAC10DamageType = 807;

// dev armors
$DamageScale[armorHuman, $MAC10DamageType] = 1.0;
$DamageScale[armorHumanF, $MAC10DamageType] = 1.0;
$DamageScale[armorZombie, $MAC10DamageType] = 1.0;
$DamageScale[armorHeadcrab, $MAC10DamageType] = 1.0;
$DamageScale[armorFheadcrab, $MAC10DamageType] = 1.0;
$DamageScale[armorFzombie, $MAC10DamageType] = 1.0;
$DamageScale[armorPheadcrab, $MAC10DamageType] = 1.0;
$DamageScale[armorCzombie, $MAC10DamageType] = 1.0;

$ItemMax[armorHuman, MAC10] = 1;
$ItemMax[armorHuman, MAC10Ammo] = 30;
$ItemMax[armorHuman, Clip45CAL] = 999999;
$ItemMax[armorHumanF, MAC10] = 1;
$ItemMax[armorHumanF, MAC10Ammo] = 30;
$ItemMax[armorHumanF, Clip45CAL] = 999999;
$ItemMax[armorZombie, MAC10] = 0;
$ItemMax[armorZombie, MAC10Ammo] = 0;
$ItemMax[armorZombie, Clip45CAL] = 0;
$ItemMax[armorHeadcrab, MAC10] = 0;
$ItemMax[armorHeadcrab, MAC10Ammo] = 0;
$ItemMax[armorHeadcrab, Clip45CAL] = 0;
$ItemMax[armorFheadcrab, MAC10] = 0;
$ItemMax[armorFheadcrab, MAC10Ammo] = 0;
$ItemMax[armorFheadcrab, Clip45CAL] = 0;
$ItemMax[armorFzombie, MAC10] = 0;
$ItemMax[armorFzombie, MAC10Ammo] = 0;
$ItemMax[armorFzombie, Clip45CAL] = 0;
$ItemMax[armorPheadcrab, MAC10] = 0;
$ItemMax[armorPheadcrab, MAC10Ammo] = 0;
$ItemMax[armorPheadcrab, Clip45CAL] = 0;
$ItemMax[armorCzombie, MAC10] = 0;
$ItemMax[armorCzombie, MAC10Ammo] = 0;
$ItemMax[armorCzombie, Clip45CAL] = 0;

$InvList[MAC10] = 1;
$InvList[MAC10Ammo] = 1;
$RemoteInvList[MAC10] = 1;
$RemoteInvList[MAC10Ammo] = 1;

// base onfire
function MAC10Image::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"MAC10Ammo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"MAC10Ammo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("MAC10BulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("MAC10Bullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("MAC10BulletNR",%trans,%this,%vel);
		}
	}
}

function MAC10::onDrop(%player,%item)
{
	// do nothing
}	

function MAC10Ammo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$MAC10DamageType, 0] = "%1 [Mac-10] %2";
$deathMsg[$MAC10DamageType, 1] = "%1 [Mac-10] %2";
$deathMsg[$MAC10DamageType, 2] = "%1 [Mac-10] %2";
$deathMsg[$MAC10DamageType, 3] = "%1 [Mac-10] %2";

