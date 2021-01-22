// Berretta 92FS

// explosion data
ExplosionData BerettaExp0
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

ExplosionData BerettaExp1
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

ExplosionData BerettaExp2
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

// projectile data
BulletData BerettaBulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BerettaExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $BerettaDamageType;

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

BulletData BerettaBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BerettaExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $BerettaDamageType;

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

BulletData BerettaBulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BerettaExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 20.0;
   damageType         = $BerettaDamageType;

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

SoundProfileData Profile3dBeretta
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireBeretta
{
   wavFileName = "beretta_fire.wav";
   profile = Profile3dBeretta;
};

// ammo data
ItemData BerettaAmmo
{
	description = "Beretta Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData BerettaImage
{
	shapeFile = "B92FS2";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = BerettaAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireBeretta;
//	sfxActivate = "";
//	sfxReload = "";
};

ItemData Beretta
{
	description = "Beretta 92FS";
	className = "Weapon";
	shapeFile = "B92FS2";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = BerettaImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

ItemData Clip9MM
{
	description = "9MM Clip";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

$WeaponAmmo[Beretta] = BerettaAmmo;
$AutoUse[Beretta] = True;
$Use[Beretta] = True;

addWeapon("Beretta");

// dev damage types
$BerettaDamageType = 800;

// dev armors
$DamageScale[armorHuman, $BerettaDamageType] = 1.0;
$DamageScale[armorZombie, $BerettaDamageType] = 1.0;

$ItemMax[armorHuman, Beretta] = 1;
$ItemMax[armorHuman, BerettaAmmo] = 17;
$ItemMax[armorHuman, Clip9MM] = 999999;
$ItemMax[armorZombie, Beretta] = 0;
$ItemMax[armorZombie, BerettaAmmo] = 0;
$ItemMax[armorZombie, Clip9MM] = 0;

$InvList[Beretta] = 1;
$InvList[BerettaAmmo] = 1;
$RemoteInvList[Beretta] = 1;
$RemoteInvList[BerettaAmmo] = 1;

// base onfire
function BerettaImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%ammo = Player::getItemCount(%client,"BerettaAmmo");
		if(%ammo > 0) {
		 	Player::decItemCount(%client,"BerettaAmmo");
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			if (GameBase::IsAtRest(%client) == "True")
				if (Player::isCrouching(%client) == "True")
					Projectile::spawnProjectile("BerettaBulletC",%trans,%this,%vel);
				else
					Projectile::spawnProjectile("BerettaBullet",%trans,%this,%vel);
			else
				Projectile::spawnProjectile("BerettaBulletNR",%trans,%this,%vel);
		}
}

// weapon deathmessages

$deathMsg[$BerettaDamageType, 0] = "%1 [92FS] %2";
$deathMsg[$BerettaDamageType, 1] = "%1 [92FS] %2";
$deathMsg[$BerettaDamageType, 2] = "%1 [92FS] %2";
$deathMsg[$BerettaDamageType, 3] = "%1 [92FS] %2";

