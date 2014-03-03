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

#include "CommandSet.hpp"
#include "Clock.hpp"
#include "Application.hpp"

void CommandSet::Execute(const Args& args)
{
	// variables
	Clock& clock = Clock::GetInstance();
	int h = -1, m = -1, s = -1, index = -1;
	
	// check for hours
	if ((index = Application::GetArgumentIndex(args, 'H')) != -1) {
		h = std::stoi(args[index + 1]);
	}

	// check for minutes
	if ((index = Application::GetArgumentIndex(args, 'M')) != -1) {
		m = std::stoi(args[index + 1]);
	}

	// check for seconds
	if ((index = Application::GetArgumentIndex(args, 'S')) != -1) {
		s = std::stoi(args[index + 1]);
	}

	// execute command
	clock.Set(h, m, s);
}

const char* CommandSet::Name() const
{
	return SET.c_str();
}
