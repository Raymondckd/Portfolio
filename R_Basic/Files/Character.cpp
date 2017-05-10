#include "Character.h"

void Character::AutoCreate()
{
	using namespace Generate;

	mLevel = 0;
	mExp = mCurrentExp = 0;
	mNeededExp = GenerateNumRng(50, 100);
	Initialize();
	BasicStats(mStats);
	BasicAttributes(mAttributes);
}