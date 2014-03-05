/* Copyright © 2014 David Wolf <d.wolf@live.at>
 *
 * This file is part of SWP1.
 *
 * SWP1 is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * SWP1 is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with SWP1.  If not, see <http://www.gnu.org/licenses/>.
 */

#include "CommandShow.hpp"
#include "Clock.hpp"
#include "Application.hpp"
#include "DigitalClockWindow.hpp"
#include <iostream>

void CommandShow::Execute(const Args& args)
{
	// variables
	int index = -1;
	int timezone = 0, x = -1, y = -1;

	// parse arguments
	ParseArgument(args, 'Z', timezone);
	ParseArgument(args, 'X', x);
	ParseArgument(args, 'Y', y);

	// check for type
	if ((index = Application::GetArgumentIndex(args, 'T')) != -1) {
		std::string arg = args[index + 1];

		if (arg == "DIGITAL") {
			new DigitalClockWindow(timezone, x, y);
		} else if (arg == "ANALOG") {
		} else {
		}
	} else {
		std::cout << "No valid type given.\n" << std::endl;
	}
}

const char* CommandShow::Name() const
{
	return SHOW.c_str();
}

const char* CommandShow::Help() const
{
	return "\t\t-t <type>: Clock types are \"DIGITAL\", \"ANALOG\". This type is REQUIRED.\n\t\t-z <timezone>: Defines timezone for this clock.\n\t\t-x <value>: Sets x position to value.\n\t\t-y <value>: Sets y position to value.\n";
}

int CommandShow::ParseArgument(const Args& args, char arg, int& result) const
{
	// variables
	int index = -1;

	// parse argument
	if ((index = Application::GetArgumentIndex(args, arg)) != -1) {
		try {
			result = std::stoi(args[index + 1]);
		} catch (std::invalid_argument&) {
			// do nothing
		}
	}

	return result;
}
