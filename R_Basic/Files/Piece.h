#pragma once
#include <vector>

class Character;
class Bonus;

class Piece
{
public:
	enum Type {eNONE = -1, ePawn, eBishop, eRook, eKnight, eQueen, eKing};

protected:
	std::vector<Bonus*> mBonuses;
private:

};