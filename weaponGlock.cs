// GLOCK 17

// projectile data
BulletData GlockBulletC
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $GlockDamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0021;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData GlockBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $GlockDamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.0049;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

BulletData GlockBulletNR
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = BasicExp0;
   expRandCycle       = 3;
   damageClass        = 0;
   damageValue        = 22.0;
   damageType         = $GlockDamageType;

   muzzleVelocity     = 400.0;
   terminalVelocity   = 400.0;

   aimDeflection      = 0.009;
   totalTime          = 0.15;
   liveTime           = 0.3;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 10;
  
   bulletholeindex    = 1;
};

// sound data

SoundProfileData Profile3dGlock
{
   baseVolume = 0;
   minDistance = 5.0;
   maxDistance = 1600.0;
   flags = SFX_IS_HARDWARE_3D;
};

SoundData SoundFireGlock
{
   wavFileName = "glock_fire.wav";
   profile = Profile3dGlock;
};

// ammo data
ItemData GlockAmmo
{
	description = "Glock Ammuntion";
      heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
	showInventory = true;
};

// weapon data
ItemImageData GlockImage
{
	shapeFile = "GLOCK";
	mountPoint = 0;
      mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = GlockAmmo;
	accuFire = true;
	reloadTime = 0.152;
	fireTime = 0.03;


	lightType = 3;  // Weapon Fire
	lightRadius = 1.8;
	lightTime = 0.07;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireGlock;
};

ItemData Glock
{
	description = "Glock 17";
	className = "Weapon";
	shapeFile = "GLOCK";
	hudIcon = "sniper";
      	heading = "dDefender Weapons";
	shadowDetailMask = 4;
	imageType = GlockImage;
	price = 175;
	showWeaponBar = true;
      	validateShape = true;
};

// CLIP 9MM

$WeaponAmmo[Glock] = GlockAmmo;
$AutoUse[Glock] = True;
$Use[Glock] = True;

addWeapon("Glock");

// dev damage types
$GlockDamageType = 805;

// dev armors
$DamageScale[armorHuman, $GlockDamageType] = 1.0;
$DamageScale[armorHumanF, $GlockDamageType] = 1.0;
$DamageScale[armorZombie, $GlockDamageType] = 1.0;
$DamageScale[armorHeadcrab, $GlockDamageType] = 1.0;
$DamageScale[armorFheadcrab, $GlockDamageType] = 1.0;
$DamageScale[armorFzombie, $GlockDamageType] = 1.0;
$DamageScale[armorPheadcrab, $GlockDamageType] = 1.0;
$DamageScale[armorCzombie, $GlockDamageType] = 1.0;

$ItemMax[armorHuman, Glock] = 1;
$ItemMax[armorHuman, GlockAmmo] = 17;
$ItemMax[armorHumanF, Glock] = 1;
$ItemMax[armorHumanF, GlockAmmo] = 17;
$ItemMax[armorZombie, Glock] = 0;
$ItemMax[armorZombie, GlockAmmo] = 0;
$ItemMax[armorHeadcrab, Glock] = 0;
$ItemMax[armorHeadcrab, GlockAmmo] = 0;
$ItemMax[armorFheadcrab, Glock] = 0;
$ItemMax[armorFheadcrab, GlockAmmo] = 0;
$ItemMax[armorFzombie, Glock] = 0;
$ItemMax[armorFzombie, GlockAmmo] = 0;
$ItemMax[armorPheadcrab, Glock] = 0;
$ItemMax[armorPheadcrab, GlockAmmo] = 0;
$ItemMax[armorCzombie, Glock] = 0;
$ItemMax[armorCzombie, GlockAmmo] = 0;


$InvList[Glock] = 1;
$InvList[GlockAmmo] = 1;
$RemoteInvList[Glock] = 1;
$RemoteInvList[GlockAmmo] = 1;

// base onfire
function GlockImage::onFire(%this)
{
	%client = GameBase::getOwnerClient(%this);
	%name = Client::GetName(%client);
	if (!$zs::reloading[%name]) {
	%ammo = Player::getItemCount(%client,"GlockAmmo");
		if(%ammo > 0) {
		 	%trans = GameBase::getMuzzleTransform(%this);
		 	%vel = Item::getVelocity(%this);
			%name = Client::GetName(%client);
			if (GameBase::IsAtRest(%client) == "True") {
				if (Player::isCrouching(%client) == "True") {
					if ($zs::specialweapon[%name]) {
						Projectile::spawnProjectile("GlockBulletC",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
						if (%ammo >= 2) {
							Projectile::spawnProjectile("GlockBulletC",%trans,%this,%vel);
							Player::decItemCount(%client,"GlockAmmo");
						}
						if (%ammo >= 3) {
							Projectile::spawnProjectile("GlockBulletC",%trans,%this,%vel);
							Player::decItemCount(%client,"GlockAmmo");
						}
					}
					else {
						Projectile::spawnProjectile("GlockBulletC",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
					}
					Player::trigger(%this, $WeaponSlot, false);
				}
				else {
					if ($zs::specialweapon[%name]) {
						Projectile::spawnProjectile("GlockBullet",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
						if (%ammo >= 2) {
							Projectile::spawnProjectile("GlockBullet",%trans,%this,%vel);
							Player::decItemCount(%client,"GlockAmmo");
						}
						if (%ammo >= 3) {
							Projectile::spawnProjectile("GlockBullet",%trans,%this,%vel);
							Player::decItemCount(%client,"GlockAmmo");
						}
					}
					else {
						Projectile::spawnProjectile("GlockBullet",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
					}
					Player::trigger(%this, $WeaponSlot, false);
				}	
			}
			else {
				if ($zs::specialweapon[%name]) {
					Projectile::spawnProjectile("GlockBulletNR",%trans,%this,%vel);
					Player::decItemCount(%client,"GlockAmmo");
					if (%ammo >= 2) {
						Projectile::spawnProjectile("GlockBulletNR",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
					}
					if (%ammo >= 3) {
						Projectile::spawnProjectile("GlockBulletNR",%trans,%this,%vel);
						Player::decItemCount(%client,"GlockAmmo");
					}
				}
				else {
					Projectile::spawnProjectile("GlockBulletNR",%trans,%this,%vel);
					Player::decItemCount(%client,"GlockAmmo");
				}
				Player::trigger(%this, $WeaponSlot, false);
			}			
		}
	}
}

function Glock::onDrop(%player,%item)
{
	// do nothing
}	

function GlockAmmo::onDrop(%player,%item)
{
	// do nothing
}

// weapon deathmessages

$deathMsg[$GlockDamageType, 0] = "%1 [Glock 17] %2";
$deathMsg[$GlockDamageType, 1] = "%1 [Glock 17] %2";
$deathMsg[$GlockDamageType, 2] = "%1 [Glock 17] %2";
$deathMsg[$GlockDamageType, 3] = "%1 [Glock 17] %2";

