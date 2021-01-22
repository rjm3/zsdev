// FiveseveN

ExplosionData BasicExp0
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData BasicExp1
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData BasicExp2
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;
   validateShape = true;
   validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 1.0;

   timeZero = 0.200;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

//-----------------------------------------------------------------------------------------------------

// projectile data
BulletData FiveBulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $FivesevenDamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.004;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData FiveBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $FivesevenDamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.008;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData FiveBulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $FivesevenDamageType;

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

// sound data

SoundProfileData Profile3dFiveseven
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireFiveseven
{
   wavFileName = "fiveseven_fire.wav";
   profile = Profile3dFiveseven;
};

// ammo data
ItemData FivesevenAmmo
{
	description = "Fiveseven Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData FivesevenImage
{
	shapeFile = "FIVESEVEN";
	mountPoint = 0;
      	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = FivesevenAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.05;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireFiveseven;
};

ItemData Fiveseven
{
	description = "FN FiveseveN";
	className = "Weapon";
	shapeFile = "FIVESEVEN";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = FivesevenImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

ItemData Clip57MM
{
	description = "5.7MM Clip";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

$WeaponAmmo[Fiveseven] = FivesevenAmmo;
$AutoUse[Fiveseven] = True;
$Use[Fiveseven] = True;

addWeapon("Fiveseven");

// dev damage types
$FivesevenDamageType = 800;

// dev armors
$DamageScale[armorHuman, $FivesevenDamageType] = 1.0;
$DamageScale[armorHumanF, $FivesevenDamageType] = 1.0;
$DamageScale[armorZombie, $FivesevenDamageType] = 1.0;
$DamageScale[armorHeadcrab, $FivesevenDamageType] = 1.0;
$DamageScale[armorFheadcrab, $FivesevenDamageType] = 1.0;
$DamageScale[armorFzombie, $FivesevenDamageType] = 1.0;
$DamageScale[armorPheadcrab, $FivesevenDamageType] = 1.0;
$DamageScale[armorCzombie, $FivesevenDamageType] = 1.0;

$ItemMax[armorHuman, Fiveseven] = 1;
$ItemMax[armorHuman, FivesevenAmmo] = 20;
$ItemMax[armorHuman, Clip57MM] = 999999;
$ItemMax[armorHumanF, Fiveseven] = 1;
$ItemMax[armorHumanF, FivesevenAmmo] = 20;
$ItemMax[armorHumanF, Clip57MM] = 999999;
$ItemMax[armorZombie, Fiveseven] = 0;
$ItemMax[armorZombie, FivesevenAmmo] = 0;
$ItemMax[armorZombie, Clip57MM] = 0;
$ItemMax[armorHeadcrab, Fiveseven] = 0;
$ItemMax[armorHeadcrab, FivesevenAmmo] = 0;
$ItemMax[armorHeadcrab, Clip57MM] = 0;
$ItemMax[armorFheadcrab, Fiveseven] = 0;
$ItemMax[armorFheadcrab, FivesevenAmmo] = 0;
$ItemMax[armorFheadcrab, Clip57MM] = 0;
$ItemMax[armorFzombie, Fiveseven] = 0;
$ItemMax[armorFzombie, FivesevenAmmo] = 0;
$ItemMax[armorFzombie, Clip57MM] = 0;

$InvList[Fiveseven] = 1;
$InvList[FivesevenAmmo] = 1;
$RemoteInvList[Fiveseven] = 1;
$RemoteInvList[FivesevenAmmo] = 1;

// base onfire
function FivesevenImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"FivesevenAmmo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"FivesevenAmmo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("FiveBulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("FiveBullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("FiveBulletNR",%trans,%this,%vel);
			Player::trigger(%this, $WeaponSlot, false);
		}
	}
}

function Fiveseven::onDrop(%player,%item)
{
	// do nothing
}	

function FivesevenAmmo::onDrop(%player,%item)
{
	// do nothing
}

function Clip57MM::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$FivesevenDamageType, 0] = "%1 [FiveseveN] %2";
$deathMsg[$FivesevenDamageType, 1] = "%1 [FiveseveN] %2";
$deathMsg[$FivesevenDamageType, 2] = "%1 [FiveseveN] %2";
$deathMsg[$FivesevenDamageType, 3] = "%1 [FiveseveN] %2";

