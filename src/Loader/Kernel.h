#pragma once

#include "AccessLevels.h"
#include "Program.h"

class Kernel : public Program {
public:
	Kernel() : Program("KERNEL", DEVELOPER) {}

	void runApp() override {
		system("Kernel/kernel");
	}
};