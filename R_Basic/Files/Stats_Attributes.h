#pragma once
#include <random>
#include <stdlib.h>
#include <time.h>



struct Attributes
{
	int vit, vig, end, str, dex, con, aff, lck;
};

struct Stats
{
	long hp, def, stm, cwp, atk, spd, mgk, csd, mak, res;
};

namespace Generate
{
	static void Initialize()
	{
		srand((unsigned int)time(NULL));
	}

	static int GenerateNumRng(int _min, int _max)
	{
		return (rand() % _max) + _min;
	}
	static long GenerateNumRng(long _min, long _max)
	{
		return ((rand() % LONG_MAX) % _max) + _min;
	}
	static float GenerateNumRng(float _min, float _max)
	{
		return _min + static_cast<float> (rand()) / (static_cast<float> (RAND_MAX / (_max - _min)));
	}

	static void BasicAttributes(Attributes& _att)
	{
		_att.vit = GenerateNumRng(4, 8);
		_att.vig = GenerateNumRng(4, 8);
		_att.end = GenerateNumRng(4, 8);
		_att.str = GenerateNumRng(4, 8);
		_att.dex = GenerateNumRng(4, 8);
		_att.con = GenerateNumRng(4, 8);
		_att.aff = GenerateNumRng(4, 8);
		_att.lck = GenerateNumRng(4, 8);
	}

	static void BasicStats(Stats& _stats)
	{
		_stats.hp = GenerateNumRng((long)10, (long)200);
		_stats.def = GenerateNumRng((long)10, (long)200);
		_stats.stm = GenerateNumRng((long)10, (long)200);
		_stats.cwp = GenerateNumRng((long)10, (long)200);
		_stats.atk = GenerateNumRng((long)10, (long)200);
		_stats.spd = GenerateNumRng((long)10, (long)200);
		_stats.mgk = GenerateNumRng((long)10, (long)200);
		_stats.csd = GenerateNumRng((long)10, (long)200);
		_stats.mak = GenerateNumRng((long)10, (long)200);
		_stats.res = GenerateNumRng((long)10, (long)200);
	}
}