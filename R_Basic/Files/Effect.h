#pragma once
#include <string>

class Character;

class Effect
{
	enum Type { };

	Type mType;
	std::string mName, mDescription;
	bool mTemporary;
	float mLife;

	virtual void ApplyEffect(Character*) = 0;
	virtual void Update() = 0;
};

class Bonus
{
	enum Type { };

	Type mType;
	std::string mName, mDescription;

	virtual void ApplyBonus(Character*) = 0;
};