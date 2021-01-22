// Weapon Lasers

TargetLaserData greenTarget
{
   	laserBitmapName   = "paintPulse.bmp";
	
	beamTime = 0.1;
  	damageConversion  = 0.0;
   	baseDamageType    = 0;

  	lightRange        = 0.0;
   	lightColor        = { 0.25, 1.0, 0.25 };

   	detachFromShooter = false;
};

TargetLaserData flashOne
{
   	laserBitmapName   = "plas18.bmp";
	
	beamTime = 0.1;
  	damageConversion  = 0.0;
   	baseDamageType    = 0;

  	lightRange        = 3.0;
   	lightColor        = { 1.0, 1.0, 1.0 };
	isVisible          = false;

   	detachFromShooter = false;
};

LaserData flashTwo
{
   	laserBitmapName   = "plas18.bmp";
	
	beamTime = 0.1;
  	damageConversion  = 0.0;
   	baseDamageType    = 0;

  	lightRange        = 6.0;
   	lightColor        = { 0.5, 0.5, 0.5 };

   	detachFromShooter = false;
};
