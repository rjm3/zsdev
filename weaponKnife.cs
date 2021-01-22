// Standard Issue Combat Knife
// Slash and Stab techniques
// update November 08, 2002 11:43:21 AM

SoundProfileData ProfileKnifeHitwall
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 100.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundKnifeHitwall
{
   wavFileName = "knife_hitwall.wav";
   profile = ProfileKnifeHitwall;
};

// explosion data
ExplosionData KnifeExp
{
   shapeName = "chainspk.dts";
   soundId   = SoundKnifeHitwall;
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
BulletData KnifeSwing
{
   bulletShapeName    = "invisable.dts";
   explosionTag       = KnifeExp;

   damageClass        = 0;
   damageValue        = 47.0;
   damageType         = $KnifeDamageType;

   muzzleVelocity     = 10.0;
   totalTime          = 0.08;
   liveTime           = 0.08;

   lightRange         = 0.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

};

// sound data
SoundProfileData Profile3dSlash
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 100.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundProfileData Profile3dKnifeDeploy
{
   baseVolume = 0;
   minDistance = 8.0;
   maxDistance = 100.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundSlashKnife
{
   wavFileName = "knife_slash.wav";
   profile = Profile3dSlash;
};

SoundData SoundKnifeDeploy
{
   wavFileName = "knife_deploy.wav";
   profile = Profile3dKnifeDeploy;
};

// ammo data
ItemData KnifeAmmo
{
	description = "Knife Blade";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = false;
};

// weapon data
ItemImageData KnifeImage
{
	shapeFile = "KABAR";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.41;
	fireTime = 0.1;
      ammoType = KnifeAmmo;
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 0.2 };

	sfxActivate = SoundKnifeDeploy;
	sfxFire = SoundSlashKnife;
};

ItemData Knife
{
	description = "S.I. Combat Knife (KA-BAR)";
	className = "Weapon";
	shapeFile = "KABAR";
	hudIcon = "sniper";
      heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = KnifeImage;
	price = 175;
	showWeaponBar = true;
      validateShape = true;
};

$WeaponAmmo[Knife] = KnifeAmmo;
$AutoUse[Knife]= True;
$Use[Knife] = True;

addWeapon("Knife");

// dev damage types
$KnifeDamageType = 804;

// dev armors
$DamageScale[armorHuman, $KnifeDamageType] = 1.0;
$DamageScale[armorHumanF, $KnifeDamageType] = 1.0;
$DamageScale[armorZombie, $KnifeDamageType] = 1.0;
$DamageScale[armorHeadcrab, $KnifeDamageType] = 1.0;
$DamageScale[armorFheadcrab, $KnifeDamageType] = 1.0;
$DamageScale[armorFzombie, $KnifeDamageType] = 1.0;
$DamageScale[armorPheadcrab, $KnifeDamageType] = 1.0;
$DamageScale[armorCzombie, $KnifeDamageType] = 1.0;

$ItemMax[armorHuman, Knife] = 1;
$ItemMax[armorHuman, KnifeAmmo] = 1;
$ItemMax[armorHumanF, Knife] = 1;
$ItemMax[armorHumanF, KnifeAmmo] = 1;
$ItemMax[armorZombie, Knife] = 0;
$ItemMax[armorZombie, KnifeAmmo] = 0;
$ItemMax[armorHeadcrab, Knife] = 0;
$ItemMax[armorHeadcrab, KnifeAmmo] = 0;
$ItemMax[armorFheadcrab, Knife] = 0;
$ItemMax[armorFheadcrab, KnifeAmmo] = 0;
$ItemMax[armorFzombie, Knife] = 0;
$ItemMax[armorFzombie, KnifeAmmo] = 0;
$ItemMax[armorPheadcrab, Knife] = 0;
$ItemMax[armorPheadcrab, KnifeAmmo] = 0;
$ItemMax[armorCzombie, Knife] = 0;
$ItemMax[armorCzombie, KnifeAmmo] = 0;

$InvList[Knife] = 1;
$RemoteInvList[Knife] = 1;
$InvList[KnifeAmmo] = 1;
$RemoteInvList[KnifeAmmo] = 1;

//primary
function KnifeImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
       	%ammo = Player::getItemCount(%client, "KnifeAmmo");
	if(%ammo > 0)
	{
        	%trans = GameBase::getMuzzleTransform(%this);
	     	%vel = Item::getVelocity(%this);
	     	Projectile::spawnProjectile("KnifeSwing",%trans,%this,%vel);
	     	//playSound(SoundSlashKnife,GameBase::getPosition(%this));
      	}
}

function Knife::onDrop(%player,%item)
{
	// do nothing
}	

function KnifeAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$KnifeDamageType, 0] = "%1 [Knife] %2";
$deathMsg[$KnifeDamageType, 1] = "%1 [Knife] %2";
$deathMsg[$KnifeDamageType, 2] = "%1 [Knife] %2";
$deathMsg[$KnifeDamageType, 3] = "%1 [Knife] %2";

