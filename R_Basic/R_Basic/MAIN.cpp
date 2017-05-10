// R_Basic.cpp : Defines the entry point for the console application.
//

#include <iostream>
#include <Windows.h>
#include "../Files/Character.h"

///Replace with 
Character* CreateEnemy(Character* _c)
{
	delete _c;
	_c = new Character();
	_c->AutoCreate();
	_c->SetName(std::string("Slime"));
	_c->SetLevel(Generate::GenerateNumRng(1, 10));

	return _c;
}

void DisplayCharacter(Character* _c)
{
	std::cout << "Name: " + _c->GetName() + "   Level: ";
	std::cout << _c->GetLevel();
	std::cout << "\n";

	Stats _st = _c->GetStats();
	Attributes _att = _c->GetAttributes();
	std::cout << "\n";
	std::cout << "--Stats--\n";
	std::cout << "Health: ";
	std::cout << _st.hp;
	std::cout << "\n";
	std::cout << "Defense: ";
	std::cout << _st.def;
	std::cout << "\n";
	std::cout << "Stamina: ";
	std::cout << _st.stm;
	std::cout << "\n";
	std::cout << "Carry Weight: ";
	std::cout << _st.cwp;
	std::cout << "\n";
	std::cout << "Attack: ";
	std::cout << _st.atk;
	std::cout << "\n";
	std::cout << "Speed: ";
	std::cout << _st.spd;
	std::cout << "\n";
	std::cout << "Magicka: ";
	std::cout << _st.mgk;
	std::cout << "\n";
	std::cout << "Cast Speed: ";
	std::cout << _st.csd;
	std::cout << "\n";
	std::cout << "Magic Attack: ";
	std::cout << _st.mak;
	std::cout << "\n";
	std::cout << "Resistance: ";
	std::cout << _st.res;
	std::cout << "\n";

	std::cout << "\n";
	std::cout << "--Attributes--\n";
	std::cout << "Vitality: ";
	std::cout << _att.vit;
	std::cout << "\n";
	std::cout << "Vigor: ";
	std::cout << _att.vig;
	std::cout << "\n";
	std::cout << "Endurance: ";
	std::cout << _att.end;
	std::cout << "\n";
	std::cout << "Strength: ";
	std::cout << _att.str;
	std::cout << "\n";
	std::cout << "Dexterity: ";
	std::cout << _att.dex;
	std::cout << "\n";
	std::cout << "Constitution: ";
	std::cout << _att.con;
	std::cout << "\n";
	std::cout << "Affinity: ";
	std::cout << _att.aff;
	std::cout << "\n";
	std::cout << "Luck: ";
	std::cout << _att.lck;
	std::cout << "\n";

}

int main()
{

	std::cout << "<- Roll Character ->\n";
	std::cin.get();

	Character* enemy = nullptr;
	Character* player = new Character();
	player->AutoCreate();
	player->SetName(std::string("Basic Man"));

	DisplayCharacter(player);
	std::cin.get();

	std::cout << "Adventure >>";
	std::cin.get();
	while (1)
	{
		if (GetAsyncKeyState(VK_ESCAPE))
			break;
		system("cls");
		enemy = CreateEnemy(enemy);
		std::cout << "You've encountered....\n";
		DisplayCharacter(enemy);
		std::cin.get();
	}


	delete player;
	delete enemy;

	return 0;
}

