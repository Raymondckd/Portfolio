#pragma once
//std
//#include <string>
#include <unordered_map>
//custom
#include "Inventory.h"
#include "Piece.h"


class Character
{
public:
	enum Race {eNONE = -1, };
	enum Gender{eNA = -1, };
	enum EquipmentSlots { };
protected:
	//Name
	std::string mName;
	//Level
	unsigned long mLevel;
	unsigned long mExp, mNeededExp, mCurrentExp;
	unsigned int mAttributePoints;
	//Gold
	unsigned long mGold;
	//Race(s)
	Race mRace;
	Race mSubRace;
	//Gender
	Gender mGender;
	//Piece
	Piece* mPiece;
	//Abilities & Skills (Actives/Passives)
	//Equipped abilities
	//Class--Primary & Secondary
	//Inventory
	Inventory* mInventory;
	//Equipment
	std::unordered_map<EquipmentSlots, Item*> mEquipment;
	//Attributes
	Attributes mAttributes, mFinalAttributes;
	//Stats
	Stats mStats, mFinalStats;

	std::vector<Effect*> mEffects;
	std::vector<Bonus*> mBonuses;

public:
	///TODO: Fill these out.
	Character() {}
	~Character() {}

	//Getters
	std::string GetName() const { return mName; }
	unsigned long GetLevel() const { return mLevel; }
	Race GetRace() const;
	Race GetSubRace() const;
	Gender GetGender() const;
	Piece* GetPiece() const;
	//Abilities
	//Skills
	Inventory* GetInventory() const;
	//Equipment
	Attributes& GetAttributes() { return mAttributes; }
	Stats& GetStats() { return mStats; };

	//Setters
	void SetName(std::string s) { mName = s; }
	void SetLevel(unsigned long l) { mLevel = l; }

	//Other
	void LevelUp(unsigned long);
	void Loot(Character*);
	//void Loot(Container*);
	///TODO: Different attack types...ie: Heavy, Light, Magic, Projectile
	///TODO: How do they block/deflect/evade/counter???
	///<summary> Takes in defender and calls there take damage function </summary>
	unsigned int L_LightAttack(Character*);
	unsigned int L_HeavyAttack(Character*);
	unsigned int R_LightAttack(Character*);
	unsigned int R_HeavyAttack(Character*);
	
	///<summary> Takes in attackers stats and weapon/projectile and calculates dmg taken </summary>
	void TakeDamage(unsigned int);

	///Process Effects/ Bonuses--- Update, Apply
	void Update();
	void AutoCreate();
};
