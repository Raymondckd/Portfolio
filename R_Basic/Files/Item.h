#pragma once
#include <tuple>

#include "Stats_Attributes.h"
#include "Effect.h"


class Item
{
protected:
	std::string mName;

	float mWeight;
	unsigned int mCost;
	bool mEquippable;

public:
	Item(std::string, float, unsigned int);

	std::string GetName() const;
	float GetWeight() const;
	unsigned int GetCost() const;
	bool CanEquip() const;

};

//Move to own header/cpp

class Consumable : public Item
{
private:
public:
	Consumable(std::string, float, unsigned int);

};

class Material : public Item
{
private:
public:
	Material(std::string, float, unsigned int);

};

class Miscellaneous : public Item
{
private:
public:
	Miscellaneous(std::string, float, unsigned int);

};

class Projectile : public Item
{
	enum Type { ePhysical = 0, eMagical, eMixed, eMAX};
private:
	Effect* mEffects;
	int mNumEffects;

	Type mType;
public:
	Projectile(std::string, float, unsigned int);

};

class Weapon : public Item
{
	enum Style { eRanged, eMelee, eCombo, eSMAX};
	enum Grip { eSingle, eDouble, eBoth, eGMAX};
	enum Type { eBow, eGun, eSword, eAxe, eSpear, eChainBlades, eWhip, eMace, eLance, eShield, eTonfa, eStaff, eNunChucks, eTMAX};
	enum Dmg { eSharp, eBlunt, eMagical, eMagicalSharp, eMagicalBlunt, eDMAX};

private:
	Attributes mRequirements;
	Effect* mEffects;
	Bonus* mBounes;
	int mNumEffects, mNumBonuses;

	Type mType;
	Style mStyle;
	Grip mGrip;
	Dmg mDMG;

public:
	Weapon(std::string, float, unsigned int);

};

class Armor : public Item
{
	enum Style { };
	enum Type { };

private:
	Attributes mRequirements;
	Effect* mEffects;
	Bonus* mBounes;
	int mNumEffects, mNumBonuses;

	Style mStyle;
	Type mType;
public:
	Armor(std::string, float, unsigned int);

};
